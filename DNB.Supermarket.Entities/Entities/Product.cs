using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DNB.Supermarket.Core.Entities;

namespace DNB.Supermarket.Entities.Entities
{
    [Table("Products")]
    public class Product : IEntity
    {
        [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public string ProductName { get; set; }
        public string Category { get; set; }
        public short UnitsInStock { get; set; }
        public decimal SellPrice { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();

    }
}
