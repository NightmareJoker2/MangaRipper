using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace MangaRipper
{
    static class Common
    {
        public static void SaveIChapterCollection(BindingList<IChapter> chapters, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, chapters);
            }
        }
        public static BindingList<IChapter> LoadIChapterCollection(string fileName)
        {
            var result = new BindingList<IChapter>();

            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    if (fs.Length != 0)
                    {
                        IFormatter formatter = new BinaryFormatter();
                        result = (BindingList<IChapter>)formatter.Deserialize(fs);
                    }
                }
            }
            catch { }

            return result;
        }


        public static string DownloadWebsite(string url, ref bool isCancel)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                while (!isCancel)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Proxy = null;
                    request.Timeout = 30000;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            byte[] downBuffer = new byte[1024];
                            int bytesSize = 0;
                            while ((bytesSize = responseStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                            {
                                if (isCancel) { break; }
                                result.Append(Encoding.UTF8.GetString(downBuffer, 0, bytesSize));
                            }
                        }
                    }
                    break;
                }
                return result.ToString();
            }

            catch (Exception ex)
            {
                string error = String.Format("Error while download {0}. {1}", url, ex.Message);
                throw new Exception(error);
            }

        }

        public static void DownloadImage(string imageURL, string saveToFolder, ref bool isCancel)
        {

            try
            {
                string filename = imageURL.Remove(0, imageURL.LastIndexOf("/") + 1);
                if (!File.Exists(saveToFolder + "\\" + filename))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageURL);
                    request.Proxy = null;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (Stream strLocal = new FileStream(saveToFolder + "\\" + filename + ".mr", FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                byte[] downBuffer = new byte[1024];
                                int bytesSize = 0;
                                while ((bytesSize = responseStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                                {
                                    if (isCancel) { break; }
                                    strLocal.Write(downBuffer, 0, bytesSize);
                                }
                            }
                            if (!isCancel)
                            {
                                File.Move(saveToFolder + "\\" + filename + ".mr", saveToFolder + "\\" + filename);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = String.Format("Error while download {0}. {1}", imageURL, ex.Message);
                throw new Exception(error);
            }
        }
    }
}