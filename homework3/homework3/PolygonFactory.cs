using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class PolygonFactory
    {
        public static Polygon createPolygon(String type)
        {
            Polygon polygon = null;
            switch (type)
            {
                case "r":
                    polygon = new Rectangle();break;
                case "s":
                    polygon = new Square();break;
                case "t":
                    polygon = new Triangle();break;
            }
            return polygon;
        }
       
    }
}
