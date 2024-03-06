using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoanNgocTranChau_Ass2.Pages.Candidate
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateService _candidateService;
        private readonly IJobPostServicecs _jobPostServicecs;

        public IndexModel(ICandidateService candidateService, IJobPostServicecs jobPostServicecs)
        {
            _candidateService = candidateService;
            _jobPostServicecs = jobPostServicecs;
        }

        public IList<CandidateProfile> CandidateProfile { get; set; }
        public Dictionary<string, string> JobPostings { get; set; }

        public IActionResult OnGet()
        {
            // Lấy danh sách ứng viên
            CandidateProfile = _candidateService.GetAllCandidate();

            // Lấy danh sách công việc
            var jobsData = _jobPostServicecs.GetJobs();
            JobPostings = new Dictionary<string, string>();
            foreach (var job in jobsData)
            {
                JobPostings.Add(job.PostingId, job.JobPostingTitle);
            }

            return Page();
        }
    }
}
