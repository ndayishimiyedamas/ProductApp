using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CommerceApp.Data;
using CommerceApp.Models;

namespace CommerceApp.Pages_Commerces
{
    public class DeleteModel : PageModel
    {
        private readonly CommerceApp.Data.CommerceContext _context;

        public DeleteModel(CommerceApp.Data.CommerceContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Commerce = await _context.Commerces.FindAsync(id);

            if (Commerce != null)
            {
                _context.Commerces.Remove(Commerce);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
