using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Service;
using System.Security.Principal;

namespace DoanNgocTranChau_Ass2.Pages
{
    public class IndexModel : PageModel
    {

        private string email;
        private string password;
        private readonly IHrAccountService _accountRepository ;

        [BindProperty]
        public string Password { get => password; set => password = value; }
        [BindProperty]
        public string Email { get => email; set => email = value; }
        public IndexModel(IHrAccountService accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult OnPost()
        {
            string email = Request.Form["Email"];

            Hraccount account = _accountRepository.GetManagementMember(email);

            if (account != null && password.Equals(account.Password))
            {
                return Redirect("HrAccounts");
            }
            return Redirect("Index");
        }
        public void OnGet()
        {

        }


       
    }
}
