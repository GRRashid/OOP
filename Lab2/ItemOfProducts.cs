using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops
{
    class ItemOfProducts
    {
        private readonly Product _product;
        private uint _amount;
        private double _price;
        private const string val = "шт.";
        private const string currentcy = "руб.";
        public ItemOfProducts(Product product, uint amount, double price)
        {
            _product = product;
            _amount = amount;
            _price = price;
        }
        public Product GetProduct()
        {
            return _product;
        }
        public uint GetId()
        {
            return _product._id;
        }
        public void SetProductPrice(double price)
        {
            _price = price;
        }
        public void SetProductAmount(uint amount)
        {
            _amount = amount;
        }
        public uint GetAmount()
        {
            return _amount;
        }
        public double GetPrice()
        {
            return _price;
        }
        public double CalcPrice()
        {
            return _amount * _price;
        }
        public override string ToString()
        {
            return _product.ToString() + ": " + _amount + val + "*" + _price + currentcy +" = " + CalcPrice();
        }
    }
}
