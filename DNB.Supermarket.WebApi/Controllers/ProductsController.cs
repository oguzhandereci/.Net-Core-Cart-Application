using DNB.Supermarket.Business.Abstract;
using DNB.Supermarket.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DNB.Supermarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var productList = _productService.GetAll();
            return Json(productList);
        }

        [HttpGet("{id}")]
        public JsonResult GetById(Guid id)
        {
            var product = _productService.GetAll().FirstOrDefault(x => x.ProductId == id);
            return Json(product);
        }



        [HttpPost]
        public ActionResult<Product> AddProduct(Product prd)
        {
            _productService.Add(prd);
            return CreatedAtAction(nameof(GetById), new { id = prd.ProductId }, prd);
        }
    }
}