﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MangaRipper.Core
{
    [Serializable]
    public abstract class ChapterBase : IChapter
    {
        [NonSerialized]
        private CancellationToken _cancellationToken;

        [NonSerialized]
        private Task _task;

        [NonSerialized]
        private Progress<ChapterProgress> _progress;

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
                bool result = false;
                if (_task != null)
                {
                    switch (_task.Status)
                    {
                        case TaskStatus.Created:
                        case TaskStatus.Running:
                        case TaskStatus.WaitingForActivation:
                        case TaskStatus.WaitingForChildrenToComplete:
                        case TaskStatus.WaitingToRun:
                            result = true;
                            break;
                    }
                }
                return result;
            }
        }

        public IWebProxy Proxy { get; set; }

        public ChapterBase(string name, Uri address)
        {
            Name = name;
            Address = address;

        }

        public Task DownloadImageAsync(string fileName, CancellationToken cancellationToken, Progress<ChapterProgress> progress)
        {
            _cancellationToken = cancellationToken;
            _progress = progress;
            SaveTo = fileName;

            _task = Task.Factory.StartNew(() =>
            {
                _progress.ReportProgress(new ChapterProgress(this, 0));
                string html = DownloadString(Address);
                if (ImageAddresses == null)
                {
                    PopulateImageAddress(html);
                }

                string saveToFolder = SaveTo + "\\" + this.Name.RemoveFileNameInvalidChar();
                if (!Directory.Exists(saveToFolder))
                {
                    Directory.CreateDirectory(saveToFolder);
                }

                int countImage = 0;

                foreach (Uri imageAddress in ImageAddresses)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                    string filename = saveToFolder + "\\" + Path.GetFileName(imageAddress.LocalPath);
                    DownloadFile(imageAddress, filename);

                    countImage++;
                    int percent = (countImage * 100 / ImageAddresses.Count / 2) + 50;
                    _progress.ReportProgress(new ChapterProgress(this, percent));
                }
            }, cancellationToken, TaskCreationOptions.None, TaskScheduler.Default);

            return _task;
        }


        private void PopulateImageAddress(string html)
        {
            List<Uri> pageAddresses = ParsePageAddresses(html);

            var sbHtml = new StringBuilder();

            int countPage = 0;

            foreach (Uri pageAddress in pageAddresses)
            {
                _cancellationToken.ThrowIfCancellationRequested();
                string content = DownloadString(pageAddress);
                sbHtml.AppendLine(content);

                countPage++;
                int percent = countPage * 100 / (pageAddresses.Count * 2);
                _progress.ReportProgress(new ChapterProgress(this, percent));
            }

            ImageAddresses = ParseImageAddresses(sbHtml.ToString());
        }

        private void DownloadFile(Uri address, string fileName)
        {
            try
            {
                if (File.Exists(fileName) == false)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                    request.Proxy = Proxy;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Referer = Address.AbsoluteUri;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        //if (response.StatusCode == HttpStatusCode.OK)
                        //{
                            // actually, leave this at throwing the standard exceptions for now...
                            using (Stream responseStream = response.GetResponseStream())
                            {
                                string tmpFileName = Path.GetTempFileName();

                                using (Stream strLocal = new FileStream(tmpFileName, FileMode.Create))
                                {
                                    byte[] downBuffer = new byte[2048];
                                    int bytesSize = 0;
                                    while ((bytesSize = responseStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                                    {
                                        _cancellationToken.ThrowIfCancellationRequested();
                                        strLocal.Write(downBuffer, 0, bytesSize);
                                    }
                                    if (response.ContentLength > 0 && strLocal.Length != response.ContentLength)
                                    {
                                        long streamSize = strLocal.Length;
                                        strLocal.Dispose();
                                        File.Delete(tmpFileName);
                                        throw new WebException(string.Format("Content-Length mismatch [file: {0}, header: {1}]", streamSize, response.ContentLength), WebExceptionStatus.ConnectionClosed);
                                    }
                                }

                                File.Move(tmpFileName, fileName);
                            }
                        //}
                    }
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                string error = String.Format("{0} - Error while download: {2} - Reason: {3}", DateTime.Now.ToLongTimeString(), this.Name, address.AbsoluteUri, ex.Message);
                throw new OperationCanceledException(error, ex);
            }
        }

        private string DownloadString(Uri address)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                request.Proxy = Proxy;
                request.Credentials = CredentialCache.DefaultCredentials;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (MemoryStream strCache = new MemoryStream())
                        {
                            byte[] downBuffer = new byte[2048];
                            int bytesSize = 0;
                            while ((bytesSize = responseStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                            {
                                _cancellationToken.ThrowIfCancellationRequested();
                                strCache.Write(downBuffer, 0, downBuffer.Length);
                            }
                            if (response.ContentLength > 0 && strCache.Length != response.ContentLength)
                            {
                                long streamSize = strCache.Length;
                                strCache.Dispose();
                                throw new WebException(string.Format("Content-Length mismatch [cache: {0}, header: {1}]", streamSize, response.ContentLength), WebExceptionStatus.ConnectionClosed);
                            }
                            else
                            {
                                result.Append(Encoding.UTF8.GetString(strCache.ToArray()));
                            }
                        }
                    }
                }
                return result.ToString();
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                string error = String.Format("{0} - Error while download: {2} - Reason: {3}", DateTime.Now.ToLongTimeString(), this.Name, address.AbsoluteUri, ex.Message);
                throw new Exception(error, ex);
            }
        }
    }
}
