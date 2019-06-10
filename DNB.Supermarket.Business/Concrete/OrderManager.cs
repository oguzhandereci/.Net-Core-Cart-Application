using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DNB.Supermarket.Business.Abstract;
using DNB.Supermarket.DataAccess.Abstract;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.Business.Concrete
{
    public class OrderManager:IOrderService
    {
        private readonly IOrderDAL _orderDal;

        public OrderManager(IOrderDAL orderDal)
        {
            _orderDal = orderDal;
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            return _orderDal.GetList(filter);
        }

        public Order GetById(Guid id)
        {
            return _orderDal.Get(x => x.OrderId == id);
        }

        public void Add(Order order)
        {
            _orderDal.Insert(order);
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }

        public void Delete(Guid id)
        {
            var order = _orderDal.Get(x => x.OrderId == id);
            _orderDal.Delete(order);
        }
    }
}
