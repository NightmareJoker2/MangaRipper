﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaRipper
{
    public class TitleMangaShare : TitleBase
    {
        public TitleMangaShare(Uri address)
        {
            Address = address;
        }

        protected override List<Uri> ParseChapterAddresses(string html)
        {
            return null;
        }

        protected override List<IChapter> ParseChapterObjects(string html)
        {
            var list = new List<IChapter>();
            Regex reg = new Regex("<td class=\"datarow-0\"><a href=\"(?<Value>[^\"]+)\"><img src=\"http://read.mangashare.com/static/images/dlmanga.gif\" class=\"inlineimg\" border=\"0\" alt=\"(?<Text>[^\"]+)\" /></a></td>",
                RegexOptions.IgnoreCase);
            Match m = reg.Match(html);
            while (m.Success)
            {
                var value = new Uri(Address, m.Groups["Value"].Value);
                string name = m.Groups["Text"].Value;
                IChapter chapter = new ChapterMangaShare(name, value);
                list.Add(chapter);

                m = m.NextMatch();
            }
            return list;
        }
    }
}
