using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaRipper
{
    public class TitleAnimeVibe : TitleBase
    {
        public TitleAnimeVibe(Uri address)
        {
            Address = address;
        }

        protected override List<Uri> ParseChapterAddresses(string html)
        {
            return null;
        }

        protected override List<IChapter> ParseChapterObjects(string html)
        {
            string title = ParseTitleName(html);
            string manga = ParseMangaName(html);
            string option = GetChapterOptionTag(html);

            var list = new List<IChapter>();
            Regex reg = new Regex("<option value=\"(?<Value>[^\"]+)\"(| selected=\"selected\")>(?<Text>[^\"]+)</option>", RegexOptions.IgnoreCase);

            MatchCollection matches = reg.Matches(option);

            foreach (Match match in matches)
            {
                string chapter = match.Groups["Value"].Value;
                string uri = "http://manga.animevibe.net/" + manga + "/" + chapter + "/";
                string name = title + " " + match.Groups["Text"].Value;

                IChapter chapterobj = new ChapterAnimeVibe(name, new Uri(uri));
                list.Add(chapterobj);
            }

            list.Reverse();
            return list;
        }

        private string ParseTitleName(string html)
        {
            string name = "";
            Regex reg = new Regex("content=\"Read (?<Title>[^\"]+) Manga Online\"", RegexOptions.IgnoreCase);

            Match match = reg.Match(html);

            if (match.Success)
            {
                name = match.Groups["Title"].Value;
            }

            return name;
        }

        private string ParseMangaName(string html)
        {
            string name = "";
            Regex reg = new Regex(@"onchange=""change_chapter\('(?<Manga>[^']+)', this\.value\)""", RegexOptions.IgnoreCase);

            Match match = reg.Match(html);

            if (match.Success)
            {
                name = match.Groups["Manga"].Value;
            }

            return name;
        }

        private string GetChapterOptionTag(string html)
        {
            string name = "";
            Regex reg = new Regex(@"(?<Chapter><span>Chapter <select name=""chapter"" [^\n]+)", RegexOptions.IgnoreCase);

            Match match = reg.Match(html);

            if (match.Success)
            {
                name = match.Groups["Chapter"].Value;
            }

            return name;
        }
    }
}
