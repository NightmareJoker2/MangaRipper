using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MangaRipper
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
                case "manga.bleachexile.com":
                    title = new TitleBleachExile(uri);
                    break;
                case "www.mangatoshokan.com":
                    title = new TitleMangaToshokan(uri);
                    break;
                case "www.mangahere.com":
                    title = new TitleMangaHere(uri);
                    break;
                default:
                    string message = String.Format("This site ({0}) is not supported.", uri.Host);
                    throw new Exception(message);
            }
            return title;
        }

        /// <summary>
        /// Populate supported sites into DataGridView
        /// </summary>
        /// <param name="grid"></param>
        public static void PopulateSiteGrid(DataGridView grid)
        {
            grid.Rows.Clear();
            grid.Rows.Add("BleachExile", "http://manga.bleachexile.com/", "English");
            grid.Rows.Add("MangaFox", "http://www.mangafox.com/", "English");
            grid.Rows.Add("MangaHere", "http://www.mangahere.com/", "English");
            grid.Rows.Add("MangaShare", "http://read.mangashare.com/", "English");
            grid.Rows.Add("MangaToshokan", "http://www.mangatoshokan.com/", "English");
        }
    }
}
