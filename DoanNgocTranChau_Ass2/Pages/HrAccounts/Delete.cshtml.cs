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
    public class DeleteModel : PageModel
    {
        private readonly IHrAccountService _hrAccountService;
        public DeleteModel( IHrAccountService hrAccountService)
        {
            _hrAccountService = hrAccountService;
        }

        [BindProperty]
      public Hraccount Hraccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _hrAccountService.GetMemberList() == null)
            {
                return NotFound();
            }

            var hraccount =  _hrAccountService.GetManagementMember(id);

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _hrAccountService.GetMemberList() == null)
            {
                return NotFound();
            }
            var hraccount = _hrAccountService.GetManagementMember(id);          if (hraccount != null)
            {
                _hrAccountService.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
