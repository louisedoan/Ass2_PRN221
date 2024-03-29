﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.Candidate
{
    public class DeleteModel : PageModel
    {
        //private readonly BusinessObject.CandidateManagement_03Context _context;
        private readonly ICandidateService _candidateService;
        public DeleteModel(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [BindProperty]
      public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _candidateService.GetAllCandidate == null)
            {
                return NotFound();
            }

            var candidateprofile =  _candidateService.GetById(id);

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _candidateService.GetAllCandidate == null)
            {
                return NotFound();
            }
            var candidateprofile =  _candidateService.GetById(id);

            if (candidateprofile != null)
            {
                _candidateService.DeleteCandidate(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
