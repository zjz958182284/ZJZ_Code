using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    [Serializable]
      public class Order:IComparable<Order>
    {

        private Receiver receiver;
        private List<OrderItem> orderItems = new List<OrderItem>();
        public OrderItem this[int index]
        {
            get
            {
                if (index < orderItems.Count)
                    return orderItems[index];
                else
                    return null;
            }
          
        }
        public List<OrderItem> OrderItems { get => orderItems; }
        public Receiver Receiver {
            get => receiver;
            set => receiver = value;
        }

        public Order() { receiver = null; }
        public Order(Receiver receiver)  
        {
            this.receiver = receiver;
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            foreach (OrderItem o in orderItems)
                if (orderItem.Equals(o))
                {
                    Console.WriteLine("添加重复订单项请重新添加！");
                    return;
                }
                    
            orderItems.Add(orderItem);
            
        }
        public override bool Equals(object order1)
        {
            if (order1 is Order)
            {
                Order order = (Order)order1;
                return this.receiver.ReceiverID == order.receiver.ReceiverID;
            }
            else
                return false;
 
        }

        public double SumPrice()
        {
            double sum = 0;
            foreach (OrderItem o in orderItems)
                sum += o.SumPrice();
            return sum;
        }

        public override string ToString()
        {
            string titleBar1= "收件人ID    "+"收件人      " + "收件人地址    " + "收件人电话   "+"订单总价\n";
            string content1 =receiver.ReceiverID+ "         " +receiver.ReceiverName + "       " +
                receiver.ReceiverAddress + "      "+ receiver.ReceiverPhone + "      " + SumPrice()+"\n\n";

            string titleBar2 = "订单明细为:\n" + "订单编号   " + "商品名称   " +
               // "商品ID     " + "商品类型     " + 
                "商品单价    "+ "所购商品数量    " + "商品总价   " + "订购时间\n";
            StringBuilder stringBuilder = new StringBuilder();
            foreach (OrderItem orderItem in orderItems)
            {

               stringBuilder.Append( orderItem.ToString());
            }
            return titleBar1 + content1 + titleBar2 + stringBuilder.ToString();
        }

        //默认按照用户ID排序
        public int CompareTo(Order other)
        {
            if (other == null)
                throw new System.ArgumentException();
            return this.receiver.ReceiverID.CompareTo(other.receiver.ReceiverID);
        }

        //迭代器方法
        public IEnumerator<OrderItem> GetEnumerator()
        {
            for (int i = 0; i < orderItems.Count; ++i)
                yield return orderItems[i];
        }

    }
    
}
