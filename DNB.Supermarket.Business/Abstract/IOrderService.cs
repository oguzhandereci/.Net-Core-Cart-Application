﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll(Expression<Func<Order, bool>> filter = null);
        Order GetById(Guid id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Guid id);
    }
}
