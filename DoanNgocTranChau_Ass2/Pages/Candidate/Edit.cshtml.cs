using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.Candidate
{
    public class EditModel : PageModel
    {
        //private readonly BusinessObject.CandidateManagement_03Context _context;
        private readonly ICandidateService _candidateService;

        private readonly IJobPostServicecs _jobPostServicecs;
        public EditModel(ICandidateService candidateService, IJobPostServicecs jobPostServicecs)
        {
            _candidateService = candidateService;
            _jobPostServicecs = jobPostServicecs;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        public List<SelectListItem> JobPostings { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _candidateService.GetAllCandidate == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateService.GetById(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
            var jobsData = _jobPostServicecs.GetJobs();
            JobPostings = new List<SelectListItem>();
            foreach (var job in jobsData)
            {
                JobPostings.Add(new SelectListItem
                {
                    Text = job.JobPostingTitle,
                    Value = job.PostingId.ToString()
                });
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _candidateService.UpdateCandidate(CandidateProfile);
            }
            catch (Exception ex)
            {

            }
            return RedirectToPage("./Index");
            
        }

        /*private bool CandidateProfileExists(string id)
        {
          return (_context.CandidateProfiles?.Any(e => e.CandidateId == id)).GetValueOrDefault();
        }*/
    }
}
