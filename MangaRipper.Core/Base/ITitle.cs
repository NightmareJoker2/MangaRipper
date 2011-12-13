using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Threading;

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

        IWebProxy Proxy
        {
            get;
            set;
        }

        void PopulateChapterAsync();
    }
}
