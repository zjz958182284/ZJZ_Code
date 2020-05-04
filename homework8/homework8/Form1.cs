using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
namespace homework8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (var context = new OrderContext())
            {

                this.orderBindingSource.DataSource = context.orders.ToArray();

            }

        }


        private void 添加订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            using (var context = new OrderContext())
            {
                this.orderBindingSource.DataSource = context.orders.ToList();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var context = new OrderContext())
            {
                if (this.textBox1.Text != "")
                    this.orderBindingSource.DataSource = context.orders.SingleOrDefault(
                        o => o.orderID == this.textBox1.Text);
                else this.orderBindingSource.DataSource = context.orders.ToList();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Order order = orderBindingSource.Current as Order;
            using (OrderContext context = new OrderContext())
            {
                var items = context.orderItems.Where(i => i.orderID == order.orderID);
                Form2 form = new Form2();
                form.orderItemBindingSource.DataSource = items.ToList();
                form.Show();


            }


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Order order = ((Order)this.dataGridView1.Rows[e.RowIndex].DataBoundItem);
            using (OrderContext context = new OrderContext())
            {
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            Order order = this.orderBindingSource.Current as Order;

            if (order != null)
            {
                using (OrderContext context = new OrderContext())
                {
                    try
                    {
                        Order order2 = context.orders.SingleOrDefault(b => b.orderID == order.orderID);
                        context.Entry(order2).State = EntityState.Deleted;

                        context.SaveChanges();
                        orderBindingSource.DataSource = context.orders.ToList();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("此订单不存在", ex.Message, MessageBoxButtons.OKCancel);

                    }




                }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }
    }
}

