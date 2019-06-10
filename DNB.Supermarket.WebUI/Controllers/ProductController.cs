using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNB.Supermarket.Business.Abstract;
using DNB.Supermarket.Entities.Entities;
using DNB.Supermarket.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNB.Supermarket.WebUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products
            };
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    ProductName = model.ProductName,
                    Category = model.Category,
                    SellPrice = model.SellPrice,
                    UnitsInStock = model.UnitsInStock
                };

                _productService.Add(product);
                TempData["message"] = "Ürün ekleme işlemi başarılı";
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError(String.Empty, "Ürün ekleme işlemi sırasında bir hata oluştu.");
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateProduct(Guid id)
        {
            var prd = _productService.GetAll().FirstOrDefault(x => x.ProductId == id);
            ProductViewModel model = new ProductViewModel()
            {
                ProductId = prd.ProductId,
                ProductName = prd.ProductName,
                Category = prd.Category,
                UnitsInStock = prd.UnitsInStock,
                SellPrice = prd.SellPrice
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(String.Empty, "Güncelleme işlemi sırasında bir hata oluştu.");
                return View(model);
            }

            var prd = _productService.GetAll().FirstOrDefault(x => x.ProductId == model.ProductId);
            prd.ProductName = model.ProductName;
            prd.Category = model.Category;
            prd.SellPrice = model.SellPrice;
            prd.UnitsInStock = model.UnitsInStock;

            _productService.Update(prd);
            TempData["message"] = "Ürün güncelleme işlemi başarılı";
            return RedirectToAction("Index", "Product");
        }
    }
}