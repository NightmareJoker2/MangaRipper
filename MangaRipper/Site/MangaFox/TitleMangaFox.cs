﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaRipper
{
    public class TitleMangaFox : TitleBase
    {
        public TitleMangaFox(Uri address)
        {
            Address = address;
        }
        protected override List<IChapter> ParseChapterObjects(string html)
        {
            var list = new List<IChapter>();
            Regex reg = new Regex("<a href=\"(?<Value>[^\"]+)\" class=\"ch\" title=\"[^\"]+\">(?<Text>.+?)</a>",
                RegexOptions.IgnoreCase);
            MatchCollection m = reg.Matches(html);

            foreach (Match item in m)
            {
                var value = new Uri(Address, item.Groups["Value"].Value);
                string name = item.Groups["Text"].Value;

                IChapter chapter = new ChapterMangaFox(name, value);
                list.Add(chapter);
            }

            return list;
        }

        protected override List<Uri> ParseChapterAddresses(string html)
        {
            return null;
        }
    }
}
