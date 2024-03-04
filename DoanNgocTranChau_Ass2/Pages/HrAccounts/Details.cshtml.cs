using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.HrAccounts
{
    public class DetailsModel : PageModel
    {
        //  private readonly BusinessObject.CandidateManagement_03Context _context;
        private readonly IHrAccountService _hrAccountService;

        public DetailsModel(IHrAccountService hrAccountService)
        {
            _hrAccountService =hrAccountService;
        }

      public Hraccount Hraccount { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _hrAccountService.GetMemberList == null)
            {
                return NotFound();
            }

            var hraccount = _hrAccountService.GetManagementMember(id);
            if (hraccount == null)
            {
                return NotFound();
            }
            else 
            {
                Hraccount = hraccount;
            }
            return Page();
        }
    }
}
