using System;
using System.Collections.Generic;
using System.Text;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Product prd);
        void RemoveFromCart(Cart cart, Guid prdId);
        List<CartLine> List(Cart cart);
    }
}
