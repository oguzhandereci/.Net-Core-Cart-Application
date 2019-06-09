using System;
using System.Collections.Generic;
using System.Text;
using DNB.Supermarket.Entities.Entities;
using DNB.Supermarket.Entities.Enums;

namespace DNB.Supermarket.Entities.ViewModels
{
    public class PurchaseViewModel
    {
        public Cart Cart { get; set; }
        public PaymentTypes PaymentTypes { get; set; }
    }
}
