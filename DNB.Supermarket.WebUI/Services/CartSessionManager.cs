using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNB.Supermarket.Entities.Entities;
using DNB.Supermarket.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace DNB.Supermarket.WebUI.Services
{
    public class CartSessionManager:ICartSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart",cart);
        }

        public Cart GetCart()
        {
            var cartContent = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartContent != null) return cartContent;
            _httpContextAccessor.HttpContext.Session.SetObject("cart",new Cart());
            cartContent = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");

            return cartContent;
        }
    }
}
