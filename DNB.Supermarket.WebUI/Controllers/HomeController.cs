using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DNB.Supermarket.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using DNB.Supermarket.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace DNB.Supermarket.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Product");
        }
    }
}
