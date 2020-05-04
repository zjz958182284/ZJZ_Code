using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            OrderItem order = ((OrderItem)this.dataGridView1.Rows[e.RowIndex].DataBoundItem);
            using (OrderContext context = new OrderContext())
            {
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = this.orderItemBindingSource.Current as OrderItem;
            using (OrderContext context = new OrderContext())
            {
                try
                {
                    var orderitem2 = context.orderItems.Single(o => o.id == orderItem.id);
                    context.Entry(orderitem2).State = EntityState.Deleted;
                    context.SaveChanges();
                    orderItemBindingSource.DataSource = context.orderItems.Where(a => a.orderID == orderItem.orderID).ToList();
                }catch(Exception ex)
                {
                    MessageBox.Show("不存在此订单项");
                }
            }
        }
    }
}
