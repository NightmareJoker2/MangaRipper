using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaRipper
{
    public static class TitleFactory
    {
        public static ITitle CreateTitle(Uri uri)
        {
            ITitle title = null;
            switch (uri.Host)
            {
                case "www.mangafox.com":
                    title = new TitleMangaFox(uri);
                    break;
                case "read.mangashare.com":
                    title = new TitleMangaShare(uri);
                    break;
                case "manga.bleachexile.com":
                    title = new TitleBleachExile(uri);
                    break;
                default:
                    string message = String.Format("MangaRipper does not support this site ({0}).", uri.Host);
                    throw new Exception(message);
            }
            return title;
        }
    }
}
