using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace MangaRipper
{
    class Manga
    {
        public static readonly string WebAddress = "http://www.mangafox.com";

        public static List<Chapter> ListChaptersFromManga(string urlManga, int retryMax, ref bool cancel)
        {
            if (urlManga.IndexOf("?no_warning=1") == -1)
            {
                urlManga += "?no_warning=1";
            }
            string response = Common.DownloadWebsite(urlManga, retryMax, ref cancel);
            List<Chapter> arrChapters = ParseChaptersFromManga(response);
            return arrChapters;
        }

        public static List<string> ListImagesFromChapter(string urlChapter, int retryMax, ref bool cancel)
        {
            string response = Common.DownloadWebsite(urlChapter, retryMax, ref cancel);
            List<string> arrPages = ParsePagesFromChapter(response);
            List<string> images = new List<string>();
            foreach (string page in arrPages)
            {
                response = Common.DownloadWebsite(urlChapter + page + ".html", retryMax, ref cancel);
                string image = ParseImageFromPage(response);
                images.Add(image);
            }
            return images;
        }

        private static List<Chapter> ParseChaptersFromManga(string html)
        {
            Regex reg = new Regex(@"<a href=""(:?[^""]+)"" class=""chico"">\r\n\s+(:?.+?)\s+</a>", RegexOptions.IgnoreCase);
            Match m = reg.Match(html);
            List<Chapter> list = new List<Chapter>();
            while (m.Success)
            {
                string value = WebAddress + m.Groups[1].Value;
                string name = m.Groups[2].Value.Replace("                  "," ");
                list.Add(new Chapter(name, value));
                m = m.NextMatch();
            }
            return list;
        }

        private static List<string> ParsePagesFromChapter(string html)
        {
            Regex reg = new Regex("<option value=\"(:?[^\"]+)\" (:?|selected=\"selected\")>.+?</option>", RegexOptions.IgnoreCase);
            Match m = reg.Match(html);
            List<string> list = new List<string>();
            while (m.Success)
            {
                string value = m.Groups[1].Value;
                if (!list.Contains(value))
                {
                    list.Add(value);
                }
                m = m.NextMatch();
            }
            return list;
        }

        private static string ParseImageFromPage(string html)
        {
            Regex reg = new Regex("<img src=\"(:?[^\"]+)\" width=\"[^\"]+\" id=\"image\" alt=\".+?\"/>", RegexOptions.IgnoreCase);
            Match m = reg.Match(html);
            string value = "";
            if (m.Success)
            {
                value = m.Groups[1].Value;
            }
            return value;
        }
    }
}
