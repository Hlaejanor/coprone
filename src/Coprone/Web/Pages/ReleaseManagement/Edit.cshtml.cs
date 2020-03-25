using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;

namespace Web.Pages.ReleaseManagement
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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

            Release = await _context.Release.FindAsync(id);

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

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var releaseToUpdate = await _context.Release.FindAsync(id);
            if (releaseToUpdate == null) return NotFound();

            if (await TryUpdateModelAsync(
                releaseToUpdate,
                "release",
                s => s.Name, s => s.Version, s => s.Contributors, s => s.Licence))
            {

                await _context.SaveChangesAsync();
                return RedirectToPage("./Details", new { Id = releaseToUpdate.Id });
            }

            return Page();
        }
    }
}
