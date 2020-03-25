using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web.Data;

namespace Web.Pages.ReleaseManagement
{
    public class DetailsModel : PageModel
    {
        private readonly Web.Data.ApplicationDbContext _context;

        public DetailsModel(Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Release Release { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Release = await _context.Release.FirstOrDefaultAsync(m => m.Id == id);

            if (Release == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
