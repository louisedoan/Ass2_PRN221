using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        //private readonly BusinessObject.CandidateManagement_03Context _context;
        private readonly IJobPostServicecs _jobPostService;
        public CreateModel(IJobPostServicecs jobPostService)
        {
            _jobPostService = jobPostService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _jobPostService.GetJobs == null || JobPosting == null)
            {
                return Page();
            }

            _jobPostService.AddJob(JobPosting);
            

            return RedirectToPage("./Index");
        }
    }
}
