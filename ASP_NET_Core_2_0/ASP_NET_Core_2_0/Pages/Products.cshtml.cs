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
    public class ProductsModel : ProductPageModel
    {
        public ProductsModel(IHostingEnvironment env) : base(env)
        {
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

    }
}