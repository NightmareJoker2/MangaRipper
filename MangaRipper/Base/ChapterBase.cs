using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;

namespace MangaRipper
{
    public abstract class ChapterBase : IChapter
    {
        public event RunWorkerCompletedEventHandler DownloadImageCompleted;

        public event ProgressChangedEventHandler DownloadImageProgressChanged;

        protected BackgroundWorker _bw;

        abstract protected List<Uri> ParsePageUrlFromHtml(string html);

        abstract protected List<Uri> ParseImageUrlFromHtml(string html);

        public string Name
        {
            get;
            protected set;
        }

        public Uri Url
        {
            get;
            protected set;
        }

        public List<Uri> ImageUrls
        {
            get;
            protected set;
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
                if (_bw != null)
                {
                    busy = _bw.IsBusy;
                }
                return busy;
            }
        }

        public void DownloadImageAsync(string fileName)
        {
            SaveTo = fileName;
            if (_bw == null || _bw.IsBusy == false)
            {
                _bw = new BackgroundWorker();
                _bw.WorkerReportsProgress = true;
                _bw.WorkerSupportsCancellation = true;

                _bw.DoWork += new DoWorkEventHandler(DoWork);
                _bw.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
                _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);

                _bw.RunWorkerAsync();
            }
        }

        public void CancelDownloadImage()
        {
            if (_bw != null && _bw.IsBusy == true)
            {
                _bw.CancelAsync();
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool cancelled = (_bw.CancellationPending == true || e.Cancelled == true);

            var arg = new RunWorkerCompletedEventArgs(e.Result, e.Error, cancelled);

            if (DownloadImageCompleted != null)
            {
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
            if (_bw.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }

            var client = new WebClient();
            client.Proxy = null;
            string html = client.DownloadString(Url);

            List<Uri> uris = ParsePageUrlFromHtml(html);
            var sb = new StringBuilder();

            int countHtml = 0;
            int countImage = 0;
            foreach (Uri item in uris)
            {
                if (_bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                string content = client.DownloadString(item);
                countHtml++;

                int percent = (countHtml + countImage) * 100 / (uris.Count * 2);
                _bw.ReportProgress(percent);

                sb.AppendLine(content);
            }

            ImageUrls = ParseImageUrlFromHtml(sb.ToString());

            string saveToFolder = SaveTo + "\\" + this.Name
                        .Replace("\\", "").Replace("/", "").Replace(":", "")
                        .Replace("*", "").Replace("?", "").Replace("\"", "")
                        .Replace("<", "").Replace(">", "").Replace("|", "");
            Directory.CreateDirectory(saveToFolder);

            foreach (Uri url in ImageUrls)
            {
                if (_bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                string filename = Path.GetFileName(url.LocalPath);
                client.DownloadFile(url, saveToFolder + "\\" + filename);

                countImage++;
                int percent = (countHtml + countImage) * 100 / (uris.Count * 2);
                _bw.ReportProgress(percent);
            }
        }
    }
}
