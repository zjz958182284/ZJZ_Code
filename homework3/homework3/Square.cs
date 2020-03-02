using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Square : Polygon
    {
        private double width;
        

        public  Square(double w)
        {
            this.width = w;
          
        }
        public Square()
        {
            Console.Write("请输入正方形的边长：");
            width = Double.Parse(Console.ReadLine());
        }
        public  double Area()
        {
            if (!Isvalid())
            {
                Console.Write("正方形不合法！");
                return 0;
            }
            return width * width;
        }

        public bool Isvalid()
        {
            return width > 0 ;
        }
    }
}
