using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CommerceApp.Data;
using CommerceApp.Models;

namespace CommerceApp.Pages_Commerces
{
    public class CreateModel : PageModel
    {
        private readonly CommerceApp.Data.CommerceContext _context;

        public CreateModel(CommerceApp.Data.CommerceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Commerce Commerce { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Commerces.Add(Commerce);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
