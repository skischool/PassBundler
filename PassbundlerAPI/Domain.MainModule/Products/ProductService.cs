using System;
using System.Collections.Generic;
using System.Linq;
using Domain.MainModule.Bundles;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Products
{
    public class ProductService : IProductService
    {
    	readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product item)
        {
            return _productRepository.Add(item);
        }

        public Product Update(Product item)
        {
            return _productRepository.Update(item);
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> List(Product item)
        {
            return _productRepository.List(item);
        }
    }
}
