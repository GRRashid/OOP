using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops
{
    class Product
    {
        public readonly uint _id;
        public string _name;
        public Product(uint id, string name)
        {
            _id = id;
            _name = name;
        }

        public override string ToString()
        {
            return "[" + _id + "]" + _name;
        }
    }
}
