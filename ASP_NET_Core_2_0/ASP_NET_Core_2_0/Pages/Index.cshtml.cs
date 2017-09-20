using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_NET_Core_2_0.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; private set; }
        public void OnGet()
        {
            Message += $"App for managing products";
        }
    }
}