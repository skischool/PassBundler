using System.Collections.Generic;
using Domain.Core;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Products
{
    public interface IProductRepository
    {
        Product Add(Product item);

        Product Update(Product item);

        Product Delete(int id);

        IEnumerable<Product> List(Product item);

        Product Get(int id);
    }
}
