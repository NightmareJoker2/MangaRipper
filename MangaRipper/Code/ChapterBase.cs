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
        public event RunWorkerCompletedEventHandler RefreshImageUrlCompleted;

        public event ProgressChangedEventHandler RefreshImageUrlProgressChanged;

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

        public void RefreshImageUrlAsync(string fileName)
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

        public void CancelRefreshImageUrl()
        {
            if (_bw != null && _bw.IsBusy == true)
            {
                _bw.CancelAsync();
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (RefreshImageUrlCompleted != null)
            {
                RefreshImageUrlCompleted(this, e);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (RefreshImageUrlProgressChanged != null)
            {
                RefreshImageUrlProgressChanged(this, e);
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
                string content = client.DownloadString(item);
                countHtml++;

                int percent = (countHtml + countImage) * 100 / (uris.Count * 2);
                var ev = new ProgressChangedEventArgs(percent, null);
                if (RefreshImageUrlProgressChanged != null)
                {
                    RefreshImageUrlProgressChanged(this, ev);
                }

                sb.AppendLine(content);
            }

            ImageUrls = ParseImageUrlFromHtml(sb.ToString());

            foreach (Uri url in ImageUrls)
            {
                string saveToFolder = SaveTo + "\\" + this.Name
                        .Replace("\\", "").Replace("/", "").Replace(":", "")
                        .Replace("*", "").Replace("?", "").Replace("\"", "")
                        .Replace("<", "").Replace(">", "").Replace("|", "");
                Directory.CreateDirectory(saveToFolder);
                string filename = Path.GetFileName(url.LocalPath);
                client.DownloadFile(url, saveToFolder + "\\" + filename);

                countImage++;
                int percent = (countHtml + countImage) * 100 / (uris.Count * 2);
                var ev = new ProgressChangedEventArgs(percent, null);
                if (RefreshImageUrlProgressChanged != null)
                {
                    RefreshImageUrlProgressChanged(this, ev);
                }
            }
        }
    }
}
