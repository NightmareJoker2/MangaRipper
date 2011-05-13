using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MangaRipper
{
    public interface IChapter
    {
        event RunWorkerCompletedEventHandler DownloadImageCompleted;

        event System.ComponentModel.ProgressChangedEventHandler DownloadImageProgressChanged;
    
        string Name
        {
            get;
        }

        Uri Url
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

        void DownloadImageAsync(string fileName);

        void CancelDownloadImage();
    }
}
