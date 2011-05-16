using System;
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
            Match m = reg.Match(html);
            while (m.Success)
            {
                var value = new Uri(Address, m.Groups["Value"].Value);
                string name = m.Groups["Text"].Value;

                IChapter chapter = new ChapterMangaFox(name, value);
                list.Add(chapter);

                m = m.NextMatch();
            }
            return list;
        }

        protected override List<Uri> ParseChapterAddresses(string html)
        {
            return null;
        }
    }
}
