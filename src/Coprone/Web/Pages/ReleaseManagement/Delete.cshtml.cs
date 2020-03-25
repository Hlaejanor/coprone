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
    public class DeleteModel : PageModel
    {
        private readonly Web.Data.ApplicationDbContext _context;

        public DeleteModel(Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Release = await _context.Release.FindAsync(id);

            if (Release != null)
            {
                _context.Release.Remove(Release);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
