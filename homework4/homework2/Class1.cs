using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework2
{
    delegate void ClockHandler(object sender, ClockEventArgs args);
    class ClockEventArgs
    {
        public int timeTick;
        public int timeAlarm;
    }
    class ClockSimulator
    {
        public event ClockHandler Onclock1;
        public event ClockHandler Onclock2;
        public void Clock(int tTick, int tAlarm)
        {
            ClockEventArgs args = new ClockEventArgs() { timeAlarm = tAlarm, timeTick = tTick };
            int time = 0;
            while (true)
            {
                Onclock1(this, args);
                time = ++time % 5;
                if (time == 0) //每过五秒
                    Onclock2(this, args);
            }
        }
    }
        class Form
        {
            public ClockSimulator clock = new ClockSimulator();
            public Form()
            {
                clock.Onclock1 += Clock_Onclock1;
                clock.Onclock2 += Clock_Onclock2;

            }
            void Clock_Onclock1(object sender, ClockEventArgs args)
            {

                Console.WriteLine("tick.....");
                Thread.Sleep(args.timeTick);


            }

            void Clock_Onclock2(object sender, ClockEventArgs args)
            {

                Console.WriteLine("alarm.....");

            }

        }
        /*class Program
        {
            public static void Main(string[] args)
            {
                Form form = new Form();
                form.clock.Clock(1000, 5000);//触发时钟事件
                Console.WriteLine("tick.....");
            }
        }*/

    
}
