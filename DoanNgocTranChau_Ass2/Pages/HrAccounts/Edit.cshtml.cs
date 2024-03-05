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

namespace DoanNgocTranChau_Ass2.Pages.HrAccounts
{
    public class EditModel : PageModel
    {
        //  private readonly BusinessObject.CandidateManagement_03Context _context;

        private readonly IHrAccountService _hrAccountService;
        public EditModel(IHrAccountService hrAccountService)
        {
            _hrAccountService = hrAccountService;
        }

        [BindProperty]
        public Hraccount Hraccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _hrAccountService.GetMemberList == null)
            {
                return NotFound();
            }

            //  var hraccount =  await _context.Hraccounts.FirstOrDefaultAsync(m => m.Email == id);
             var hraccount = _hrAccountService.GetManagementMember(id);

            if (hraccount == null)
            {
                return NotFound();
            }
            Hraccount = hraccount;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           /* if (!ModelState.IsValid)
            {
                return Page();
            }

            _hrAccountService.Attach(Hraccount).State = EntityState.Modified;

            try
            {
                await _hrAccountService.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HraccountExists(Hraccount.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }*/
           try
            {
                _hrAccountService.Update(Hraccount);
            }catch (Exception ex)
            {

            }
            return RedirectToPage("./Index");
        }

        /*private bool HraccountExists(string id)
        {
          return (_hrAccountService.Hraccounts?.Any(e => e.Email == id)).GetValueOrDefault();
        }*/
    }
}
