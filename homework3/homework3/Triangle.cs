using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    public class Triangle:Polygon
    {
        private double side1, side2, side3;
        public Triangle(double s1, double s2, double s3)
        {
            side1 = s1;
            side2 = s2;
            side3 = s3;
        }
        public Triangle()
        {
            Console.Write("请输入三角形的三边:");
            String[] s =Console.ReadLine(). Split(' ');
            side1 = Double.Parse(s[0]);
            side2 = Double.Parse(s[1]);
            side3 = Double.Parse(s[2]);

        }

            public double Area()
        {
            if (!Isvalid())
            {
                Console.WriteLine("三角形不合法！");
                return 0;
            }
            double p;//p为三角形周长
            p = side1 + side1 + side3;
            return Math.Sqrt(p * (p - side1) * (p - side2)
                * (p - side3));
        }

          public  bool Isvalid()
        {
           bool isPos =( side1 > 0&& side2 > 0 && side3 > 0);
            return (side1 + side2 > side3 && side1 + side3 > side2
                 && side2 + side3 > side1 && isPos);

        }
    }
}
