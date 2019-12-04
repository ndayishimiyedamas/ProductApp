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
    public class DetailsModel : PageModel
    {
        private readonly CommerceApp.Data.CommerceContext _context;

        public DetailsModel(CommerceApp.Data.CommerceContext context)
        {
            _context = context;
        }

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
    }
}
