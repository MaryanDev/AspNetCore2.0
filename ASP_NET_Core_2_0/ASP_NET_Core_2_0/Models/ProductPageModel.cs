using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ASP_NET_Core_2_0.Models
{
    public class ProductPageModel : PageModel
    {
        private IHostingEnvironment _env;
        protected string _path;
        public ProductPageModel(IHostingEnvironment env)
        {
            _env = env;
            _path = Path.Combine(_env.ContentRootPath, "Data\\products.json");
        }
        protected List<Product> GetProducts(Func<Product, bool> criteria = null)
        {
            if (criteria == null)
            {
                return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText(_path));
            }
            return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText(_path)).Where(criteria).ToList();
        }
    }
}
