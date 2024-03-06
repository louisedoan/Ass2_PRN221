using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace DoanNgocTranChau_Ass2.Pages.Interview
{
    public class EditModel : PageModel
    {
        private readonly BusinessObject.CandidateManagement_03Context _context;

        public EditModel(BusinessObject.CandidateManagement_03Context context)
        {
            _context = context;
        }

        [BindProperty]
        public InterviewSchedule InterviewSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.InterviewSchedules == null)
            {
                return NotFound();
            }

            var interviewschedule =  await _context.InterviewSchedules.FirstOrDefaultAsync(m => m.InterviewId == id);
            if (interviewschedule == null)
            {
                return NotFound();
            }
            InterviewSchedule = interviewschedule;
           ViewData["CandidateId"] = new SelectList(_context.CandidateProfiles, "CandidateId", "CandidateId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
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
            }

            return RedirectToPage("./Index");
        }

        private bool InterviewScheduleExists(string id)
        {
          return (_context.InterviewSchedules?.Any(e => e.InterviewId == id)).GetValueOrDefault();
        }
    }
}
