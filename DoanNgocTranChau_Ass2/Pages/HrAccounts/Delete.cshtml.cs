﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace DoanNgocTranChau_Ass2.Pages.HrAccounts
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.CandidateManagement_03Context _context;

        public DeleteModel(BusinessObject.CandidateManagement_03Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Hraccount Hraccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Hraccounts == null)
            {
                return NotFound();
            }

            var hraccount = await _context.Hraccounts.FirstOrDefaultAsync(m => m.Email == id);

            if (hraccount == null)
            {
                return NotFound();
            }
            else 
            {
                Hraccount = hraccount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Hraccounts == null)
            {
                return NotFound();
            }
            var hraccount = await _context.Hraccounts.FindAsync(id);

            if (hraccount != null)
            {
                Hraccount = hraccount;
                _context.Hraccounts.Remove(Hraccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
