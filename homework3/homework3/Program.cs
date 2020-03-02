using System;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Polygon p = null;
            Random random = new Random();
            String[] type = { "r", "s", "t" };
            double sumArea=0;
            int polyNum = 10;
            for(int i = 0; i <polyNum ; ++i)
            {
                p = PolygonFactory.createPolygon(type[random.Next(3)]);
                sumArea += p.Area();
            }
            Console.WriteLine($"这{polyNum}个多边形的面积总和为：{sumArea}");

        }
    }
}
