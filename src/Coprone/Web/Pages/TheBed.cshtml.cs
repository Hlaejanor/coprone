using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web.Data;

namespace Web.Pages
{
    public class TheBedModel : PageModel
    {
        private readonly ILogger<TheBedModel> _logger;
        private readonly Web.Data.ApplicationDbContext _context;
        public TheBedModel(ILogger<TheBedModel> logger, Web.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<Release> Release { get; set; }

        public async Task OnGetAsync()
        {
            Release = await _context.Release.ToListAsync();
        }
      
    }
}
