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
using Microsoft.Build.Execution;

namespace DoanNgocTranChau_Ass2.Pages.Interview
{
    public class EditModel : PageModel
    {
      //  private readonly BusinessObject.CandidateManagement_03Context _context;
      private readonly IScheduleService _scheduleService;
       private readonly ICandidateService _candidateService;
        public EditModel(IScheduleService scheduleService, ICandidateService candidateService)
        {
            _scheduleService = scheduleService;
            _candidateService = candidateService;
        }

        [BindProperty]
        public InterviewSchedule InterviewSchedule { get; set; } = default!;
        public List<SelectListItem> CandidatesList { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _scheduleService.GetSchedules == null)
            {
                return NotFound();
            }

            var interviewschedule =   _scheduleService.GetById(id);
            if (interviewschedule == null)
            {
                return NotFound();
            }
            InterviewSchedule = interviewschedule;
            var candidateData = _candidateService.GetAllCandidate();
            CandidatesList = new List<SelectListItem>();
            foreach (var candidate in candidateData)
            {
                CandidatesList.Add(new SelectListItem
                {
                    Text = candidate.Fullname,
                    Value = candidate.CandidateId.ToString()
                });
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InterviewSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewScheduleExists(InterviewSchedule.InterviewId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }*/
            _scheduleService.UpdateInterview(InterviewSchedule);
            return RedirectToPage("./Index");
        }

        /*private bool InterviewScheduleExists(string id)
        {
          return (_context.InterviewSchedules?.Any(e => e.InterviewId == id)).GetValueOrDefault();
        }*/
    }
}
