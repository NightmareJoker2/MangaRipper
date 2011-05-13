using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MangaRipper
{
    public interface ITitle
    {
        event RunWorkerCompletedEventHandler PopulateChapterCompleted;

        event ProgressChangedEventHandler PopulateChapterProgressChanged;

        List<IChapter> Chapters
        {
            get;
        }

        Uri Address
        {
            get;
        }

        bool IsBusy
        {
            get;
        }

        void PopulateChapterAsync();

        void CancelPopulateChapter();
    }
}
