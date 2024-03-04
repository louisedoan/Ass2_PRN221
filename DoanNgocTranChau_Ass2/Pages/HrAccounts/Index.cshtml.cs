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
    public class IndexModel : PageModel
    {
       // private readonly BusinessObject.CandidateManagement_03Context _context;
        private readonly IHrAccountService _hrAccountService;
        public IndexModel(IHrAccountService hrAccountService)
        {
            _hrAccountService = hrAccountService;
        }

        public IList<Hraccount> Hraccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_hrAccountService.GetMemberList != null)
            {
                Hraccount =  _hrAccountService.GetMemberList();
            }
        }
    }
}
