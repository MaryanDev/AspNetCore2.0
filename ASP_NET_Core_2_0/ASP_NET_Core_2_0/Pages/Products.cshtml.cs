using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Core_2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace ASP_NET_Core_2_0.Pages
{
    public class ProductsModel : PageModel
    {
        private IHostingEnvironment _env;
        private string _path;
        public ProductsModel(IHostingEnvironment env)
        {
            _env = env;
            _path = Path.Combine(_env.ContentRootPath, "Data\\products.json");
        }

        [BindProperty]
        public List<Product> Products { get; set; }
        public void OnGet()
        {
            
            Products = GetProducts();
        }

        public IActionResult OnPostDelete(int id)
        {
            var allProducts = GetProducts();
            var product = allProducts.Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                allProducts.Remove(product);
                System.IO.File.WriteAllText(_path, JsonConvert.SerializeObject(allProducts));
            }
            return RedirectToPage();
        }

        private List<Product> GetProducts(Func<Product, bool>criteria = null )
        {
            if (criteria == null)
            {
                return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText(_path));
            }
            return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText(_path)).Where(criteria).ToList();
        }
    }
}