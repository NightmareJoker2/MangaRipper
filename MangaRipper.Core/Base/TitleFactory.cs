using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaRipper.Core
{
    public static class TitleFactory
    {
        /// <summary>
        /// Create Title object base on uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
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
                //case "manga.bleachexile.com":
                //    title = new TitleBleachExile(uri);
                //    break;
                case "www.mangatoshokan.com":
                    title = new TitleMangaToshokan(uri);
                    break;
                //case "www.mangahere.com":
                //    title = new TitleMangaHere(uri);
                //    break;
                case "www.otakuworks.com":
                    title = new TitleOtakuworks(uri);
                    break;
                //case "truyentranhtuan.com":
                //case "www.truyentranhtuan.com":
                //    title = new TitleTruyenTranhTuan(uri);
                //    break;
                //case "manga.animevibe.net":
                //    title = new TitleAnimeVibe(uri);
                //    break;
                default:
                    string message = String.Format("This site ({0}) is not supported.", uri.Host);
                    throw new Exception(message);
            }
            return title;
        }

        /// <summary>
        /// Get list of supported manga sites
        /// </summary>
        /// <returns></returns>
        public static List<string[]> GetSupportedSites()
        {
            var lst = new List<string[]>();
            //lst.Add(new string[] { "AnimeVibe", "http://manga.animevibe.net/", "English" });
            //lst.Add(new string[] { "BleachExile", "http://manga.bleachexile.com/", "English" });
            lst.Add(new string[] { "MangaFox", "http://www.mangafox.com/", "English" });
            //lst.Add(new string[] { "MangaHere", "http://www.mangahere.com/", "English" });
            lst.Add(new string[] { "MangaShare", "http://read.mangashare.com/", "English" });
            lst.Add(new string[] { "MangaToshokan", "http://www.mangatoshokan.com/", "English" });
            lst.Add(new string[] { "Otakuworks", "http://www.otakuworks.com/", "English" });
            //lst.Add(new string[] { "TruyenTranhTuan", "http://www.truyentranhtuan.com/", "Vietnamese" });
            return lst;
        }
    }
}
