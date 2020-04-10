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

   
    public partial class OrderForm : Form
    {
        private Order order;
        public Order Order { get => order; set => order = value; }
        public OrderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order.Receiver.ReceiverID = textBox1.Text;
            order.Receiver.ReceiverName = textBox2.Text;
            order.Receiver.ReceiverAddress = textBox3.Text;
            order.Receiver.ReceiverPhone = textBox4.Text;//在添加新订单项的过程中如果发现收件人信息有误可以随时更改；
            try
            {
                OrderItem orderItem = new OrderItem(textBox5.Text,
                    new Product(textBox6.Text, Double.Parse(textBox7.Text)),
                    Int32.Parse(textBox8.Text));
                if (order.AddOrderItem(orderItem))
                {
                    DialogResult result = MessageBox.Show("添加订单成功！" +
                        " 是否继续添加订单？", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        textBox5.ResetText();
                        textBox6.ResetText();
                        textBox7.ResetText();
                        textBox8.ResetText();
                    }
                    else
                    {
                        this.Close();
                    }


                }
            }
            catch (Exception)
            {
                MessageBox.Show("字符格式错误！");
            }
               
               
            }
        }
            
        }
    

