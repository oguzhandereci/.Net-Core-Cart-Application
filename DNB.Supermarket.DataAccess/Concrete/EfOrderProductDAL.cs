using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DNB.Supermarket.Core.DataAccess.EntityFramework;
using DNB.Supermarket.DataAccess.Abstract;
using DNB.Supermarket.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DNB.Supermarket.DataAccess.Concrete
{
    public class EfOrderProductDAL:EfEntityRepoBase<OrderProduct,MyContext>,IOrderProductDAL
    {
        public override List<OrderProduct> GetList(Expression<Func<OrderProduct, bool>> filter = null)
        {
            using (var myContext = new MyContext())
            {
                return filter == null
                    ? myContext.Set<OrderProduct>().Include(x => x.Product).ToList()
                    : myContext.Set<OrderProduct>().Include(x => x.Order).Where(filter).ToList();
            }
        }
    }
}
