using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaRipper
{

    public class ChapterMangaShare : ChapterBase
    {
        public ChapterMangaShare(string name, Uri url)
        {
            Name = name;
            Url = url;
        }

        protected override List<Uri> ParsePageUrlFromHtml(string html)
        {
            var list = new List<Uri>();
            list.Add(Url);
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
                    var url = new Uri(Url, link);
                    list.Add(url);
                    m = m.NextMatch();
                }
            }
            return list;
        }

        protected override List<Uri> ParseImageUrlFromHtml(string html)
        {
            var list = new List<Uri>();
            Regex reg = new Regex(@"<img src=""(?<Value>[^""]+)"" border=""0"" alt=""[^""]+"" />\n",
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
    }
}
