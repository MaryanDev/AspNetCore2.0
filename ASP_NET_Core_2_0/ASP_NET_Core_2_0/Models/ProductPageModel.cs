using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_Core_2_0.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ASP_NET_Core_2_0.Models
{
    public class ProductPageModel : PageModel
    {
        protected IProductService _productService;
        public ProductPageModel(IProductService productService)
        {
            _productService = productService;
        }
    }
}
