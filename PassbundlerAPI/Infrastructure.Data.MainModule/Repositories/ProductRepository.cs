using System;
using System.Collections.Generic;
using System.Linq;
using Domain.MainModule.Bundles;
using Infrastructure.Data.MainModule.Models;
using Infrastructure.Data.MainModule.Contexts;
using Domain.Core;
using Domain.MainModule.Entities;
using Domain.MainModule.Products;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PassBundlerContext _passBundlerContext;

		public ProductRepository()
        {
            _passBundlerContext = new PassBundlerContext();
        }

        public Product Add(Product item)
        {
            var addedItem = _passBundlerContext.Products.Add(item);

            _passBundlerContext.SaveChanges();

            return addedItem;
        }

        public Product Update(Product item)
        {
            var itemToUpdate = _passBundlerContext.Products.FirstOrDefault(b => b.Id == item.Id);

            itemToUpdate = item;

            _passBundlerContext.SaveChanges();

            return itemToUpdate;
        }

        public Product Delete(int id)
        {
            var itemToDelete = _passBundlerContext.Products.FirstOrDefault(b => b.Id == id);

            var deletedItem = _passBundlerContext.Products.Remove(itemToDelete);

            _passBundlerContext.SaveChanges();

            return deletedItem;
        }

        public IEnumerable<Product> List(Product item)
        {
            var bundle = _passBundlerContext.Bundles.ToList().FirstOrDefault(b => b.Id == item.BundleId);

            var products = bundle.Products;

            return products;
        }

        public Product Get(int id)
        {
            var item = _passBundlerContext.Products.ToList().FirstOrDefault(b => b.Id == id);

            return item;
        }
    }
}
