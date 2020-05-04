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


namespace ConsoleApp1
{
    class Program
    {
            public Hashtable urls = new Hashtable();
        public int count = 0;
       
        static void Main(string[] args)
        {
                Program myCrawler = new Program();
            string startUrl = "https://blog.csdn.net/qq_37717853/article/details/78218606";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);//加入初始页面
            Console.WriteLine("爬行" + startUrl + "页面!");
            string html = myCrawler.DownLoad(startUrl); // 下载
            myCrawler.urls[startUrl] = true;
            myCrawler.count++;
            myCrawler.Parse(html);//解析,并加入新的链接
            Console.WriteLine("爬行结束");
            new Thread(myCrawler.Crawl).Start();
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            Regex regex = new Regex(@"(.html)$");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]==false && regex.IsMatch(url))
                    {
                        current = url;
                        break;
                    }
                   
                }

                if (current == null || count > 50) break;
               
               
                    Console.WriteLine("爬行" + current + "页面!");
                    string html = DownLoad(current); // 下载
                    urls[current] = true;
                    count++;
                    Parse(html);//解析,并加入新的链接
                    Console.WriteLine("爬行结束");
                List<double> d = new List<double>();
               
                var query = d.AsParallel().Where(n =>n==3.6);
              
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = "D:\\VS_workplace\\homework7\\" + count.ToString() + ".html";
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

