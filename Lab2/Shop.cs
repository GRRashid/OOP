using Shops.Exception;
using System;
using System.Collections.Generic;

namespace Shops
{
    class Shop
    {
        private Check Products = new Check();
        private readonly uint _id;
        private string _name;
        private string _address;
        public Shop(uint id, string name, string address)
        {
            _id = id;
            _name = name;
            _address = address;
        }

        public uint GetID()
        {
            return _id;
        }
        public string GetName()
        {
            return _name;
        }
        public string GetAddress()
        {
            return _address;
        }



        public void AddProducts(ItemOfProducts product)
        {
            AddProducts(new List<ItemOfProducts> { product });
        }
        public void AddProducts(List<ItemOfProducts> products)
        {
            foreach (var addproduct in products)
            {
                Products.Add(addproduct);
            }
        }
       
        public void RemoveProducts(uint product)
        {
            Products.Remove(product);
        }
        public void RemoveProducts(List<uint> products)
        {
            foreach (var prod in products)
            {
                RemoveProducts(prod);
            }
        }



        public ItemOfProducts GetProduct(uint product)
        {
            return Products[product];
        }

        public bool HasProduct(Product product)
        {
            if (Products.ContainsKey(product._id))
                return true;
            return false;
        }

        public List<ItemOfProducts> GetList()
        {
            return Products.GetProducts();
        }

        //Task 5
        public Check GetListOfProductsOnPrice(double price)
        {
            List<ItemOfProducts> result = new List<ItemOfProducts>();
            foreach (var prod in Products.GetProducts())
            {
                if (Convert.ToUInt32(Math.Truncate(price / prod.GetPrice())) > 0)
                {
                    result.Add(prod);
                    result[result.Count - 1].SetProductAmount(Convert.ToUInt32(Math.Truncate(price / prod.GetPrice())));
                }
            }
            return new Check(result);
        }

        public Check GetListOfProducts(List<KeyValuePair<Product, uint>> products)
        {
            List<ItemOfProducts> res = new List<ItemOfProducts>();
            foreach (var pr in products)
            {
            ItemOfProducts help = new ItemOfProducts(pr.Key, 0, 0);
            ItemOfProducts price = Products[pr.Key._id];
            if (price.GetAmount() < pr.Value)
                throw new NotSuchProduct(pr.Key._id);
            help.SetProductPrice(price.GetPrice());
            help.SetProductAmount(pr.Value);
            res.Add(help);
            }
            return new Check(res);
        }

        public Check BuyListOfProducts(List<KeyValuePair<Product, uint>> products)
        {
            List<ItemOfProducts> res = new List<ItemOfProducts>();

            GetListOfProducts(products);

            foreach (var pr in products)
            {
                ItemOfProducts help = new ItemOfProducts(pr.Key, 0, 0);
                ItemOfProducts price = Products[pr.Key._id];
                if (price.GetAmount() < pr.Value)
                    throw new NotSuchProduct(pr.Key._id);
                help.SetProductPrice(price.GetPrice());
                price.SetProductAmount(price.GetAmount() - pr.Value); // Отличие в этой строчке
                help.SetProductAmount(pr.Value);
                res.Add(help);
            }
            return new Check(res);
        }




        public override string ToString()
        {
            string result = _name + "\nАдрес:" + _address + "\n";
            result += Products.ToString();
            return result;
        }
    }
}
