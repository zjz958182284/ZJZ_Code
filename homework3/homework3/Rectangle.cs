using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Rectangle:Polygon
    {
        private double width;
        private double height;

    public  Rectangle(double w,double h)
        {
            this.width = w;
            this.height = h;
        }
        public Rectangle()
        {
            Console.Write("请输入长方形的宽：");
            width = Double.Parse(Console.ReadLine());
            Console.Write("请输入长方形的高：");
            height = Double.Parse(Console.ReadLine());

        }
        public double Area()
        {
            if (!Isvalid())
            {
                Console.Write("长方形不合法！");
                return 0;
            }
            return width * height;
        }
        public bool Isvalid()
        {
            return width > 0 && height > 0;
        }
    }
}
