using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Core_2_0.Models;

namespace ASP_NET_Core_2_0.Services.Abstract
{
    public interface IProductService
    {
        List<Product> GetProducts(Func<Product, bool> criteria = null);
        void DeleteProduct(int id);
        void EditProduct(Product product);
        void AddProduct(Product product);
    }
}
