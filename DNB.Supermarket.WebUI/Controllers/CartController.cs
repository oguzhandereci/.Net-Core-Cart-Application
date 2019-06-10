using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DNB.Supermarket.Business.Abstract;
using DNB.Supermarket.Entities.Entities;
using DNB.Supermarket.Entities.Enums;
using DNB.Supermarket.Entities.ViewModels;
using DNB.Supermarket.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DNB.Supermarket.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartSessionService _cartSessionService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderProductService _orderProductService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected static int Stok;

        public CartController(IProductService productService, ICartSessionService cartSessionService, ICartService cartService, IOrderService orderService, IHttpContextAccessor httpContextAccessor, IOrderProductService orderProductService)
        {
            _productService = productService;
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
            _orderProductService = orderProductService;
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
            Stok = product.UnitsInStock;
            //_productService.Update(product);
            _cartSessionService.SetCart(cart);

            TempData["message"] = $"{product.ProductName} isimli ürün başarıyla sepetinize eklenmiştir.";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ViewCart()
        {
            List<SelectListItem> paymentTypes = new List<SelectListItem>(); 
            var cart = _cartSessionService.GetCart();
            var model = new PurchaseCartSummaryViewModel()
            {
                CartSummaryViewModel = new CartSummaryViewModel()
                {
                    Cart = cart
                }
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
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //var orderContent = _orderService.GetAll(x=>x.UserId == userId);
            
            var order = new Order()
            {
                PaymentTypes = model.PaymentTypes,
                TotalPrice = cart.Total,
                UserId = userId
            };

            _orderService.Add(order);

            foreach (var item in cart.CartLines)
            {
                var prd = item.Product;
                var orderItem = new OrderProduct()
                {
                    ProductId = prd.ProductId,
                    OrderId = order.OrderId,
                    SellingQuantity = item.Quantity
                };
                _orderProductService.Add(orderItem);
                //prd.UnitsInStock -= Convert.ToInt16(item.Quantity);
                _productService.Update(prd);
            }

            _cartSessionService.SetCart(null);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult PurchasedItems()
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //var userOrders = _orderService.GetAll(x => x.UserId == userId);
            var orderItems = _orderProductService.GetAll(x => x.Order.UserId == userId);
            //var boughtProducts = new List<Product>();
            foreach (var orderProduct in orderItems)
            {
                var prd = _productService.GetAll().FirstOrDefault(x => x.ProductId == orderProduct.ProductId);
                //boughtProducts.Add(prd);
                orderProduct.Product = prd;
            }
            var model = new OrderViewModel()
            {
                OrderProducts = orderItems,
                //Products = boughtProducts
            };
            return View(model);
        }
    }
}