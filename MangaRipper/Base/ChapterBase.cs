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

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }

            var client = new WebClient();
            client.Proxy = null;
            string html = client.DownloadString(Address);

            List<Uri> uris = GetPageAddresses(html);
            var sb = new StringBuilder();

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

                sb.AppendLine(content);

                int percent = countHtml * 100 / (uris.Count * 2);
                worker.ReportProgress(percent);
            }

            ImageAddresses = GetImageAddresses(sb.ToString());

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

                string filename = Path.GetFileName(url.LocalPath);

                string srcFileName = Path.GetTempFileName();
                string desFileName = saveToFolder + "\\" + filename;

                client.DownloadFile(url, srcFileName);

                File.Move(srcFileName, desFileName);

                countImage++;
                int percent = (countHtml + countImage) * 100 / (uris.Count * 2);
                worker.ReportProgress(percent);
            }
        }

        private string DownloadString(Uri address)
        {
            return "";
        }

        private void DownloadFile(Uri address, string fileName)
        {

        }
    }
}
