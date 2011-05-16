using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;

namespace MangaRipper
{
    [Serializable]
    public abstract class ChapterBase : IChapter
    {
        [field: NonSerialized]
        public event RunWorkerCompletedEventHandler DownloadImageCompleted;

        [field: NonSerialized]
        public event ProgressChangedEventHandler DownloadImageProgressChanged;

        [NonSerialized]
        protected BackgroundWorker worker;

        abstract protected List<Uri> GetPageAddresses(string html);

        abstract protected List<Uri> GetImageAddresses(string html);

        public string Name
        {
            get;
            protected set;
        }

        public Uri Address
        {
            get;
            protected set;
        }

        private List<Uri> ImageAddresses
        {
            get;
            set;
        }

        public string SaveTo
        {
            get;
            protected set;
        }

        public bool IsBusy
        {
            get
            {
                bool busy = false;
                if (worker != null)
                {
                    busy = worker.IsBusy;
                }
                return busy;
            }
        }

        public void DownloadImageAsync(string fileName)
        {
            SaveTo = fileName;
            if (worker == null || worker.IsBusy == false)
            {
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;

                worker.DoWork += new DoWorkEventHandler(DoWork);
                worker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);

                worker.RunWorkerAsync();
            }
        }

        public void CancelDownloadImage()
        {
            if (worker != null && worker.IsBusy == true)
            {
                worker.CancelAsync();
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (DownloadImageCompleted != null)
            {
                bool cancelled = (worker.CancellationPending == true || e.Cancelled == true);
                var arg = new RunWorkerCompletedEventArgs(null, e.Error, cancelled);
                DownloadImageCompleted(this, arg);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (DownloadImageProgressChanged != null)
            {
                DownloadImageProgressChanged(this, e);
            }
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            worker.ReportProgress(0);

            var client = new WebClient();
            client.Proxy = null;
            string html = client.DownloadString(Address);

            List<Uri> uris = GetPageAddresses(html);

            var sbHtml = new StringBuilder();

            int countHtml = 0;

            foreach (Uri item in uris)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                string content = client.DownloadString(item);
                countHtml++;

                sbHtml.AppendLine(content);

                int percent = countHtml * 100 / (uris.Count * 2);
                worker.ReportProgress(percent);
            }

            ImageAddresses = GetImageAddresses(sbHtml.ToString());

            string saveToFolder = SaveTo + "\\" + this.Name.RemoveFileNameInvalidChar();

            Directory.CreateDirectory(saveToFolder);

            int countImage = 0;
            foreach (Uri url in ImageAddresses)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                string filename = saveToFolder + "\\" + Path.GetFileName(url.LocalPath);

                DownloadFile(url, filename);

                countImage++;
                int percent = (countHtml + countImage) * 100 / (uris.Count * 2);
                worker.ReportProgress(percent);
            }
        }

        private void DownloadFile(Uri address, string fileName)
        {
            try
            {
                if (File.Exists(fileName) == false)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                    request.Proxy = null;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            string tmpFileName = Path.GetTempFileName();

                            using (Stream strLocal = new FileStream(tmpFileName, FileMode.Create))
                            {
                                byte[] downBuffer = new byte[2048];
                                int bytesSize = 0;
                                while ((bytesSize = responseStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                                {
                                    if (worker.CancellationPending == true)
                                    {
                                        return;
                                    }
                                    strLocal.Write(downBuffer, 0, bytesSize);
                                }

                            }

                            File.Move(tmpFileName, fileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = String.Format("{0} - Error while download chapter: {1}, url: {2}. {3}", DateTime.Now.ToLongTimeString(), this.Name, address.AbsoluteUri, ex.Message);
                throw new Exception(error);
            }
        }
    }
}
