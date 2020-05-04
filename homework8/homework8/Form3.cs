using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Entity;
namespace homework8
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Order order = new Order();
                order.orderID = textBox1.Text;
                order.receiverAddress = textBox2.Text;
                order.receiverName = textBox3.Text;
                order.receiverPhone = textBox4.Text;
                using (var context = new OrderContext())
                {
                    try
                    {
                        context.Entry(order).State = EntityState.Added;
                        context.SaveChanges();
                        MessageBox.Show("添加订单成功");
                        this.textBox1.ReadOnly = true;
                this.button1.Dispose();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }

                
            }
            else MessageBox.Show("请输入OrderID");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                using (var context = new OrderContext())
                {
                    OrderItem item = new OrderItem();
                    try
                    {
                         item = new OrderItem
                        {

                            id = textBox5.Text,
                            buyNum = Int32.Parse(textBox7.Text),
                            productName = textBox6.Text,
                            productPrice = Double.Parse(textBox8.Text),
                            orderID = textBox1.Text,
                            orderTime = DateTime.Now
                        };
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {

                        context.Entry(item).State = EntityState.Added;
                        context.SaveChanges();
                        if (MessageBox.Show("是否继续添加订单项？", "添加成功", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            textBox5.ResetText(); textBox6.ResetText(); textBox7.ResetText(); textBox8.ResetText();

                        }
                        else this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show(ex.Message + "是否继续添加订单项？", "添加失败,原因如下", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            textBox5.ResetText(); textBox6.ResetText(); textBox7.ResetText(); textBox8.ResetText();

                        }
                        else this.Dispose();
                    }
                }
            }else MessageBox.Show("请输入OrderID");
        }
               
            }
        }
    

