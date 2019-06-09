using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DNB.Supermarket.Core.Entities;

namespace DNB.Supermarket.Core.DataAccess
{
    public interface IEntityRepo<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
