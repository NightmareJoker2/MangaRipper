using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaRipper
{
    [Serializable]
    public class ChapterAnimeVibe : ChapterBase
    {
        public ChapterAnimeVibe(string name, Uri address)
        {
            Name = name;
            Address = address;
        }

        protected override List<Uri> ParsePageAddresses(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex(@"<option value=""(?<Value>\d+)""(| selected=""selected"")>#\d+</option>",
                RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(html);

            foreach (Match match in matches)
            {
                var value = new Uri(Address, match.Groups["Value"].Value);
                var obj = list.Where(uri => uri.AbsoluteUri == value.AbsoluteUri).FirstOrDefault();
                if (obj == null)
                {
                    list.Add(value);
                }
            }

            return list;
        }

        protected override List<Uri> ParseImageAddresses(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex("<img src=\"(?<Value>[^\"]+)\" alt=\"\" width=\"[^\"]+\" height=\"[^\"]+\" class=\"picture\" />",
                RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(html);

            foreach (Match match in matches)
            {
                string s = "/" + match.Groups["Value"].Value;
                var value = new Uri(Address, s);
                list.Add(value);
            }

            return list;
        }
    }
}
