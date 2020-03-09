using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            for (int i = 1; i < 11; i++)
                list.Add(i);
            //打印链表
            list.ForEach(data => Console.Write(data + " "));
            Console.Write(" \n");
            //求最大值
            int max = int.MinValue;
            list.ForEach(data => max = Math.Max(data, max));
            Console.WriteLine($"最大值为：{max}");
            //求最小值
            int min = int.MaxValue;
            list.ForEach(data => min = Math.Min(data, min));
            Console.WriteLine($"最小值为：{min}");
            //求和
            int sum = 0;
            list.ForEach(data => sum += data);
            Console.WriteLine($"和值为：{sum}");

        }
    }
}
