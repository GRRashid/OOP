using Shops.Exception;
using System.Collections.Generic;

namespace Shops
{
    class Check
    {
        private Dictionary<uint, ItemOfProducts> list;
        public Check()
        {
            list = new Dictionary<uint, ItemOfProducts>();
        }

        public Check(List<ItemOfProducts> products)
        {
            list = new Dictionary<uint, ItemOfProducts>();
            foreach (var i in products)
            {
                list.Add(i.GetId(), i);
            }
        }



        public ItemOfProducts this[uint n]
        {
            get => GetProduct(n);
            set => list[n] = value;
        }
        public ItemOfProducts GetProduct(uint product)
        {
            if (!list.ContainsKey(product))
                throw new NotSuchProduct(product);
            return list[product];
        }


        public List<uint> GetIDs()
        {
            List<uint> res = new List<uint>();
            foreach (var key in list.Keys)
            {
                res.Add(key);
            }
            return res;
        }
        public List<ItemOfProducts> GetProducts()
        {
            List<ItemOfProducts> res = new List<ItemOfProducts>();
            foreach (var key in list.Values)
            {
                res.Add(key);
            }
            return res;
        }



        public bool ContainsKey(uint productId)
        {
            return list.ContainsKey(productId);
        }

        public void Add(ItemOfProducts product)
        {
            list.Add(product.GetId(), product);
        }

        public void Remove(uint productId)
        {
            if (!list.ContainsKey(productId))
                throw new NotSuchProduct(productId);
            list.Remove(productId);
        }


        public double Total()
        {
            double sum = 0;
            foreach (var pr in list)
            {
                sum += pr.Value.CalcPrice();
            }
            return sum;
        }


        public override string ToString()
        {
            string res = "Чек\n----------------------------------\n";
            double sum = 0;
            foreach (var pr in list)
            {
                res += pr.Value.ToString() + "\n";
                sum += pr.Value.CalcPrice();
            }
            res += "----------------------------------\n";
            res += "Total: " + sum + "\n";
            return res;
        }
    }
}
