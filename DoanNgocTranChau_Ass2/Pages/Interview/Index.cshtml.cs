using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.Interview
{
    public class IndexModel : PageModel
    {
       // private readonly BusinessObject.CandidateManagement_03Context _context;
       private  readonly IScheduleService _scheduleService;
        private readonly ICandidateService _candidateService;

        public IndexModel(IScheduleService scheduleService, ICandidateService candidateService)
        {
            _scheduleService = scheduleService;
            _candidateService = candidateService;
        }

        public IList<InterviewSchedule> InterviewSchedule { get;set; } = default!;
  
        public Dictionary<string, string> CandidateList { get; set; }
        public IActionResult OnGet()
        {
            // Lấy danh sách ứng viên
            InterviewSchedule = _scheduleService.GetSchedules();

            // Lấy danh sách công việc
            var candidateData = _candidateService.GetAllCandidate();
            CandidateList = new Dictionary<string, string>();
            foreach (var candidate in candidateData)
            {
                CandidateList.Add(candidate.CandidateId, candidate.Fullname);
            }

            return Page();
        }
    }
}
