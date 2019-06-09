using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNB.Supermarket.Entities.ViewModels;
using DNB.Supermarket.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace DNB.Supermarket.WebUI.ViewComponents
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private readonly ICartSessionService _cartSessionService;

        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel()
            {
                Cart = _cartSessionService.GetCart()
            };

            return View(model);
        }
    }
}
