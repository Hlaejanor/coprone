using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Web.Pages
{
    public class TheScienceModel : PageModel
    {
        private readonly ILogger<TheScienceModel> _logger;

        public TheScienceModel(ILogger<TheScienceModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
