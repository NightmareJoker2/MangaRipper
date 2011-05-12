using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MangaRipper
{
    public interface ITitle
    {
        event RunWorkerCompletedEventHandler RefreshChapterCompleted;

        event ProgressChangedEventHandler RefreshChapterProgressChanged;

        List<IChapter> Chapters
        {
            get;
        }

        Uri Url
        {
            get;
        }

        bool IsBusy
        {
            get;
        }

        void RefreshChapterAsync();

        void CancelRefreshChapter();
    }
}
