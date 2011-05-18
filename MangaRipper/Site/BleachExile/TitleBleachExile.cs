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
            Address = url;
        }

        protected override List<Uri> ParseChapterAddresses(string html)
        {
            return null;
        }

        protected override List<IChapter> ParseChapterObjects(string html)
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

                MatchCollection mc = reg.Matches(html);

                foreach (Match item in mc)
                {
                    string value = item.Groups["Value"].Value;
                    string name = item.Groups["Text"].Value;

                    string link = String.Format("/{0}-chapter-{1}.html", serie, value);
                    var url = new Uri(Address, link);
                    IChapter chapter = new ChapterBleachExile(titlename + " " + name, url);

                    var same = list.Where(r => r.Name == chapter.Name && r.Address == chapter.Address).FirstOrDefault();

                    if (same == null)
                    {
                        list.Add(chapter);
                    }
                }
            }

            list.Reverse();
            return list;
        }
    }
}
