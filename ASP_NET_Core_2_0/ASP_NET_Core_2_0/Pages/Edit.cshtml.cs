using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Core_2_0.Models;
using ASP_NET_Core_2_0.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ASP_NET_Core_2_0.Pages
{
    public class EditModel : ProductPageModel
    {
        public EditModel(IProductService productService) : base(productService)
        {
            
        }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _productService.GetProducts(p => p.Id == id).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.EditProduct(Product);
            return RedirectToPage("./Products");
        }
    }
}