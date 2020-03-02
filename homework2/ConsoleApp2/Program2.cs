using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMin
{
    class Program2
    {
        static void Main(string[] args)
        {
            int[] array = { 10, 48, 98, 78, 65, 17, 48, 65, 15, 84 };
            int max = int.MinValue, min = int.MaxValue ;
            int aver=0, sum=0;
            for( int i=0;i<array.Length;i++)
            {
                sum += array[i];
                if (array[i] > max)
                    max = array[i];
                if (array[i] < min)
                    min = array[i];
            }
            aver = sum/array.Length;
            Console.Write("数组{ 10, 48, 98, 78, 65, 17, 48, 65, 15, 84 }：\n" +
                $"最大值为{max}\n" + $"最小值为{min}\n" + $"总和为{sum}\n" + $"平均值为{aver}");
            
        }
    }
}
