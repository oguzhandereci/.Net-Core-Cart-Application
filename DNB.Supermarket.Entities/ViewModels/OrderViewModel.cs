using System;
using System.Collections.Generic;
using System.Text;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.Entities.ViewModels
{
    public class OrderViewModel
    {
        public List<OrderProduct> OrderProducts { get; set; }
        //public List<Product> Products { get; set; }
    }
}
