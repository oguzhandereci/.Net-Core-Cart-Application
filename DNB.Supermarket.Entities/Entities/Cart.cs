using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNB.Supermarket.Entities.Entities
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }

        public decimal Total
        {
            get { return CartLines.Sum(x => x.Product.SellPrice * x.Quantity);}
        }
    }
}
