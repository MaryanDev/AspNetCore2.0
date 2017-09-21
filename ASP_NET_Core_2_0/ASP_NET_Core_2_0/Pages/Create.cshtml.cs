using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Core_2_0.Models;
using ASP_NET_Core_2_0.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Rewrite.Internal;

namespace ASP_NET_Core_2_0.Pages
{
    public class CreateModel : ProductPageModel
    {
        public CreateModel(IProductService productService) : base(productService)
        {
                
        }
        public Product Product { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Product product)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.AddProduct(product);

            return RedirectToPage("./Products");
        }
    }
}