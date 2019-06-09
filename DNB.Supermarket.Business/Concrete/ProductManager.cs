using System;
using System.Collections.Generic;
using System.Text;
using DNB.Supermarket.Business.Abstract;
using DNB.Supermarket.DataAccess.Abstract;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private readonly IProductDAL _productDal;

        public ProductManager(IProductDAL productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(Guid id)
        {
            return _productDal.Get(x=>x.ProductId == id);
        }

        public void Add(Product product)
        {
            _productDal.Insert(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(Guid id)
        {
            var prd = _productDal.Get(x => x.ProductId == id);
            _productDal.Delete(prd);    
        }
    }
}
