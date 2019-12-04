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
    public class IndexModel : PageModel
    {
        private readonly CommerceApp.Data.CommerceContext _context;

        public IndexModel(CommerceApp.Data.CommerceContext context)
        {
            _context = context;
        }

        public IList<Commerce> Commerce { get;set; }

        public async Task OnGetAsync()
        {
            Commerce = await _context.Commerces.ToListAsync();
        }
    }
}
