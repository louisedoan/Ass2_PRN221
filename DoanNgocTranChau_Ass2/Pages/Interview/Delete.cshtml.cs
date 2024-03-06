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
    public class DeleteModel : PageModel
    {
      //  private readonly BusinessObject.CandidateManagement_03Context _context;
      private readonly IScheduleService _scheduleService;
        public DeleteModel(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [BindProperty]
      public InterviewSchedule InterviewSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _scheduleService.GetSchedules == null)
            {
                return NotFound();
            }

            var interviewschedule =  _scheduleService.GetById(id);

            if (interviewschedule == null)
            {
                return NotFound();
            }
            else 
            {
                InterviewSchedule = interviewschedule;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _scheduleService.GetSchedules == null)
            {
                return NotFound();
            }
            var interviewschedule = _scheduleService.GetById(id);

            if (interviewschedule != null)
            {
                _scheduleService.DeleteInterview(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
