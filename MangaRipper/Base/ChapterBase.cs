using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Threading;

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

        abstract protected List<Uri> ParsePageAddresses(string html);

        abstract protected List<Uri> ParseImageAddresses(string html);

        public string Name
        {
            get;
            set;
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
            if (IsBusy == false)
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
            if (IsBusy == true)
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

            string html = DownloadString(Address);

            List<Uri> pageAddresses = ParsePageAddresses(html);

            var sbHtml = new StringBuilder();

            int countPage = 0;

            foreach (Uri pageAddress in pageAddresses)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    throw new OperationCanceledException();
                }
                string content = DownloadString(pageAddress);
                sbHtml.AppendLine(content);

                countPage++;
                int percent = countPage * 100 / (pageAddresses.Count * 2);
                worker.ReportProgress(percent);
            }

            ImageAddresses = ParseImageAddresses(sbHtml.ToString());

            string saveToFolder = SaveTo + "\\" + this.Name.RemoveFileNameInvalidChar();
            Directory.CreateDirectory(saveToFolder);

            int countImage = 0;

            foreach (Uri imageAddress in ImageAddresses)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    throw new OperationCanceledException();
                }
                string filename = saveToFolder + "\\" + Path.GetFileName(imageAddress.LocalPath);
                DownloadFile(imageAddress, filename);

                countImage++;
                int percent = (countImage * 100 / ImageAddresses.Count / 2) + 50;
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
                    request.Proxy = Option.GetProxy();
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
                                        throw new OperationCanceledException();
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
                string error = String.Format("{0} - Error while download: {2}. Reason: {3}.", DateTime.Now.ToLongTimeString(), this.Name, address.AbsoluteUri, ex.Message);
                throw new Exception(error);
            }
        }

        private string DownloadString(Uri address)
        {
            StringBuilder result = new StringBuilder();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                request.Proxy = Option.GetProxy();
                request.Credentials = CredentialCache.DefaultCredentials;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        byte[] downBuffer = new byte[2048];
                        int bytesSize = 0;
                        while ((bytesSize = responseStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                        {
                            if (worker.CancellationPending == true)
                            {
                                throw new OperationCanceledException();
                            }
                            result.Append(Encoding.UTF8.GetString(downBuffer, 0, bytesSize));
                        }
                    }
                }
                return result.ToString();
            }

            catch (Exception ex)
            {
                Thread.Sleep(1000);
                string error = String.Format("{0} - Error while download: {2} - Reason: {3}", DateTime.Now.ToLongTimeString(), this.Name, address.AbsoluteUri, ex.Message);
                throw new Exception(error);
            }
        }
    }
}
