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

            Box box1 = warpFactory.WarpProduct(fun1);
            Box box2 = warpFactory.WarpProduct(fun2);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }

        class Product
        {
            public string Name { get; set; }
        }

        class Box
        {
            public Product Product { get; set; }
        }

        class WarpFactory
        {
            public Box WarpProduct(Func<Product> getProduct)
            { 
                Box box = new Box();
                Product product = getProduct.Invoke();

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
                return product;
            }

            public Product MakeToyCar()
            {
                Product product = new Product();
                product.Name = "ToyCar";
                return product;
            }
        }
    }
}
