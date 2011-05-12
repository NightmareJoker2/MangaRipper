using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MangaRipper
{
    public interface IChapter
    {
        event RunWorkerCompletedEventHandler RefreshImageUrlCompleted;

        event System.ComponentModel.ProgressChangedEventHandler RefreshImageUrlProgressChanged;
    
        string Name
        {
            get;
        }

        Uri Url
        {
            get;
        }

        List<Uri> ImageUrls
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

        void RefreshImageUrlAsync(string fileName);

        void CancelRefreshImageUrl();
    }
}
