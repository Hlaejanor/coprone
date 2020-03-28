using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Data.Entities.StackeholderEntities;

namespace Web.Pages.Stakeholders
{
    public class DetailsModel : PageModel
    {
        private readonly Web.Data.ApplicationDbContext _context;

        public DetailsModel(Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Stakeholder Stakeholder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stakeholder = await _context.Stakeholder.FirstOrDefaultAsync(m => m.Id == id);

            if (Stakeholder == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
