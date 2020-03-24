using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework5
{
    //删除或者修改失败时引发的异常类型
    class DeleOrModiException : ApplicationException
    {
        public DeleOrModiException(string message) : base(message) { }
    }

    public class OrderService
    {
        private List<Order> orders = new List<Order>();
        public List<Order> Orders { get => orders; }

        //添加订单
        public void AddOrder(Order order)
        {
            if (order != null)
            {
                foreach (Order o in orders)
                    if (order.Equals(o))
                    {
                        Console.WriteLine("添加订单重复！");
                        return;
                    }

                orders.Add(order);
            }
        }

        //按照收件人ID查询收件人订单
        public Order SearchOrderById(string id)
        {
            var query = this.orders.Where(order => order.Receiver.ReceiverID == id);
            List<Order> list = query.ToList();
            if (list.Count == 0)
                return null;
            return  list[0];
        }

        //按照收件人姓名查询收件人订单
        public List<Order> SearchOrderByName(string name)
        {
            var query = this.orders.Where(order => order.Receiver.ReceiverName == name)
                .OrderBy(order=>order.SumPrice());//查询结果按照订单总价排序
            List<Order> list = query.ToList();
            if (list.Count==0) Console.WriteLine("不存在此人的订单！");
            return list;
        }

        //删除订单
        public bool RemoveOrder(string id)
        {
            try
            {
                for (int i = 0; i < this.orders.Count; ++i)
                    if (orders[i].Receiver.ReceiverID == id)
                        return orders.Remove(orders[i]);
                throw new DeleOrModiException("没有此订单，删除失败！");
            }catch(DeleOrModiException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            

        }

        //修改用户名
        public bool ModifyOrderAdr(string id,string newA)
        {
            try
            {
                for (int i = 0; i < this.orders.Count; ++i)
                    if (orders[i].Receiver.ReceiverID == id)
                    {
                        orders[i].Receiver.ReceiverAddress = newA;
                        return true;
                    }
                       
                throw new DeleOrModiException("修改用户地址失败！");
            }
            catch (DeleOrModiException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //修改用户电话号码
        public bool ModifyOrderPhone(string id, string newP)
        {
            try
            {
                for (int i = 0; i < this.orders.Count; ++i)
                    if (orders[i].Receiver.ReceiverID == id)
                    {
                        orders[i].Receiver.ReceiverPhone = newP;
                        return true;
                    }

                throw new DeleOrModiException("修改用户电话号码失败！");
            }
            catch (DeleOrModiException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //按照订单号进行查询
        public OrderItem SearchOrderItemById(string id)
        {
            List<OrderItem> items = GetOrderItems(this.orders);
            var query = items.Where(item => item.OrderID == id);
            List<OrderItem> list = query.ToList();
            if (list.Count == 0)
                return null;
            return list[0];
        }

        //按照商品名称进行查询
        public List<OrderItem> SearchOrderItemByProductName(List<OrderItem> items, string name)
        {
            var query = items.Where(item => item.Product.ProductName == name);
            List<OrderItem> list = query.ToList();
            if (list.Count == 0)
                return null;
            return list;
        }

        //按照收件人ID和商品名称查询
        public OrderItem SearchOrderItemByProductName(string userID, string name)
        {
            Order order = SearchOrderById(userID);
            if (order != null)
            {
                List<OrderItem> items = SearchOrderItemByProductName(order.OrderItems,
                    name);
                if (items != null)
                    return items[0];
            }
            return null;

        }

        //修改购物数量
        public bool ModiBuyNum(string userID,string name,int newNum)
        {
            try
            {
                Order order = SearchOrderById(userID);
                if (order == null)
                    throw new DeleOrModiException("无法找到该收件人！");
                else
            {
                    foreach (OrderItem i in order)
                        if (i.Product.ProductName == name)
                        {
                            i.BuyNum = newNum;
                            return true;
                        }
                    throw new DeleOrModiException($"收件人{userID}没有购买{name}");
            }
            }catch(DeleOrModiException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
             
        }



        //删除订单项
        public bool RemoveItem(string userID,string productName)
        {
            try
            {
                Order order = SearchOrderById(userID);
                if (order==null)
                    throw new DeleOrModiException("无法找到该收件人！");
                else
                {
                    for(int i=0;i<order.OrderItems.Count;++i)
                        if (order.OrderItems[i].Product.ProductName == productName)
                        {
                            order.OrderItems.RemoveAt(i);
                            return true;
                        }
                    throw new DeleOrModiException($"收件人{userID}没有购买{productName}无法删除");
                }
            }
            catch (DeleOrModiException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //对保存的订单进行排序
        public void OrderSort()
        {
            this.orders.Sort();
            foreach (Order o in orders)
                o.OrderItems.Sort((o1, o2) => o1.OrderID.CompareTo(o2.OrderID));

        }

        //获取指定订单集合中的所有订单项
        public List<OrderItem> GetOrderItems(List<Order> orders)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (Order order in orders)
                foreach (OrderItem item in order)
                    orderItems.Add(item);
            return orderItems;
            
        }

        //将所有订单序列化为xml文件;
        public void Export()
        {
            XmlSerializer xmlSerializer=new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("D:\\VS_workplace\\homework5\\homework5\\orders.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, this.orders);
            }

        }
        //从xml文件中导入订单
        public List<Order> Import(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> orders =(List <Order>)xml.Deserialize(fs);
                return orders;
            }
           
        }
        
        //将订单序列化为二进制订单
        public void ExportToBin()
        {
            BinaryFormatter b = new BinaryFormatter();
            using (FileStream file = new FileStream("D:\\VS_workplace\\homework5\\homework5\\Bin.temp", FileMode.Create))
            {
                b.Serialize(file, this.orders);
            }
        }

        //订单二进制反序列化
        public List<Order> ImportFromBin(string path)
        {
            BinaryFormatter b = new BinaryFormatter();
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                return (List<Order>)b.Deserialize(file);
            }
        }

    }
}
