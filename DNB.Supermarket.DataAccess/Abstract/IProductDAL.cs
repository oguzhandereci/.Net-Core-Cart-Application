using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using DNB.Supermarket.Core.DataAccess;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.DataAccess.Abstract
{
    public interface IProductDAL:IEntityRepo<Product>
    {
    }
}
    