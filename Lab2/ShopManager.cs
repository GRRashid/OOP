using Shops.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops
{
    class ShopManager
    {
        private Dictionary<uint, Shop> shops;

        public ShopManager()
        {
            shops = new Dictionary<uint, Shop>();
        }

        //Task1
        public void AddShop(Shop sh)
        {
            shops[sh.GetID()] = sh;
        }
        //Task2-3
        public void AddProducts(uint shopId, ItemOfProducts item)
        {
            if (!shops.ContainsKey(shopId))
                throw new NotSuchShop(shopId);
        }

        public void AddProducts(uint shopId, List<ItemOfProducts> items)
        {
            foreach (var item in items)
            {
                AddProducts(shopId, item);
            }
        }


        //Task 4
        public Shop GetMinimumPrice(Product pr)
        {
            Shop res = GetMinimumPrice(new List<KeyValuePair<Product, uint>> { new KeyValuePair<Product, uint>(pr, 1) });
            return res;
        }

        //Task 5
        public Check GetListOfProductsOnPrice(uint shopId, double price)
        {
            if (!shops.ContainsKey(shopId))
                throw new NotSuchShop(shopId);
            return shops[shopId].GetListOfProductsOnPrice(price);
        }

        //Task 6
        public Check BuyListOfProducts(uint shopId, List<KeyValuePair<Product, uint>> products)
        {
            if (!shops.ContainsKey(shopId))
                throw new NotSuchShop(shopId);
            return shops[shopId].BuyListOfProducts(products);
        }

        //Task 7
        public Shop GetMinimumPrice(List<KeyValuePair<Product, uint>> products)
        {
            Check find = new Check();
            Shop res = new Shop(uint.MaxValue, "", "");
            foreach (var i in shops)
            {
                bool flag = true;
                foreach (var pr in products)
                {
                    if (!i.Value.HasProduct(pr.Key))
                        flag = false;
                }

                if (flag)
                {
                    Check help = i.Value.GetListOfProducts(products);
                    if (find.Total() == 0 || find.Total() > help.Total())
                    {
                        find = help;
                        res = i.Value;
                    }
                }
            }
            if (res.GetID() == uint.MaxValue)
                throw new NotSuchShops();
            return res;
        }

    }
}
