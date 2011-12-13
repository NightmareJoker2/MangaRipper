using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace MangaRipper.Core
{
    public abstract class TitleBase : ITitle
    {
        public event RunWorkerCompletedEventHandler PopulateChapterCompleted;

        public event ProgressChangedEventHandler PopulateChapterProgressChanged;

        protected virtual List<Uri> ParseChapterAddresses(string html)
        {
            return null;
        }

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

        public IWebProxy Proxy { get; set; }

        public TitleBase(Uri address)
        {
            Address = address;
        }

        public void PopulateChapterAsync()
        {
            var taskSync = TaskScheduler.FromCurrentSynchronizationContext();

            var task = Task.Factory.StartNew(() =>
            {
                ReportProgress(0);

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
                        ReportProgress(count * 100 / uris.Count);
                    }
                }

                Chapters = ParseChapterObjects(sb.ToString());

                ReportProgress(100);
            });

            task.ContinueWith(delegate
            {
                if (PopulateChapterCompleted != null)
                {
                    var ex = task.Exception == null ? null : task.Exception.InnerException;
                    var arg = new RunWorkerCompletedEventArgs(null, ex, task.IsCanceled);
                    PopulateChapterCompleted(this, arg);
                }
            }, taskSync);

        }


        private void ReportProgress(int percent)
        {
            if (PopulateChapterProgressChanged != null)
            {
                PopulateChapterProgressChanged(this, new ProgressChangedEventArgs(percent, null));
            }
        }
    }
}
