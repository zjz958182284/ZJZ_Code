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
        private Hashtable urls;
        private int count = 0;     
        public string startUrl;
        public Action<string> updateListBox;
        public SimpleCrawler()
        {
            urls = new Hashtable();
          
        }

        public void Start()
        {
            this.urls.Add(startUrl, false);//加入初始页面           
            string html = this.DownLoad(startUrl); // 下载
            this.urls[startUrl] = true;
            this.count++;
            this.Parse(html,startUrl);//解析,并加入新的链接     
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
                updateListBox("正在下载" + currentUrl);
                 html = DownLoad(currentUrl); // 下载
                urls[currentUrl] = true;
                count++;
                Parse(html, startUrl);//解析,并加入新的链接
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
                updateListBox(e.Message);
                return "";
                   
            }

        }

        private void Parse(string html,string url)
        {
            Regex regex = new Regex(@"/{1,2}.+");//转换成绝对地址
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');

                if (strRef.Length == 0) continue;
                if (regex.IsMatch(strRef))
                    strRef = url + strRef;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
