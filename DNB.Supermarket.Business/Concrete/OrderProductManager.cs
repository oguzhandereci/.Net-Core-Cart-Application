using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DNB.Supermarket.Business.Abstract;
using DNB.Supermarket.DataAccess.Abstract;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.Business.Concrete
{
    public class OrderProductManager:IOrderProductService
    {
        private readonly IOrderProductDAL _orderProductDal;

        public OrderProductManager(IOrderProductDAL orderProductDal)
        {
            _orderProductDal = orderProductDal;
        }

        public List<OrderProduct> GetAll(Expression<Func<OrderProduct, bool>> filter = null)
        {
            return _orderProductDal.GetList(filter);
        }

        public OrderProduct GetById(Guid orderId, Guid prdId)
        {
            return _orderProductDal.Get(x => x.OrderId == orderId & x.ProductId == prdId);
        }

        public void Add(OrderProduct orderProduct)
        {
            _orderProductDal.Insert(orderProduct);
        }

        public void Update(OrderProduct orderProduct)
        {
            _orderProductDal.Update(orderProduct);
        }

        public void Delete(Guid orderId, Guid prdId)
        {
            var orderItem = _orderProductDal.Get(x => x.OrderId == orderId & x.ProductId == prdId);
            if (orderItem != null)
                _orderProductDal.Delete(orderItem);
        }
    }
}
