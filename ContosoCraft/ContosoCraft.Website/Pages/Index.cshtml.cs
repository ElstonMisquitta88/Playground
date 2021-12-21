using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCraft.Website.Models;
using ContosoCraft.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCraft.Website.Pages
{
    //https://gist.github.com/bradygaster/3d1fcf43d1d1e73ea5d6c1b5aab40130
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService _ProductService;
        public IEnumerable<Product> Products { get; private set; }

        // Requesting the Product Service - You can also request other services
        public IndexModel(ILogger<IndexModel> logger,JsonFileProductService productService)  
        {
            _logger = logger;
            _ProductService = productService;
        }

        public void OnGet()
        {
            Products=_ProductService.GetProducts();
        }
    }
}
