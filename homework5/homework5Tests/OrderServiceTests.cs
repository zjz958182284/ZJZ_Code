using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5.Tests
{

    [TestClass()]
    public class OrderServiceTests
    {
         OrderService orderService;
         Order order1;
         Order order2;
         Order order3;
        //test
        [TestInitialize]
        public void  Init()
        {
            orderService = new OrderService();//一个订单服实例
            //模拟收件人1
            order1 = new Order(new Receiver("923", "Jack", "长虹街33号", "195487859"));
            order1.AddOrderItem(new OrderItem("asd", new Product("苹果", 0.5), 5));
            order1.AddOrderItem(new OrderItem("ard", new Product("香蕉", 2.3), 8));
            order1.AddOrderItem(new OrderItem("aso", new Product("梨子", 1.2), 6));
            orderService.AddOrder(order1);
            //模拟收件人2
            order2 = new Order(new Receiver("456", "Amy", "胜利街街63号", "199487549"));
            order2.AddOrderItem(new OrderItem("qge", new Product("苹果", 0.5), 5));
            order2.AddOrderItem(new OrderItem("qoe", new Product("香蕉", 2.3), 8));
            order2.AddOrderItem(new OrderItem("qye", new Product("梨子", 1.2), 6));
            orderService.AddOrder(order2);
            ////模拟收件人3
            order3 = new Order(new Receiver("789", "Amy", "红安街街8号", "199456949"));
            order3.AddOrderItem(new OrderItem("zgc", new Product("苹果", 0.5), 5));
            order3.AddOrderItem(new OrderItem("zlc", new Product("香蕉", 2.3), 8));
            order3.AddOrderItem(new OrderItem("zfc", new Product("梨子", 1.2), 6));
            orderService.AddOrder(order3);
        }
        [TestMethod()]
        public void ExportTest()
        {
            orderService.Export();
        }

        [TestMethod()]
        public void ImportTest()
        {
            List<Order> orders = orderService.Import("D:\\VS_workplace\\homewor" +
                 "k5\\homework5\\orders.xml");
            foreach (Order o in orders)
                Console.WriteLine(o.ToString());

        }

        [TestMethod()]
        public void ExportToBinTest()
        {
            orderService.ExportToBin();
        }

        [TestMethod()]
        public void ImportFromBinTest()
        {
            List<Order> orders = orderService.ImportFromBin("D:\\VS_workplace\\homewor" +
                  "k5\\homework5\\Bin.temp");
            foreach (Order o in orders)
                Console.WriteLine(o.ToString());
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            OrderService os = new OrderService();
            Order order = new Order(new Receiver("923", "Jack", "长虹街33号", "195487859"));
            order.AddOrderItem(new OrderItem("asd", new Product("苹果", 0.5), 5));
            order.AddOrderItem(new OrderItem("ard", new Product("香蕉", 2.3), 8));
            order.AddOrderItem(new OrderItem("aso", new Product("梨子", 1.2), 6));
            Order order2 = new Order(new Receiver("923", "Jack", "长虹街33号", "195487859"));
            order2.AddOrderItem(new OrderItem("asd", new Product("苹果", 0.5), 5));
            order2.AddOrderItem(new OrderItem("ard", new Product("香蕉", 2.3), 8));
            order2.AddOrderItem(new OrderItem("aso", new Product("梨子", 1.2), 6));
            os.AddOrder(order);
            os.AddOrder(order2);
        }

        [TestMethod()]
        public void SearchOrderByIdTest()
        {
            Order order = orderService.SearchOrderById("923");
            Console.WriteLine(order.ToString());

        }

        [TestMethod()]
        public void SearchOrderByIdTest1()
        {
            Order order1 = orderService.SearchOrderById(null);
            Order order2 = orderService.SearchOrderById("48");//测试不存在此id时返回为null
            Assert.AreEqual(null, order1);
            Assert.AreEqual(null, order2);
        }

        [TestMethod()]
        public void SearchOrderByNameTest()
        {
            List<Order> list = orderService.SearchOrderByName("Amy");
            Order[] orders = list.ToArray();
            Array.ForEach(orders, order => order.ToString());
            list = orderService.SearchOrderByName("adwwfw");
            orders = list.ToArray();
            Assert.AreEqual(0, orders.Length);
            list = orderService.SearchOrderByName(null);
            orders = list.ToArray();
            Assert.AreEqual(0, orders.Length);

        }

       

        [TestMethod()]
        public void ModifyOrderAdrTest()
        {
            string newAdr = "珞珈街3号";
            bool f = orderService.ModifyOrderAdr("456", newAdr);
            Assert.IsTrue(f);
            Assert.AreEqual(newAdr, orderService.SearchOrderById("456").
                Receiver.ReceiverAddress);

        }

        [TestMethod()]
        public void GetOrderItemsTest()
        {
            List<Order> lo = orderService.SearchOrderByName("Amy");
            List<OrderItem> loi = orderService.GetOrderItems(lo);
            List<OrderItem> expected = new List<OrderItem>
            {
                new OrderItem("qge", new Product("苹果", 0.5), 5),
                new OrderItem("qoe", new Product("香蕉", 2.3), 8),
                new OrderItem("qye", new Product("梨子", 1.2), 6),
                new OrderItem("zgc", new Product("苹果", 0.5), 5),
                new OrderItem("zlc", new Product("香蕉", 2.3), 8),
                new OrderItem("zfc", new Product("梨子", 1.2), 6)
            };
            CollectionAssert.AreEqual(expected, loi);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            bool flag = orderService.RemoveOrder("789");
            foreach (Order o in orderService.Orders)
                Console.WriteLine(o.ToString());
            Assert.IsTrue(flag);
            bool flag2 = orderService.RemoveOrder("1549494");
            Assert.IsFalse(flag2);

        }

        [TestMethod()]
        public void SearchOrderItemByIdTest()
        {

            OrderItem items = orderService.SearchOrderItemById("ard");
            OrderItem i = new OrderItem("ard", new Product("香蕉", 2.3), 8);
            Assert.AreEqual(i, items);

        }

        [TestMethod()]
        public void ModiBuyNumTest()
        {
            int newBuyNum = 38;
            orderService.ModiBuyNum("789", "苹果", newBuyNum);
            Assert.AreEqual(38,orderService.SearchOrderItemByProductName("789", "苹果")
                .BuyNum);
        }
            

        [TestMethod()]
        public void RemoveItemTest()
        {
            Assert.IsTrue(orderService.RemoveItem("789", "梨子"));
        }

        [TestMethod()]
        public void OrderSortTest()
        {
            orderService.OrderSort();
            List<Order> orders = new List<Order>()
            {
                order2,order3,order1
            };
            CollectionAssert.AreEqual(orders, orderService.Orders);
            
        }
    }
}