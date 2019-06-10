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
    public class EfOrderDAL:EfEntityRepoBase<Order,MyContext>, IOrderDAL
    {
        public override List<Order> GetList(Expression<Func<Order, bool>> filter = null)
        {
            using (var myContext = new MyContext())
            {
                return filter == null
                    ? myContext.Set<Order>().Include(x=>x.OrderProducts).ToList()
                    : myContext.Set<Order>().Include(x => x.OrderProducts).Where(filter).ToList();
            }
        }
    }
}
