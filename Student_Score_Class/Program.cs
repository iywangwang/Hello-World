using System;

namespace Student_Score_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WarpFactory warpFactory = new WarpFactory();
            ProductFactory productFactory = new ProductFactory();

            Func<Product> fun1 = new Func<Product> (productFactory.MakePizza);
            Func<Product> fun2 = new Func<Product> (productFactory.MakeToyCar);

            Logger logger = new Logger();
            Action<Product> log = new Action<Product>(logger.log);

            Box box1 = warpFactory.WarpProduct(fun1, log);
            Box box2 = warpFactory.WarpProduct(fun2, log);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }

        class Logger
        {
            public void log(Product product)
            {
                Console.WriteLine("Product '{0}' created at {1}. Price id {2}.", product.Name, DateTime.UtcNow, product.Pice);
            }
        }

        class Product
        {
            public string Name { get; set; }
            public int Pice { get; set; }
        }

        class Box
        {
            public Product Product { get; set; }
        }

        class WarpFactory
        {
            public Box WarpProduct(Func<Product> getProduct, Action<Product> logCallback)
            { 
                Box box = new Box();
                Product product = getProduct.Invoke();
                if (product.Pice >= 50)
                { 
                    logCallback(product);
                }

                box.Product = product;
                return box;
            }
        }

        class ProductFactory
        {
            public Product MakePizza()
            {
                Product product = new Product();
                product.Name = "Pizza";
                product.Pice = 33;
                return product;
            }

            public Product MakeToyCar()
            {
                Product product = new Product();
                product.Name = "ToyCar";
                product.Pice = 99;
                return product;
            }
        }
    }
}
