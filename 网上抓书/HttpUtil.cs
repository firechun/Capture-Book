using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 网上抓书
{
    public class HttpUtil
    {
        public static string path = System.Environment.CurrentDirectory;

        public static string GetWebContent(string url, Encoding encoding)
        {
            string strResult = "";
            StreamReader streamReader = null;
            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //WebProxy proxy = new WebProxy("103.9.124.210", 8080);
                //request.Proxy = proxy;
                //声明一个HttpWebRequest请求 
                request.Timeout = 30000;
                //设置连接超时时间 
                request.Headers.Set("Pragma", "no-cache");
                response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                streamReader = new StreamReader(streamReceive, encoding);
                //strResult = streamReader.ReadToEnd();
                int len = 0;
                char[] chs = new char[1024];
                var result = new List<char>();
                while ((len = streamReader.Read(chs, 0, chs.Length)) != 0)
                {
                    result.AddRange(chs.Take(len));
                }
                strResult = new string(result.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine("出错：" + ex.ToString());
                WriteLog(url + " " + ex.ToString());
                throw ex;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return strResult;
        }

        public static bool Download(string url, string localFile)
        {
            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //WebProxy proxy = new WebProxy("103.9.124.210", 8080);
                //request.Proxy = proxy;
                //声明一个HttpWebRequest请求 
                request.Timeout = 30000;
                //设置连接超时时间 
                request.Headers.Set("Pragma", "no-cache");
                response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                //string localFile = $"{localFile}{Path.GetFileName(new Uri(url).LocalPath)}";
                int len;
                byte[] buffer = new byte[1024];
                using (var fs = new FileStream(localFile, FileMode.Create))
                {
                    while ((len = streamReceive.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        fs.Write(buffer, 0, len);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("出错：" + ex.ToString());
                WriteLog(ex.ToString());
                return false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }

        protected static void WriteLog(string content)
        {
            //if (!Directory.Exists(path))//如果日志目录不存在就创建
            //{
            //    Directory.CreateDirectory(path);
            //}

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string filename = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名
            File.AppendAllText(filename, time + ": " + content + "\r\n");
        }

    }
}
