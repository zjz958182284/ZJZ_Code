using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool flag = false;
        private Graphics graphics;
        double length=100;
        int depth=10;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        Pen pen = new Pen(Color.Red);
        void drawCayleyTree(int n,double x0,double y0,
            double leng,double th)
        { 
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);

        }
        void drawLine(double x0,double  y0,double x1,double y1)
        {
            graphics.DrawLine(pen,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.pen.Color = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.depth = trackBar1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int leng = Int32.Parse(textBox1.Text);
                length = leng;
            }
            catch (Exception)
            {
                MessageBox.Show("输入不能为空且必须为100以内的整数！");
            }
            
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
                per1 = Double.Parse(radioButton3.Text);
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                per1 = Double.Parse(radioButton3.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
                per1 = Double.Parse(radioButton3.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            per2 = Double.Parse(comboBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i= Int32.Parse((string)listBox1.SelectedItem);
            th1 = Math.PI / i;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                int i = Int32.Parse(listView1.SelectedItems[0].Text);
                th2 = i;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.panel3.CreateGraphics();
            
            drawCayleyTree(depth, 155, 300, length, -Math.PI / 2);
            flag = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (graphics == null) graphics = this.panel3.CreateGraphics();
            drawCayleyTree(depth, 155, 300, length, -Math.PI / 2);
        }
    }
}
