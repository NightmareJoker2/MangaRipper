﻿using System;
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

        protected BackgroundWorker worker;

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
            bool cancelled = (worker.CancellationPending == true || e.Cancelled == true);

            var arg = new RunWorkerCompletedEventArgs(null, e.Error, cancelled);

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
            if (worker.CancellationPending == true)
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

            ImageUrls = ParseImageUrlFromHtml(sb.ToString());

            string saveToFolder = SaveTo + "\\" + this.Name
                        .Replace("\\", "").Replace("/", "").Replace(":", "")
                        .Replace("*", "").Replace("?", "").Replace("\"", "")
                        .Replace("<", "").Replace(">", "").Replace("|", "");
            Directory.CreateDirectory(saveToFolder);

            int countImage = 0;

            foreach (Uri url in ImageUrls)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                string filename = Path.GetFileName(url.LocalPath);
                client.DownloadFile(url, saveToFolder + "\\" + filename);

                countImage++;
                int percent = (countHtml + countImage) * 100 / (uris.Count * 2);
                worker.ReportProgress(percent);
            }
        }
    }
}
