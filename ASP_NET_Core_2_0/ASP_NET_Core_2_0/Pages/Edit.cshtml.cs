using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Core_2_0.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_NET_Core_2_0.Pages
{
    public class EditModel : ProductPageModel
    {
        public EditModel(IHostingEnvironment env) : base(env)
        {
            
        }
        private Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = GetProducts(p => p.Id == id).FirstOrDefault();
        }
    }
}