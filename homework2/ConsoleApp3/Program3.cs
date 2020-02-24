using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program3
    {
        static void Main(string[] args)
        {
            //埃及筛法
            int i ,j;
            Console.Write("求2~100以内的质数:");
            bool[] isPrimes = new bool[100];
            for (i=0; i < 100; ++i)
                isPrimes[i] = true;
            for (i = 2; i < 100; i++)
                if (isPrimes[i])
                    for (j = 2; j * i < 100; ++j)
                        isPrimes[j * i] = false;
            for(i=2; i<100; i++)
            {
                if (isPrimes[i] == true)
                    Console.Write($" {i}");
            }
            
        }
    }
}
