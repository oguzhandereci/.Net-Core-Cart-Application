using System;
using System.Collections.Generic;
using System.Text;
using DNB.Supermarket.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DNB.Supermarket.DataAccess.Concrete
{
    public class MyIdentityContext:IdentityDbContext<AppUser,AppRole,Guid>  
    {
        public MyIdentityContext(DbContextOptions options) : base(options)
        {
        }
    }
}
