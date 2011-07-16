using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaCore
{
    public class TitleOtakuworks : TitleBase
    {
        public TitleOtakuworks(Uri address)
        {
            Address = address;
        }

        protected override List<IChapter> ParseChapterObjects(string html)
        {
            var list = new List<IChapter>();
            Regex reg = new Regex(@"<a href=""(?<Value>/view/[^""]+)"">(?<Text>[^\<]+)</a>",
                RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(html);

            string title = ParseTitleName(html);

            foreach (Match match in matches)
            {
                var value = new Uri(Address, match.Groups["Value"].Value + "/read/");
                string name = String.Format("{0} {1}", title, match.Groups["Text"].Value);
                IChapter chapter = new ChapterOtakuworks(name, value);
                list.Add(chapter);
            }

            return list;
        }

        protected override List<Uri> ParseChapterAddresses(string html)
        {
            return null;
        }

        private string ParseTitleName(string html)
        {
            string name = "";
            Regex reg = new Regex(@"<title>(?<Text>[^(]+)\s\(Manga\)",
                RegexOptions.IgnoreCase);

            Match match = reg.Match(html);

            if (match.Success)
            {
                name = match.Groups["Text"].Value;
            }

            return name;
        }
    }
}
