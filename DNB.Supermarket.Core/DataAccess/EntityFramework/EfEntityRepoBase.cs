using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DNB.Supermarket.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DNB.Supermarket.Core.DataAccess.EntityFramework
{
    public abstract class EfEntityRepoBase<TEntity, TContext> : IEntityRepo<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var myContext = new TContext())
            {
                return myContext.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var myContext = new TContext())
            {
                return filter == null
                    ? myContext.Set<TEntity>().ToList()
                    : myContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            using (var myContext = new TContext())
            {
                var addedEntity = myContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                myContext.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var myContext = new TContext())
            {
                var updatedEntity = myContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                myContext.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (var myContext = new TContext())
            {
                var deletedEntity = myContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                myContext.SaveChanges();
            }
        }

    }
}
