using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaRipper
{
    [Serializable]
    public class ChapterMangaShare : ChapterBase
    {
        public ChapterMangaShare(string name, Uri address)
        {
            Name = name;
            Address = address;
        }

        protected override List<Uri> ParsePageAddresses(string html)
        {
            var list = new List<Uri>();
            list.Add(Address);
            Regex reg = new Regex(@"<select name=""pagejump"" class=""page"" onchange=""javascript:window.location='(?<Value>[^']+)'\+this\.value\+'\.html';"">",
                RegexOptions.IgnoreCase);

            Match m = reg.Match(html);
            if (m.Success)
            {
                string value = m.Groups["Value"].Value;

                reg = new Regex(@"<option value=""(?<FileName>\d+)"">Page \d+</option>",
                RegexOptions.IgnoreCase);

                m = reg.Match(html);
                while (m.Success)
                {
                    string link = value + m.Groups["FileName"].Value + ".html";
                    var url = new Uri(Address, link);
                    list.Add(url);
                    m = m.NextMatch();
                }
            }
            return list;
        }

        protected override List<Uri> ParseImageAddresses(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex(@"<img src=""(?<Value>[^""]+)"" border=""0"" alt=""[^""]+"" />\n",
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
