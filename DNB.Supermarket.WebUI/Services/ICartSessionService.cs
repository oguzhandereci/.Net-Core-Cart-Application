using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.WebUI.Services
{
    public interface ICartSessionService
    {
        void SetCart(Cart cart);
        Cart GetCart();
    }
}
