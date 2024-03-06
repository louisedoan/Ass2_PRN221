using System;
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
    public class IndexModel : PageModel
    {
        // private readonly BusinessObject.CandidateManagement_03Context _context;
        private readonly ICandidateService _candidateService;
        public IndexModel(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        public IList<CandidateProfile> CandidateProfile { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_candidateService.GetAllCandidate != null)
            {
                CandidateProfile = _candidateService.GetAllCandidate();

            }
        }
    }
}
