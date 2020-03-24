using System;
using System.Threading;
using System.Collections.Generic;
namespace homework5
{
    public class Program
    {
        static void Main(string[] args)
        {
            //test
            OrderService orderService = new OrderService();//一个订单服实例
            //模拟收件人1
            Order order1 = new Order(new Receiver("923","Jack", "长虹街33号", "195487859"));
            order1.AddOrderItem(new OrderItem("asd",new Product("苹果", 0.5), 5));
            Console.WriteLine(order1.OrderItems[0].ToString());
            
            order1.AddOrderItem(new OrderItem("ard",new Product("香蕉", 2.3), 8));
            Console.WriteLine(order1.OrderItems[1].ToString());
            
            order1.AddOrderItem(new OrderItem("aso",new Product("梨子", 1.2), 6));
            Console.WriteLine(order1.OrderItems[2].ToString());
            
            orderService.AddOrder(order1);
           
            Console.WriteLine( order1.ToString());

            ////模拟收件人2
            Order order2 = new Order(new Receiver("456", "Amy", "胜利街街63号", "199487549"));
            order2.AddOrderItem(new OrderItem("qge",new Product("苹果", 0.5), 5));
            Console.WriteLine(order2.OrderItems[0].ToString());

            order2.AddOrderItem(new OrderItem("qoe", new Product("香蕉", 2.3), 8));
            Console.WriteLine(order2.OrderItems[1].ToString());

            order2.AddOrderItem(new OrderItem("qye", new Product("梨子", 1.2), 6));
            Console.WriteLine(order2.OrderItems[2].ToString());

            orderService.AddOrder(order2);
           
            Console.WriteLine(order2.ToString());


            ////模拟收件人3
            Order order3 = new Order(new Receiver("789", "Amy", "红安街街8号", "199456949"));
            order3.AddOrderItem(new OrderItem("zgc",new Product("苹果", 0.5), 5));
          

            order3.AddOrderItem(new OrderItem("zlc", new Product("香蕉", 2.3), 8));
       

            order3.AddOrderItem(new OrderItem("zfc", new Product("梨子", 1.2), 6));
       

            orderService.AddOrder(order3);
           
         

            orderService.OrderSort();
            Console.WriteLine("查询买了香蕉的所有订单项:");
            List<OrderItem> items = orderService.GetOrderItems(orderService.Orders);

            foreach (OrderItem o in orderService.SearchOrderItemByProductName(items, "香蕉"))
                Console.WriteLine(o.ToString());

            Console.WriteLine("查询Amy的订单：");
            List<Order> orders = orderService.SearchOrderByName("Amy");
            foreach (Order o in orders)
                Console.WriteLine(o.ToString());

            //修改购物数量
            Order order = orderService.SearchOrderById("456");
            Console.WriteLine(order.OrderItems[1].ToString());
            orderService.ModiBuyNum("456", "香蕉", 150);
            Console.WriteLine(order.OrderItems[1].ToString());
        }
    }
}
