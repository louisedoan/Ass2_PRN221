using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace DoanNgocTranChau_Ass2.Pages.HrAccount
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.CandidateManagement_03Context _context;

        public IndexModel(BusinessObject.CandidateManagement_03Context context)
        {
            _context = context;
        }

        public IList<Hraccount> Hraccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Hraccounts != null)
            {
                Hraccount = await _context.Hraccounts.ToListAsync();
            }
        }
    }
}
