using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Web.Pages
{
    public class TheBedModel : PageModel
    {
        private readonly ILogger<TheBedModel> _logger;

        public TheBedModel(ILogger<TheBedModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
