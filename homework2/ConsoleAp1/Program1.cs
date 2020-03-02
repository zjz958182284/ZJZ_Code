using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program1
    {
        static void Main(string[] args)
        {
            int number, primeFactor=2;
            Console.Write("请输入一个整数然后我们会返回它的所有素数因子：");
            number = Int32.Parse(Console.ReadLine());
            Console.Write("它的所有素数因子为：1");
            while (number >= primeFactor)
            {
                if (number % primeFactor == 0)
                    do
                    {
                        Console.Write("*" + primeFactor);
                        number /= primeFactor;
                    } while (number % primeFactor == 0);///整数不能再分解出此质数因子
                primeFactor++;//质数因子递增
            }
        }
    }
}
