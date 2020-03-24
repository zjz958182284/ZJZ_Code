using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
   [Serializable]
   public class Product
    {
        //private string productId;
        //private string productType;
        private string productName;
        private double productPrice;
        //       public string ProductId
        //   {
        //       get => productId;
        //       set => productId = value;
        //   }
        //   public string ProductType
        //   {
        //       get => productType;
        //       set => productType = value;
        //   }
        public Product() { }
        public string ProductName
        {
            get => productName;
            set => productName = value;
        }
        public double ProductPrice
        {
            get => productPrice;
            set => productPrice = value;
        }
        public Product(string productname, double productprice)
        {
            //this.productId = productId;
            this.productName = productname;
            //this.productType = productype;
            this.productPrice = productprice;   
        }
        public override string ToString()
        {
            return //productId + " " +
                   productName + "    " //+ productType + " " 
                   + productPrice;

        }
    }
}
