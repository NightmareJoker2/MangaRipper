using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;

namespace MangaRipper
{
    public interface IChapter
    {
        event RunWorkerCompletedEventHandler DownloadImageCompleted;

        event System.ComponentModel.ProgressChangedEventHandler DownloadImageProgressChanged;

        string Name
        {
            get;
            set;
        }

        Uri Address
        {
            get;
        }

        string SaveTo
        {
            get;
        }

        bool IsBusy
        {
            get;
        }

        IWebProxy Proxy
        {
            get;
            set;
        }

        void DownloadImageAsync(string fileName);

        void CancelDownloadImage();
    }
}
