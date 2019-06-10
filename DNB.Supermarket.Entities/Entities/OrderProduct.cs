using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DNB.Supermarket.Core.Entities;

namespace DNB.Supermarket.Entities.Entities
{
    public class OrderProduct:IEntity
    {
        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public int SellingQuantity { get; set; }
    }
}
