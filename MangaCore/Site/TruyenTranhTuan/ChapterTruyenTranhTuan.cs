using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaCore
{
    [Serializable]
    public class ChapterTruyenTranhTuan : ChapterBase
    {
        public ChapterTruyenTranhTuan(string name, Uri address)
        {
            Name = name;
            Address = address;
        }

        protected override List<Uri> ParseImageAddresses(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex("\"><img src=\"(?<Value>[^\"]+)\"",
                RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(html);

            foreach (Match match in matches)
            {
                var value = new Uri(Address, match.Groups["Value"].Value);
                list.Add(value);
            }

            return list;
        }

        protected override List<Uri> ParsePageAddresses(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex(@"<option value=""(?<Value>\d+)""(| selected=""selected"")>\d+",
                RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(html);

            foreach (Match match in matches)
            {
                var value = new Uri(Address, match.Groups["Value"].Value + ".html");
                int number = list.Where(uri => uri.AbsoluteUri == value.AbsoluteUri).Count();
                if (number == 0)
                {
                    list.Add(value); 
                }
            }

            return list;
        }
    }
}
