using System;
using System.Collections.Generic;
using System.Text;

namespace DNB.Supermarket.Entities.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
