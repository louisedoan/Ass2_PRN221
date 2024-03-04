using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Service;

namespace DoanNgocTranChau_Ass2.Pages.HrAccounts
{
    public class CreateModel : PageModel
    {
        // private readonly BusinessObject.CandidateManagement_03Context _context;

        private readonly IHrAccountService _hrAccountService;
        public CreateModel(IHrAccountService hrAccountService)
        {
            _hrAccountService = hrAccountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hraccount Hraccount { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _hrAccountService.GetMemberList() == null || Hraccount == null)
            {
                return Page();
            }

            _hrAccountService.AddAccount(Hraccount);
           

            return RedirectToPage("./Index");
        }
    }
}
