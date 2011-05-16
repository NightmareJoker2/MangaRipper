using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaRipper
{
    [Serializable]
    public class ChapterBleachExile : ChapterBase
    {
        public ChapterBleachExile(string name, Uri url)
        {
            Name = name;
            Address = url;
        }

        protected override List<Uri> ParsePageAddresses(string html)
        {
            var list = new List<Uri>();
            list.Add(Address);
            Regex reg = new Regex(@"changePage\('(?<serie>[^']+)', '(?<chapter>[^']+)', value\)",
                RegexOptions.IgnoreCase);
            Match m = reg.Match(html);

            if (m.Success)
            {
                string serie = m.Groups["serie"].Value;
                string chapter = m.Groups["chapter"].Value;

                reg = new Regex("<option value=\"(?<Value>[^\"]+)\">Page (?<Text>[^\"<]+)</option>",
                RegexOptions.IgnoreCase);

                m = reg.Match(html);

                while (m.Success)
                {
                    string value = m.Groups["Value"].Value;
                    string link = String.Format("/{0}-chapter-{1}-page-{2}.html", serie, chapter, value);
                    var url = new Uri(Address, link);

                    var same = list.Where(r => r.AbsoluteUri == url.AbsoluteUri).FirstOrDefault();

                    if (same == null)
                    {
                        list.Add(url);
                    }
                    m = m.NextMatch();
                }
            }

            return list;
        }

        protected override List<Uri> ParseImageAddresses(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex("<img src=\"(?<Value>[^\"]+)\" border=\"0\"",
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
    }
}
