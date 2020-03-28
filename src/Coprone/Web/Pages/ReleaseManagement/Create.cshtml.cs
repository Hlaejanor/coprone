using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Data;

namespace Web.Pages.ReleaseManagement
{
    public class CreateModel : PageModel
    {
        private readonly Web.Data.ApplicationDbContext _context;

        public CreateModel(Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        //[BindProperty]
        public Release Release { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newRelease = new Release();

            if (await MapInput(newRelease))
            {

                newRelease.CreatedUtc = DateTime.UtcNow;
                _context.Release.Add(newRelease);

                await _context.SaveChangesAsync();
                return RedirectToPage("./Details", new { Id = newRelease.Id });
            }

            return null;
        }

        private async Task<bool> MapInput(Release newRelease)
        {
            return await TryUpdateModelAsync(
                           newRelease,
                           "release",   // Prefix for form value.
                           s => s.Name, s => s.Version, s => s.Contributors, s => s.Licence);
        }
    }
}
