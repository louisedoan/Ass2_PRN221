using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.Interview
{
    public class CreateModel : PageModel
    {
        // private readonly BusinessObject.CandidateManagement_03Context _context;
        private readonly IScheduleService _schedulduleService;
        private readonly ICandidateService _candidateService;
        public CreateModel(IScheduleService schedulduleService, ICandidateService candidateService)
        {
            _schedulduleService = schedulduleService;
            _candidateService = candidateService;
        }
        public InterviewSchedule InterviewSchedule { get; set; }
        public List<SelectListItem> CandidatesList { get; set; }
       
        public IActionResult OnGet()
        {
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


       
     
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _schedulduleService.GetSchedules == null || InterviewSchedule == null)
            {
                return Page();
            }

            _schedulduleService.AddInterview(InterviewSchedule);
           

            return RedirectToPage("./Index");
        }
    }
}
