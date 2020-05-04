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
            crawler.updateListBox += update1;
  
        }
        private void update1(string s)
        {
            this.listBox1.Items.Add(s);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            crawler.startUrl = this.textBox1.Text;
            Thread thread = new Thread(crawler.Start);
            thread.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.bindingSource1.ResetBindings(false);
        }
    }
}
