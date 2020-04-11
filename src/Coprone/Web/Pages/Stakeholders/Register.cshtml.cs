using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Data.Entities.StackeholderEntities;

namespace Web.Pages.Stakeholders
{
    public class CreateModel : PageModel
    {
        private readonly Web.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser _userFromDb;
        public Stakeholder Stakeholder { get; set; }

        public CreateModel(Web.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {

            _userFromDb = await _userManager.GetUserAsync(User);
            if (_userFromDb == null)
            {
                RedirectToPage("/Login");
                throw new Exception("User not logged in");
            }

            Stakeholder = await _context.Stakeholder
                .Where(x => x.IdentityUser.Id == _userFromDb.Id)
                .FirstOrDefaultAsync();
        }

      

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userFromDb = await _userManager.GetUserAsync(User);

            Stakeholder = await _context.Stakeholder
            .Where(x => x.IdentityUser.Id == _userFromDb.Id)
            .FirstOrDefaultAsync();

            bool isNew = false;
            if (Stakeholder == null)
            {
                isNew = true;
            }

            var stakeholderToUpdate = isNew ? CreateNewStakeholder() : await _context.Stakeholder
                .Where(x => x.IdentityUser.Id == _userFromDb.Id)
                .FirstOrDefaultAsync();

            bool mappingSucceeded = await MapInput(stakeholderToUpdate);

            if (mappingSucceeded)
            {
                if (isNew)
                    _context.Stakeholder.Add(stakeholderToUpdate);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Details", new { Id = stakeholderToUpdate.Id });
        }

        private Stakeholder CreateNewStakeholder()
        {
            return new Stakeholder { CreatedUtc = DateTime.UtcNow, IdentityUser = _userFromDb };
        }

        private async Task<bool> MapInput(Stakeholder stakeholder)
        {
            return await TryUpdateModelAsync(
                           stakeholder,
                           "stakeholder",   // Prefix for form value.
                           s => s.Type,
                           s => s.ProducerType,
                           s => s.BuyerType,
                           s => s.Organization,
                           s => s.State,
                           s => s.Country,
                           s => s.NumberOfEmployees,
                           s => s.ContactPerson,
                           s => s.PhoneNumber,
                           s => s.Email,
                           s => s.Equipment,
                           s => s.HowCanYouHelp);
        }
    }
}
