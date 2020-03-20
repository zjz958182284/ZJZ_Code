using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    //删除或者修改失败是引发的异常类型
    class DeleOrModiException : ApplicationException
    {
        public DeleOrModiException(string message) : base(message) { }
    }

    class OrderService
    {
        private List<Order> orders = new List<Order>();
        public List<Order> Orders { get => orders; }

        //添加订单
        public void AddOrder(Order order)
        {
            foreach (Order o in orders)
                if (order.Equals(o))
                {
                    Console.WriteLine("添加订单重复！");
                    return;
                }
                 
              orders.Add(order);
        }

        //按照收件人ID查询收件人订单
        public List<Order> SearchOrderById(string id)
        {
            var query = this.orders.Where(order => order.Receiver.ReceiverID == id);
            return  query.ToList();//是否返回空？
        }

        //按照收件人姓名查询收件人订单
        public List<Order> SearchOrderByName(string name)
        {
            var query = this.orders.Where(order => order.Receiver.ReceiverName == name)
                .OrderBy(order=>order.SumPrice());//查询结果按照订单总价排序
            if (query == null) Console.WriteLine("不存在此人的订单！");
            return query.ToList();
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
        public List<OrderItem> SearchOrderItemById(List<OrderItem> items ,string id)
        {
            var query = items.Where(item => item.OrderID == id);
            return query.ToList();
        }

        //按照商品名称进行查询
        public List<OrderItem> SearchOrderItemByProductName(List<OrderItem> items, string name)
        {
            var query = items.Where(item => item.Product.ProductName == name);
            return query.ToList();
        }

        //修改购物数量
        public bool ModiBuyNum(string userID,string name,int newNum)
        {
            try
            {
                List<Order> order = SearchOrderById(userID);
                if (order == null)
                    throw new DeleOrModiException("无法找到该收件人！");
                else
            {
                    foreach (OrderItem i in order[0])
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



        //删除订单
        public bool RemoveItem(string userID,string productName)
        {
            try
            {
                List<Order> order = SearchOrderById(userID);
                if (order == null)
                    throw new DeleOrModiException("无法找到该收件人！");
                else
                {
                    for(int i=0;i<order[0].OrderItems.Count;++i)
                        if (order[0].OrderItems[i].Product.ProductName == productName)
                        {
                            order[0].OrderItems.RemoveAt(i);
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



    }
}
