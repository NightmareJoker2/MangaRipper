using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using MangaRipper.Properties;
using System.Security;

namespace MangaRipper
{
    class Option
    {
        private static Option instance = new Option();

        public IWebProxy Proxy
        {
            get
            {
                string host = Settings.Default.ProxyHost;
                int port = Settings.Default.ProxyPort;
                string userName = Settings.Default.ProxyUserName;
                string password = Settings.Default.ProxyPassword;

                IWebProxy wp = new WebProxy(host, port);
                wp.Credentials = new NetworkCredential(userName, password);

                return wp;
            }
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
