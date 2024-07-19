using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace CustomerAndWaiter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter  waiter = new Waiter();
            customer.Order += waiter.Action;

            customer.Action();
            customer.PayTheBill();
        }
    }

    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string DishSize { get; set; }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    public class Customer   //顾客
    {
        public event OrderEventHandler Order;
        public double Bill { get; set; }        //账单

        public void PayTheBill()        //结账
        {
            Console.WriteLine("Bill is ${0}", this.Bill);
        }

        public void WalkIn()
        { 
            Console.WriteLine("Waik to restaurant");
        }

        public void SitDown()
        { 
            Console.WriteLine("Sit Down");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            { 
                Console.WriteLine("Thinking {0}s.....", i);
                Thread.Sleep(1000);
            }

            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs() { DishName = "剁椒鱼头", DishSize = "small"};

                this.Order.Invoke(this, e);
            }
        }

        public void Action()
        { 
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }

    public class Waiter
    {
        public void Action(Customer customer, OrderEventArgs e)     //处理事件
        {
            Console.WriteLine("I will server you the dish {0}", e.DishName);
            double price = 77;

            switch (e.DishSize)
            {
                case "small":
                    price *= 0.75;
                    break;
                case "large":
                    price *= 1.25;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }
    }
}
