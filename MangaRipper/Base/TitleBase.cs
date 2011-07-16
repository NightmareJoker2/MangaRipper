using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Net;

namespace MangaRipper
{
    public abstract class TitleBase : ITitle
    {
        public event RunWorkerCompletedEventHandler PopulateChapterCompleted;

        public event ProgressChangedEventHandler PopulateChapterProgressChanged;

        protected BackgroundWorker worker;

        abstract protected List<Uri> ParseChapterAddresses(string html);

        abstract protected List<IChapter> ParseChapterObjects(string html);

        public List<IChapter> Chapters
        {
            get;
            protected set;
        }

        public Uri Address
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

        public IWebProxy Proxy { get; set; }

        public void CancelPopulateChapter()
        {
            if (IsBusy == true)
            {
                worker.CancelAsync();
            }
        }

        public void PopulateChapterAsync()
        {
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

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (PopulateChapterCompleted != null)
            {
                bool cancelled = (worker.CancellationPending == true || e.Cancelled == true);
                var arg = new RunWorkerCompletedEventArgs(null, e.Error, cancelled);
                PopulateChapterCompleted(this, arg);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (PopulateChapterProgressChanged != null)
            {
                PopulateChapterProgressChanged(this, e);
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
            client.Proxy = Proxy;
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(Address);

            var sb = new StringBuilder();
            sb.AppendLine(html);

            List<Uri> uris = ParseChapterAddresses(html);

            if (uris != null)
            {
                int count = 0;
                foreach (Uri item in uris)
                {
                    string content = client.DownloadString(item);
                    sb.AppendLine(content);
                    count++;
                    worker.ReportProgress(count * 100 / uris.Count);
                }
            }

            worker.ReportProgress(100);

            Chapters = ParseChapterObjects(sb.ToString());
        }
    }
}
