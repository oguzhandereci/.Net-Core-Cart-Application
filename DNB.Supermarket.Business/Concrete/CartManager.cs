using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DNB.Supermarket.Business.Abstract;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.Business.Concrete
{
    public class CartManager:ICartService
    {
        public void AddToCart(Cart cart, Product prd)
        {
            var cartContext = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == prd.ProductId);
            if (cartContext != null)
            {
                cartContext.Quantity++;
                return;
            }

            cartContext = new CartLine()
            {
                Product = prd,
                Quantity = 1
            };
            cart.CartLines.Add(cartContext);
            prd.UnitsInStock -= Convert.ToInt16(cartContext.Quantity);
        }

        public void RemoveFromCart(Cart cart, Guid prdId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(x => x.Product.ProductId == prdId));
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }
    }
}
