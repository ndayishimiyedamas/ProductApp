using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommerceApp.Data;
using CommerceApp.Models;

namespace CommerceApp.Pages_Commerces
{
    public class EditModel : PageModel
    {
        private readonly CommerceApp.Data.CommerceContext _context;

        public EditModel(CommerceApp.Data.CommerceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Commerce Commerce { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Commerce = await _context.Commerces.FirstOrDefaultAsync(m => m.Id == id);

            if (Commerce == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Commerce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommerceExists(Commerce.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CommerceExists(int id)
        {
            return _context.Commerces.Any(e => e.Id == id);
        }
    }
}
