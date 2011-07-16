using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaCore
{
    public class TitleTruyenTranhTuan : TitleBase
    {
        public TitleTruyenTranhTuan(Uri address)
        {
            Address = address;
        }

        protected override List<IChapter> ParseChapterObjects(string html)
        {
            string title = ParseTitleName(html);

            var list = new List<IChapter>();
            Regex reg = new Regex("<td class=\"tbl_body(|2)\"><a href=\"(?<Value>[^\"]+)\">(?<Text>[^\"]+)</a></td>",
                RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(html);

            foreach (Match match in matches)
            {
                var value = new Uri(Address, match.Groups["Value"].Value);
                string name = String.Format("{0} {1}", title, match.Groups["Text"].Value);
                IChapter chapter = new ChapterTruyenTranhTuan(name, value);
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
            Regex reg = new Regex(@"Tên\struyện:\s(?<Text>[^\<]+)",
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
