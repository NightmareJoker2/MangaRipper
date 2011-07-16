﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaCore
{
    [Serializable]
    public class ChapterMangaHere : ChapterBase
    {
        public ChapterMangaHere(string name, Uri address)
        {
            Name = name;
            Address = address;
        }

        protected override List<Uri> ParseImageAddresses(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex("img src=\"(?<Value>[^\"]+)\" width=\"[^\"]+\" id=\"image\"",
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
            list.Add(Address);
            Regex reg = new Regex(@"<option value=""(?<Value>http://www\.mangahere\.com/manga/[^""]+)""",
                RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(html);

            foreach (Match match in matches)
            {
                var value = new Uri(Address, match.Groups["Value"].Value);
                if (list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
           
            return list;
        }
    }
}
