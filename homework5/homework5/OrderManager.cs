using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace homework5
{
    public partial class OrderManager : Form
    {

        private OrderService orderService;
        private Order order1;
        private Order order2;
        private Order order3;

        public OrderManager()
        {
            InitializeComponent();
            orderService = new OrderService();//一个订单服实例
            //模拟收件人1
            order1 = new Order(new Receiver("923", "Jack", "长虹街33号", "195487859"));
            order1.AddOrderItem(new OrderItem("asd", new Product("苹果", 0.5), 5));
            order1.AddOrderItem(new OrderItem("ard", new Product("香蕉", 2.3), 8));
            order1.AddOrderItem(new OrderItem("aso", new Product("梨子", 1.2), 6));
            orderService.AddOrder(order1);
            //模拟收件人2
            order2 = new Order(new Receiver("456", "Amy", "胜利街街63号", "199487549"));
            order2.AddOrderItem(new OrderItem("qge", new Product("苹果", 0.5), 5));
            order2.AddOrderItem(new OrderItem("qoe", new Product("香蕉", 2.3), 8));
            order2.AddOrderItem(new OrderItem("qye", new Product("梨子", 1.2), 6));
            orderService.AddOrder(order2);
            ////模拟收件人3
            order3 = new Order(new Receiver("789", "Amy", "红安街街8号", "199456949"));
            order3.AddOrderItem(new OrderItem("zgc", new Product("苹果", 0.5), 5));
            order3.AddOrderItem(new OrderItem("zlc", new Product("香蕉", 2.3), 8));
            order3.AddOrderItem(new OrderItem("zfc", new Product("梨子", 1.2), 6));
            orderService.AddOrder(order3);
            this.bindingSource1.DataSource = orderService.Orders;       

        }

        private void showOrderDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(dataGridView2.CurrentRow.DataBoundItem is Order))
            {
                 MessageBox.Show("订单项为空");
            }
            else
            {
            Form1 form = new Form1();
                Order order = (bindingSource1.Current as Order);
                form.bindingSource1.DataSource= order;

                
            form.Show();
                
            }
            
        }

        private void showAllOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = orderService.Orders;//相当于ResetBindings(false)
        }

        private void button2_Click(object sender, EventArgs e)
        {
             Regex r = new Regex("[0-9]+");
            List<Order> orders = new List<Order>();
            if (r.IsMatch(textBox1.Text))
            {
                Order order = orderService.SearchOrderById(this.textBox1.Text);              
                orders.Add(order);//把order装进集合防止出现dataGridView不明点击异常
            }
            else
            {
                orders = orderService.SearchOrderByName(textBox1.Text);
            }
            this.bindingSource1.DataSource = orders;
        }


        private void New_OrderItem_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            Order order = new Order();
            orderForm.Order = order;
            orderForm.ShowDialog();           
            this.orderService.AddOrder(order);
            bindingSource1.ResetBindings(false);
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (orderService.RemoveOrder(textBox2.Text))
                bindingSource1.ResetBindings(false);
            else MessageBox.Show("不存在此收件人的订单！");          
        }

        private void Modify_OrdeItem_Click(object sender, EventArgs e)
        {
            ModifyForm mf = new ModifyForm();
            mf.service = this.orderService;
            mf.ShowDialog();           

        }

        private void exportAsXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Filter = "xml文件|*.xml";
            if(this.saveFileDialog1.ShowDialog()==DialogResult.OK)
               orderService.Export(saveFileDialog1.FileName);
          
            
        }

        private void importFromXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XMl文件|*xml";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<Order> orders = orderService.Import(openFileDialog1.FileName);
                orderService.Orders = orders;
                this.bindingSource1.DataSource = orderService.Orders;
            }

        }

        private void importFromBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "bin文件|*.bin";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                List<Order> orders = orderService.ImportFromBin(openFileDialog1.FileName);
                orderService.Orders = orders;
                this.bindingSource1.DataSource = orderService.Orders;
            }
        }

        private void exportAsBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Filter = "bin文件|*.bin";
            if(this.saveFileDialog1.ShowDialog()==DialogResult.OK)
                orderService.ExportToBin(saveFileDialog1.FileName);
        }
    }
}
