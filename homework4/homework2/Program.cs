using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.clock.Clock(1000, 5000);//触发时钟事件
        }
    }
}
