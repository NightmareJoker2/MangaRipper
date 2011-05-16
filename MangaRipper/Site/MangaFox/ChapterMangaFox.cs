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
        public ChapterMangaFox(string name, Uri address)
        {
            Name = name;
            Address = address;
        }

        protected override List<Uri> ParseImageAddresses(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex("<img src=\"(?<Value>[^\"]+)\" onerror=",
                RegexOptions.IgnoreCase);
            Match m = reg.Match(html);
            while (m.Success)
            {
                var value = new Uri(Address, m.Groups["Value"].Value);
                list.Add(value);
                m = m.NextMatch();
            }
            return list;
        }

        protected override List<Uri> ParsePageAddresses(string html)
        {
            var list = new List<Uri>();
            list.Add(Address);
            Regex reg = new Regex(@"<a href=""(?<Value>\d+.html)"">(?<Text>\d+)</a>",
                RegexOptions.IgnoreCase);
            Match m = reg.Match(html);
            while (m.Success)
            {
                var value = new Uri(Address, m.Groups["Value"].Value);
                string name = m.Groups["Text"].Value;
                list.Add(value);
                m = m.NextMatch();
            }
            return list;
        }
    }
}
