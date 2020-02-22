using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double op1, op2,result=0; string opSymbol, a;
            bool end = false;
            while (!end)
            {
                Console.Write("输入一个浮点数：");
                a = Console.ReadLine();
                op1 = Double.Parse(a);
                Console.Write("输入一个浮点数：");
                a = Console.ReadLine();
                op2 =Double.Parse(a);
                Console.Write("输入一个操作符：");
                opSymbol = Console.ReadLine();
                switch (opSymbol)
                {
                    case "+":  result = (op1 + op2);result.ToString(); break;
                    case "-":  (result=(op1 - op2)).ToString(); break;
                    case "*": (result = (op1 * op2)).ToString(); break;
                    case "/":
                        try
                        {   
                              (result = (op1 / op2)).ToString();

                        }

                        catch (DivideByZeroException ex)
                        {
                          Console.WriteLine("被除数为零请在第二个操作数输入一个非零值！！！\n" + ex.Message);
                          Console.Write("请重新输入第二个浮点数：");
                            a = Console.ReadLine();
                            op2 = Double.Parse(a);
                            (result = (op1 / op2)).ToString();
                        };
                        break;
                   
                }
                Console.WriteLine($"运算结果为:{op1}{opSymbol}{op2}={result}");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("是否继续使用? Y y or N n :");
                a = Console.ReadLine();
                if (a == "N" || a == "n")
                    end = true;
                else Console.WriteLine("---------------------------------");
                
            } 
            
           
           
           
        }
    }
}
