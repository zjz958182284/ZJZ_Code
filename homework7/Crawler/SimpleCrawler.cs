using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Crawler
{
    class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private List<string> s = new List<string>();
        public List<string> URLs { get => s; set => s = value; }
        public string startUrl;
        public Func<string, string> DownloadDelegate;
        public SimpleCrawler()
        {
            DownloadDelegate = DownLoad;
        }
        public void Start()
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            myCrawler.urls.Add(startUrl, false);//加入初始页面           
            string html = myCrawler.DownloadDelegate(startUrl); // 下载
            myCrawler.urls[startUrl] = true;
            myCrawler.count++;
            myCrawler.Parse(html);//解析,并加入新的链接     
            myCrawler.StartCrawl();
        }

        private void StartCrawl()
        {

            Regex regex = new Regex(@"(.html)$");
            while (true)
            {
                string currentUrl = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url] == false && regex.IsMatch(url))
                    {
                        currentUrl = url;
                        break;
                    }

                }

                if (currentUrl == null || count > 10)break;
                s.Add("正在下载" + currentUrl);
                string html = DownloadDelegate(currentUrl); // 下载
                urls[currentUrl] = true;
                count++;
                Parse(html);//解析,并加入新的链接
            }
        }

        public string DownLoad(string url)//exception
        {

            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            try
            {
                string html = webClient.DownloadString(url);
                string fileName = "D:\\VS_workplace\\homework7\\" + count.ToString() + ".html";
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception e)
            {
                s.Add(e.Message);
                return "";
                   
            }

        }

        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
