using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Crawler
{
    public partial class Form1 : Form
    {
        SimpleCrawler crawler = new SimpleCrawler();

        public Form1()
        {
            
            InitializeComponent();
            this.bindingSource1.DataSource = crawler;
            crawler.DownloadDelegate += UpdateInfo;
            
        }
        private string UpdateInfo(string s)
        {
           
            this.bindingSource1.DataSource = crawler;
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           crawler.startUrl = this.textBox1.Text;
            Thread thread = new Thread(crawler.Start);
            thread.Start();
        }
    }
}
