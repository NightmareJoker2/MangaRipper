using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace MangaRipper
{
    class Option
    {
        private static Option instance = new Option();

        public WebProxy Proxy
        {
            get;
            private set;
        }

        private Option()
        {

        }

        public static Option GetOption()
        {
            return instance;
        }
    }
}
