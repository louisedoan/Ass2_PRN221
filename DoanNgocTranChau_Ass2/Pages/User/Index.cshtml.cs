using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.CandidateManagement_03Context _context;
        private readonly IJobPostServicecs _jobPostServicecs;
        public IndexModel(IJobPostServicecs jobPostServicecs)
        {
            _jobPostServicecs = jobPostServicecs;
        }

        public IList<JobPosting> JobPosting { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_jobPostServicecs.GetJobs != null)
            {
                JobPosting = _jobPostServicecs.GetJobs();
            }
        }
    }
}

