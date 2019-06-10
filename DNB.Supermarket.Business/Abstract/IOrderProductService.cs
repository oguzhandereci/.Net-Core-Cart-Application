using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.Business.Abstract
{
    public interface IOrderProductService
    {
        List<OrderProduct> GetAll(Expression<Func<OrderProduct, bool>> filter = null);
        OrderProduct GetById(Guid orderId, Guid prdId);
        void Add(OrderProduct orderProduct);
        void Update(OrderProduct orderProduct);
        void Delete(Guid orderId,Guid prdId);
    }
}
