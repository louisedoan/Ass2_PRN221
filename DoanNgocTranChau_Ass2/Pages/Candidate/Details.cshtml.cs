﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace DoanNgocTranChau_Ass2.Pages.Candidate
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.CandidateManagement_03Context _context;

        public DetailsModel(BusinessObject.CandidateManagement_03Context context)
        {
            _context = context;
        }

      public CandidateProfile CandidateProfile { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CandidateProfiles == null)
            {
                return NotFound();
            }

            var candidateprofile = await _context.CandidateProfiles.FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            else 
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }
    }
}
