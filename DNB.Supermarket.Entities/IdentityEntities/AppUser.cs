using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DNB.Supermarket.Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace DNB.Supermarket.Entities.IdentityEntities
{
    public class AppUser:IdentityUser<Guid>
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(60)]
        [Required]
        public string Surname { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}
