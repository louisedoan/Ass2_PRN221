using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Service;
using System.Diagnostics.Metrics;
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

                switch (account.MemberRole)
                {
                    case 1:
                        HttpContext.Session.SetString("role", "admin");
                        HttpContext.Session.SetString("email", account.Email);
                       // HttpContext.Session.SetString("fullname", account.FullName);
                        return Redirect("Candidate");
                        break;
                        case 2:
                        HttpContext.Session.SetString("role", "staff");
                        HttpContext.Session.SetString("email", account.Email);
                        // HttpContext.Session.SetString("fullname", account.FullName);
                        return Redirect("Candidate");
                        break;
                    case 3:
                        HttpContext.Session.SetString("role", "user");
                        HttpContext.Session.SetString("email", account.Email);
                        // HttpContext.Session.SetString("fullname", account.FullName);
                        return Redirect("Candidate");
                        break;
                    default:
                        break;
                }
               
            }
            return Redirect("Index");
        }
        public void OnGet()
        {

        }


       
    }
}
