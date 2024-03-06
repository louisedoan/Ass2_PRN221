using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.Jobs
{
    public class DetailsModel : PageModel
    {
        //  private readonly BusinessObject.CandidateManagement_03Context _context;

        private readonly IJobPostServicecs _jobPostService;

        public DetailsModel(IJobPostServicecs jobPostService)
        {
            _jobPostService = jobPostService;
        }

      public JobPosting JobPosting { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _jobPostService.GetJobs == null)
            {
                return NotFound();
            }

            var jobposting =  _jobPostService.GetById(id);
            if (jobposting == null)
            {
                return NotFound();
            }
            else 
            {
                JobPosting = jobposting;
            }
            return Page();
        }
    }
}
