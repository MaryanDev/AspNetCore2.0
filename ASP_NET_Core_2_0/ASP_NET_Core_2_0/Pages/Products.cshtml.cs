using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Core_2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using ASP_NET_Core_2_0.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace ASP_NET_Core_2_0.Pages
{
    public class ProductsModel : ProductPageModel
    {
        public readonly int pageSize;
        public int currentPage;
        public int numberOfPages;
        public ProductsModel(IProductService productService) : base(productService)
        {
            pageSize = 10;
        }

        protected int GetCountOfPages(int allPages, int size)
        {
            var pages = allPages / size;
            var count = allPages % size == 0 ? pages : ++pages;
            return count;
        }

        [BindProperty]
        public List<Product> Products { get; set; }
        public void OnGet(int pageNum = 1)
        {
            var allProducts = _productService.GetProducts();
            Products = allProducts.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            numberOfPages = GetCountOfPages(allProducts.Count, pageSize);
            currentPage = pageNum;
        }

        public IActionResult OnPostDelete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToPage();
        }
    }
}