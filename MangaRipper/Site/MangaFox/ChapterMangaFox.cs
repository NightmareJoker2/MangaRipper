using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaRipper
{
    [Serializable]
    public class ChapterMangaFox : ChapterBase
    {
        public ChapterMangaFox(string name, Uri url)
        {
            Name = name;
            Url = url;
        }

        protected override List<Uri> ParseImageUrlFromHtml(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex("<img src=\"(?<Value>[^\"]+)\" onerror=",
                RegexOptions.IgnoreCase);
            Match m = reg.Match(html);
            while (m.Success)
            {
                var value = new Uri(Url, m.Groups["Value"].Value);
                list.Add(value);
                m = m.NextMatch();
            }
            return list;
        }

        protected override List<Uri> ParsePageUrlFromHtml(string html)
        {
            var list = new List<Uri>();
            list.Add(Url);
            Regex reg = new Regex(@"<a href=""(?<Value>\d+.html)"">(?<Text>\d+)</a>",
                RegexOptions.IgnoreCase);
            Match m = reg.Match(html);
            while (m.Success)
            {
                var value = new Uri(Url, m.Groups["Value"].Value);
                string name = m.Groups["Text"].Value;
                list.Add(value);
                m = m.NextMatch();
            }
            return list;
        }
    }
}
