using System;
using System.Collections.Generic;
using System.Text;
using DNB.Supermarket.Entities.Entities;

namespace DNB.Supermarket.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}
