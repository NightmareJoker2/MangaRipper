using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace MangaRipper.Core
{
    [Serializable]
    class ChapterMangaHere : ChapterBase
    {
        public ChapterMangaHere(string name, Uri address) : base(name, address) { }

        protected override List<Uri> ParsePageAddresses(string html)
        {
            var list = new List<Uri>();
            list.Add(Address);
            HtmlDocument htmlDocument = new HtmlDocument() { };
            htmlDocument.LoadHtml(html);
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//section[contains(@class, 'readpage_top')]/div[contains(@class, 'go_page')]/span[contains(@class, 'right')]/select/option");

            //Regex reg = new Regex(@"<option value=""(?<Value>http://www.mangahere.co/manga/[^""]+)"" (|selected=""selected"")>\d+</option>",
            //    RegexOptions.IgnoreCase);
            //MatchCollection matches = reg.Matches(html);

            foreach (HtmlNode node in nodes)
            {
                try
                {
                    string value = node.Attributes.Where(x => x.Name == "value").First().Value;
                    if (value.StartsWith("//") || !value.Contains("://") || value.StartsWith("http://www.mangahere.co/manga/") || value.StartsWith("https://www.mangahere.co/manga/"))
                    {
                        Uri uri = new Uri(Address, value);
                        list.Add(uri);
                    }
                }
                catch
                {

                }
            }

            //foreach (Match match in matches)
            //{
            //    var value = new Uri(Address, match.Groups["Value"].Value);
            //    list.Add(value);
            //}

            return list.Distinct().ToList();
        }

        protected override List<Uri> ParseImageAddresses(string html)
        {
            var list = new List<Uri>();
            HtmlDocument htmlDocument = new HtmlDocument() { };
            htmlDocument.LoadHtml(html);
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//img[@id='image']");

            //Regex reg = new Regex("<img src=\"(?<Value>[^\"]+)\" onerror",
            //    RegexOptions.IgnoreCase);
            //MatchCollection matches = reg.Matches(html);

            foreach (HtmlNode node in nodes)
            {
                try
                {
                    Uri value = new Uri(Address, node.Attributes.Where(x => x.Name == "src").First().Value);
                    list.Add(value);
                }
                catch
                {

                }
            }

            //foreach (Match match in matches)
            //{
            //    var value = new Uri(Address, match.Groups["Value"].Value);
            //    list.Add(value);
            //}

            return list;
        }
    }
}
