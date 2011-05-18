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
            MatchCollection m = reg.Matches(html);

            foreach (Match item in m)
            {
                var value = new Uri(Address, item.Groups["Value"].Value);
                list.Add(value);
            }
           
            return list;
        }

        protected override List<Uri> ParsePageAddresses(string html)
        {
            var list = new List<Uri>();
            list.Add(Address);
            Regex reg = new Regex(@"<a href=""(?<Value>\d+.html)"">(?<Text>\d+)</a>",
                RegexOptions.IgnoreCase);
            MatchCollection m = reg.Matches(html);

            foreach (Match item in m)
            {
                var value = new Uri(Address, item.Groups["Value"].Value);
                string name = item.Groups["Text"].Value;
                list.Add(value);
            }
           
            return list;
        }
    }
}
