using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DNB.Supermarket.Entities.ViewModels
{
    public class ProductViewModel
    {
        [DisplayName("Ürün ID")]
        public Guid? ProductId { get; set; }
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }
        [DisplayName("Ürün Türü")]
        public string Category { get; set; }
        [DisplayName("Stok Sayısı")]
        public short UnitsInStock { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public decimal SellPrice { get; set; }
    }
}
