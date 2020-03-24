using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
   [Serializable]
    public class OrderItem
    {
        private string orderID;
        private Product product;
        private DateTime orderTime;
        private int buyNum;
        public string OrderID {
            get =>orderID;
            set =>orderID=value;
        }
        public int BuyNum {
            get => buyNum;
            set => buyNum = value;
        }
        public OrderItem() { }
        public DateTime OrderTime { get => orderTime; set => orderTime = value; }
        public OrderItem ( string orderid ,Product product,int buyNum)
        {
           
            this.orderID = orderid;
            this.product = product;
            this.buyNum = buyNum;
            orderTime = DateTime.Now;
        }
        public Product Product { get => product; set => product = value; }
        public override string ToString()
        {
            
            string content = orderID + "            " + product.ProductName + "     "+
                //+ product.ProductId + "     " + product.ProductType + "     " 
               + product.ProductPrice + "           " + buyNum + "              " + SumPrice() 
                + "     " +orderTime.ToLocalTime().ToString()+ "\n";
            return content;
                
        }

        public double SumPrice()
        {
            return this.product.ProductPrice * buyNum;
        }

        public int CompareTo(OrderItem other)
        {
            if (other == null)
                throw new System.ArgumentException();
            return this.orderTime.CompareTo(other.orderTime);//默认按照订购时间排序
        }

        public override bool Equals(object item)
        {
            if (!(item is OrderItem))
                return false;
            else
                return ((OrderItem)item).product.ProductName == this.product.ProductName;
        }


    }
}
