using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DNB.Supermarket.Core.Entities;
using DNB.Supermarket.Entities.Enums;
using DNB.Supermarket.Entities.IdentityEntities;

namespace DNB.Supermarket.Entities.Entities
{
    [Table("Orders")]
    public class Order:IEntity
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        [DisplayName("Toplam Tutar:")]
        public decimal TotalPrice { get; set; }

        [DisplayName("Ödeme Türü:")]
        public PaymentTypes PaymentTypes { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
