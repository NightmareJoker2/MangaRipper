using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;

namespace MangaRipper.Core
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

        IWebProxy Proxy
        {
            get;
            set;
        }

        void PopulateChapterAsync();

        void CancelPopulateChapter();
    }
}
