using System.Collections.Generic;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Products
{
    public interface IProductService
    {
        Product Add(Product item);

        Product Update(Product item);

        Product Delete(int id);

        Product Get(int id);

        IEnumerable<Product> List(Product item);
    }
}
