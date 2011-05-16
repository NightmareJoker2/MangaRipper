using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaRipper
{
    public static class Extension
    {
        public static string RemoveFileNameInvalidChar(this String input)
        {
            return input.Replace("\\", "").Replace("/", "").Replace(":", "")
                        .Replace("*", "").Replace("?", "").Replace("\"", "")
                        .Replace("<", "").Replace(">", "").Replace("|", "");
        }
    }
}
