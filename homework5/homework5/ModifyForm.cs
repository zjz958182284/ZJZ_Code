using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework5
{
    public partial class ModifyForm : Form
    {
        public ModifyForm()
        {
            InitializeComponent();
        }
        public OrderService service = new OrderService();
        
        private void textBox8_Leave(object sender, EventArgs e)
        {
            this.textBox9.ReadOnly = false;
            Order o = service.SearchOrderById(textBox8.Text);              
            if (o != null)
                this.textBox9.Text =o.Receiver.ReceiverPhone;
            else MessageBox.Show("该ID不存在");
            this.textBox9.ReadOnly = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.textBox2.ReadOnly = false;
            Order o = service.SearchOrderById(textBox1.Text);
            if (o != null)
                this.textBox2.Text = o.Receiver.ReceiverAddress;
            else MessageBox.Show("该ID不存在");
            this.textBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(service.ModifyOrderAdr(textBox1.Text, textBox3.Text))
                MessageBox.Show("个人地址修改成功");
            else
                MessageBox.Show("个人地址修改失败");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(service.ModifyOrderPhone(textBox8.Text, textBox10.Text))
                MessageBox.Show("收件人电话号码修改成功");
            else
                MessageBox.Show("收件人电话号码修改失败");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(service.ModiBuyNum(textBox4.Text, textBox5.Text, Int32.Parse( textBox7.Text)))
                    MessageBox.Show($"所购商品数量已经从" + textBox6.Text + "个改为" +
                        textBox6.Text + "个!");
                else
                    MessageBox.Show("商品数量修改失败");

            }
            catch(Exception)
            {
                MessageBox.Show("商品数量请输入整数");
            }
           
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                this.textBox6.ReadOnly = false;
                OrderItem o = service.SearchOrderItemByProductName(textBox4
                    .Text, textBox5.Text);//获取原始商品数量
                if (o != null)
                    this.textBox6.Text = o.BuyNum.ToString();
                else MessageBox.Show("修改商品数量失败找不到此用户或者此用户购买的该商品!");
                this.textBox6.ReadOnly = true;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                this.textBox6.ReadOnly = false;
                OrderItem o = service.SearchOrderItemByProductName(textBox4
                    .Text, textBox5.Text);//获取原始商品数量
                if (o != null)
                    this.textBox6.Text = o.BuyNum.ToString();
                else MessageBox.Show("修改商品数量失败找不到此用户或者此用户购买的该商品!");
                this.textBox6.ReadOnly = true;
            }

        }
    }
}
