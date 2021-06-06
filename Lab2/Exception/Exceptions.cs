using System;

namespace Shops.Exception
{
    class InvalidProduct : FormatException
    {
        public InvalidProduct(Product pr)
            : base("Invalid Product " + pr.ToString())
        {}
    }

    class NotSuchProduct : FormatException
    {
        public NotSuchProduct(uint pr)

            : base("Not such product " + pr)
        { }
    }

    class NotSuchShop : FormatException
    {
        public NotSuchShop(uint shopId)

            : base("Not such shop with id "+ shopId +"!")
        { }
    }

    class NotSuchShops : FormatException
    {
        public NotSuchShops()

            : base("Not such shops!")
        { }
    }
}
