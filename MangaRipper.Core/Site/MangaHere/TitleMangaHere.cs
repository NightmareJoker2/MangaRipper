using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace MangaRipper.Core
{
    class TitleMangaHere : TitleBase
    {
        public TitleMangaHere(Uri address) : base(address) { }

        protected override List<IChapter> ParseChapterObjects(string html)
        {
            var list = new List<IChapter>();

            HtmlDocument htmlDocument = new HtmlDocument() { };
            //byte[] bytes = Encoding.Default.GetBytes(html);
            //html = Encoding.UTF8.GetString(bytes);
            htmlDocument.LoadHtml(html);
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='detail_list']/ul[1]/li[./span[@class='left']]");
            string title = WebUtility.HtmlDecode(htmlDocument.DocumentNode.SelectSingleNode("//div[@class='detail_list']/div[@class='title']").InnerText.Trim());
            if (title.StartsWith("Read ") && title.EndsWith(" Online"))
            {
                title = title.Substring("Read ".Length, title.Length - ("Read ".Length + " Online".Length));
            }

            foreach (HtmlNode node in nodes)
            {
                try
                {
                    Uri value = new Uri(Address, node.Descendants("a").First().Attributes.Where(x => x.Name == "href").First().Value);
                    string name = string.Concat(node.Descendants("a").First().InnerText.Trim()).Replace(string.Concat(title, " "), "");
                    if (Convert.ToDecimal(name) < 10)
                    {
                        name = string.Concat("0", name);
                    }
                    name = string.Concat("ch", name);
                    string volume = node.Descendants("span").FirstOrDefault().Descendants("span").FirstOrDefault().InnerText.Trim();
                    string chapterTitle = node.Descendants("span").FirstOrDefault().Descendants("#text").LastOrDefault().InnerText.Trim().Replace('/', '／').Replace('\\', '＼').Replace('?', '？').Replace('"', '\'').Replace(':', '：');
                    //if (!string.IsNullOrWhiteSpace(chapterTitle))
                    //{
                    //    if (!string.IsNullOrWhiteSpace(volume) && volume != chapterTitle)
                    //    {
                    //        name = string.Concat(name, " - ", volume);
                    //    }
                    //    name = string.Concat(name, " - ", chapterTitle);
                    //}
                    if (!string.IsNullOrWhiteSpace(chapterTitle) && volume != chapterTitle)
                    {
                        name = string.Concat(name, " - ", chapterTitle);
                    }
                    IChapter chapter = new ChapterMangaHere(name, value);
                    //list.Insert(0, chapter);
                    list.Add(chapter);
                }
                catch
                {

                }
            }
            
            //Regex reg = new Regex("<a class=\"color_0077\" href=\"(?<Value>[^\"]+)\"[^<]+>(?<Text>[^<]+)</a>",
            //    RegexOptions.Compiled |
            //    RegexOptions.IgnoreCase);
            //Regex reg2 = new Regex("<a class=\"color_0077\" href=\"(?'Value'.*)\"*.>(?'Text'.*)</a>.*<span class=\"mr6\">(?'Volume'.*)</span>(?'Title'.*)</span>",
            //    RegexOptions.Compiled |
            //    RegexOptions.IgnoreCase);
            //MatchCollection matches = reg.Matches(html);
            //MatchCollection matches2 = reg2.Matches(html);

            //foreach (Match match in matches)
            //{
            //    var value = new Uri(Address, match.Groups["Value"].Value);
            //    string name = string.Concat(match.Groups["Text"].Value.Trim(), " - ", match.Groups["Volume"].Value.Trim(), " - ", match.Groups["Title"].Value.Trim());
            //    IChapter chapter = new ChapterMangaHere(name, value);
            //    list.Add(chapter);
            //}

            return list;
        }
        //public string TrimStart(this string inputText, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        //{
        //    if (!string.IsNullOrEmpty(value))
        //    {
        //        while (!string.IsNullOrEmpty(inputText) && inputText.StartsWith(value, comparisonType))
        //        {
        //            inputText = inputText.Substring(value.Length - 1);
        //        }
        //    }

        //    return inputText;
        //}

        //public string TrimEnd(this string inputText, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        //{
        //    if (!string.IsNullOrEmpty(value))
        //    {
        //        while (!string.IsNullOrEmpty(inputText) && inputText.EndsWith(value, comparisonType))
        //        {
        //            inputText = inputText.Substring(0, (inputText.Length - value.Length));
        //        }
        //    }

        //    return inputText;
        //}

        //public string Trim(string inputText, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        //{
        //    return TrimStart(TrimEnd(inputText, value, comparisonType), value, comparisonType);
        //}
    }
}
