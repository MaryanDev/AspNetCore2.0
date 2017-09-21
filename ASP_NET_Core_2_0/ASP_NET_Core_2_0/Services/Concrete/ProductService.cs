using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Core_2_0.Models;
using ASP_NET_Core_2_0.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace ASP_NET_Core_2_0.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IHostingEnvironment _env;
        protected string _path;
        public ProductService(IHostingEnvironment env)
        {
            _env = env;
            _path = Path.Combine(_env.ContentRootPath, "Data\\products.json");
        }
        public List<Product> GetProducts(Func<Product, bool> criteria = null)
        {
            if (criteria == null)
            {
                return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText(_path));
            }
            return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText(_path)).Where(criteria).ToList();
        }

        public void DeleteProduct(int id)
        {
            var allProducts = GetProducts();
            var product = allProducts.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                allProducts.Remove(product);
                System.IO.File.WriteAllText(_path, JsonConvert.SerializeObject(allProducts));
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void EditProduct(Product product)
        {
            var allProducts = GetProducts();
            var index = allProducts.FindIndex(p => p.Id == product.Id);
            if (index >= 0)
            {
                allProducts[index] = product;
                System.IO.File.WriteAllText(_path, JsonConvert.SerializeObject(allProducts));
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddProduct(Product product)
        {
            var allProducts = GetProducts();
            if (product != null)
            {
                allProducts.Add(product);
                System.IO.File.WriteAllText(_path, JsonConvert.SerializeObject(allProducts));
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
