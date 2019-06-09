using System;
using System.Collections.Generic;
using System.Text;
using DNB.Supermarket.Core.DataAccess.EntityFramework;
using DNB.Supermarket.DataAccess.Abstract;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.DataAccess.Concrete
{
    public class EfProductDAL:EfEntityRepoBase<Product,MyContext>,IProductDAL
    {   
    }
}
