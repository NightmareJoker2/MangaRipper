using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangaRipper
{
    public class TitleBleachExile : TitleBase
    {
        public TitleBleachExile(Uri url)
        {
            Url = url;
        }

        protected override List<Uri> ParseChapterUrlFromHtml(string html)
        {
            return null;
        }

        protected override List<IChapter> ParseChapterFromHtml(string html)
        {
            var list = new List<IChapter>();
            Regex reg = new Regex(@"changeChapter\('(?<Serie>[^']+)', value\)",
                RegexOptions.IgnoreCase);
            Match m = reg.Match(html);

            if (m.Success)
            {
                string serie = m.Groups["Serie"].Value;

                string titlename = String.Format("<option value=\"{0}\" selected=\"selected\">(?<Title>[^<]+)</option>", serie);

                reg = new Regex(titlename,
                RegexOptions.IgnoreCase);

                m = reg.Match(html);

                if (m.Success)
                {
                    titlename = m.Groups["Title"].Value;
                }

                reg = new Regex("<option value=\"(?<Value>[^\"]+)\"(| selected=\"selected\")>Chapter (?<Text>[^\"<]+)</option>",
                RegexOptions.IgnoreCase);

                m = reg.Match(html);

                while (m.Success)
                {
                    string value = m.Groups["Value"].Value;
                    string name = m.Groups["Text"].Value;

                    string link = String.Format("/{0}-chapter-{1}.html", serie, value);
                    var url = new Uri(Url, link);
                    IChapter chapter = new ChapterBleachExile(titlename + " " + name, url);

                    
                    var same = list.Where(r => r.Name == chapter.Name && r.Url == chapter.Url).FirstOrDefault();

                    if (same == null)
                    {
                        list.Add(chapter);
                    }
                    m = m.NextMatch();
                }
            }

            list.Reverse();
            return list;
        }
    }
}
