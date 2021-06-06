using System;
using System.Collections.Generic;

namespace Shops
{
    class Program
    {
        static void Main()
        {

            //Task 1
            Shop P5 = new Shop(123, "Пятерочка", "Санкт-Петербург, Вяземский переулок 5/7");
            Shop Mag = new Shop(124, "Магнит", "Иваново, Ж/Д Вокзал");
            Shop Pere = new Shop(552, "Перекресток", "Санкт-Петербург, ул. Пушкина, д. Колотушкина");

            //Task 2
            Product potato = new Product(1, "Картошка");
            Product pasta = new Product(2, "Макароны");
            Product cheese = new Product(3, "Сыр");
            Product notebook = new Product(4, "Ноутбук");
            Product vodka = new Product(5, "Водка");
            Product chokolate = new Product(6, "Шоколад");
            Product beer = new Product(7, "Пиво 1.5л");
            Product coffee = new Product(8, "Кофеёк");
            Product camera = new Product(9, "Видеокамера");
            Product bmw = new Product(10, "BMW");

            //Task 3
            P5.AddProducts(new ItemOfProducts(potato, 10000, 5));
            P5.AddProducts(new ItemOfProducts(pasta, 10000, 20));
            P5.AddProducts(new ItemOfProducts(cheese, 5000, 38));                           //Дешёвый сыр
            P5.AddProducts(new ItemOfProducts(beer, 900, 120));
            P5.AddProducts(new ItemOfProducts(chokolate, 1000, 33));
            P5.AddProducts(new ItemOfProducts(vodka, 300, 150));
            P5.AddProducts(new ItemOfProducts(camera, 30, 1200));

            Mag.AddProducts(new ItemOfProducts(potato, 10000, 5));
            Mag.AddProducts(new ItemOfProducts(pasta, 10000, 15));                         // Дешёвые макароны
            Mag.AddProducts(new ItemOfProducts(cheese, 5000, 46));
            Mag.AddProducts(new ItemOfProducts(beer, 900, 90));
            Mag.AddProducts(new ItemOfProducts(chokolate, 1000, 42));
            Mag.AddProducts(new ItemOfProducts(vodka, 300, 148));
            Mag.AddProducts(new ItemOfProducts(camera, 30, 1500));
            Mag.AddProducts(new ItemOfProducts(notebook, 30, 100000));

            Pere.AddProducts(new ItemOfProducts(chokolate, 500, 32));
            Pere.AddProducts(new ItemOfProducts(potato, 10300, 194));
            Pere.AddProducts(new ItemOfProducts(coffee, 1000, 192));
            Pere.AddProducts(new ItemOfProducts(notebook, 30, 99999));
            Pere.AddProducts(new ItemOfProducts(bmw, 100, 5));

            //Help
            Console.WriteLine(P5.ToString());
            Console.WriteLine(Mag.ToString());
            Console.WriteLine(Pere.ToString());

            ShopManager manager = new ShopManager();
            manager.AddShop(P5);
            manager.AddShop(Mag);
            manager.AddShop(Pere);
            //Help

            //Task 4
            Console.WriteLine(manager.GetMinimumPrice(pasta).GetName());
            Console.WriteLine(manager.GetMinimumPrice(cheese).GetName());
            Console.WriteLine(manager.GetMinimumPrice(notebook).GetName());

            //Task 5
            Console.WriteLine("\n\nВведите число:");
            double money = double.Parse(Console.ReadLine());
            Console.WriteLine("На " + money + "руб. в Магните можно купить:");
            Console.WriteLine(manager.GetListOfProductsOnPrice(Mag.GetID(), money));

            //Task 6
            Console.WriteLine("\n\nМожно ли в Перекрестке купить 5 Видеокамер, 3кг картошку и ноутбук?");
            Pere.AddProducts(new ItemOfProducts(camera, 30, 1500));
            List<KeyValuePair<Product, uint>> req = new List<KeyValuePair<Product, uint>>
            {
                new KeyValuePair<Product, uint>(camera, 5),
                new KeyValuePair<Product, uint>(potato, 3),
                new KeyValuePair<Product, uint>(notebook, 1)
            };
            Console.WriteLine(manager.BuyListOfProducts(Pere.GetID(), req));


            //Task 7
            Console.WriteLine("\n\nСамая дешёвая таска 6\n");
            Shop sh = manager.GetMinimumPrice(req);
            Console.WriteLine(sh.GetName());
            Console.WriteLine(sh.GetListOfProducts(req));

            Console.ReadKey();
        }
    }
}
