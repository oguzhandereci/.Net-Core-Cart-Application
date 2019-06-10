using System;
using System.Collections.Generic;
using System.Text;

namespace DNB.Supermarket.Entities.ViewModels
{
    public class PurchaseCartSummaryViewModel
    {
        public CartSummaryViewModel CartSummaryViewModel { get; set; }
        public PurchaseViewModel PurchaseViewModel { get; set; }
    }
}
