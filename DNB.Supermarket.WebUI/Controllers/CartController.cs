using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNB.Supermarket.Business.Abstract;
using DNB.Supermarket.Entities.Entities;
using DNB.Supermarket.Entities.ViewModels;
using DNB.Supermarket.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DNB.Supermarket.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartSessionService _cartSessionService;
        private readonly IProductService _productService;

        public CartController(IProductService productService, ICartSessionService cartSessionService, ICartService cartService)
        {
            _productService = productService;
            _cartSessionService = cartSessionService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(Guid prdId)
        {
            var product = _productService.GetById(prdId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart,product);
            _cartSessionService.SetCart(cart);

            TempData["message"] = $"{product.ProductName} isimli ürün başarıyla sepetinize eklenmiştir.";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ViewCart()
        {
            var cart = _cartSessionService.GetCart();
            var model = new CartSummaryViewModel()
            {
                Cart = cart
            };
            return View(model);
        }

        public IActionResult RemoveFromCart(Guid prdId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart,prdId);
            _cartSessionService.SetCart(cart);

            return RedirectToAction("ViewCart", "Cart");
        }

        [HttpPost]
        public IActionResult Purchase(PurchaseViewModel model)
        {
            var cart = _cartSessionService.GetCart();

            return RedirectToAction("Index", "Home");
        }
    }
}