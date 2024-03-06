using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.Candidate
{
    public class CreateModel : PageModel
       {
        private readonly ICandidateService _candidateService;
        private readonly IJobPostServicecs _jobPostServicecs;

        public CreateModel(ICandidateService candidateService, IJobPostServicecs jobPostServicecs)
        {
            _candidateService = candidateService;
            _jobPostServicecs = jobPostServicecs;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }

        public List<SelectListItem> JobPostings { get; set; }

        public IActionResult OnGet()
        {
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _candidateService.AddCadidate(CandidateProfile);
           

            return RedirectToPage("./Index");
        }
    }
}
  