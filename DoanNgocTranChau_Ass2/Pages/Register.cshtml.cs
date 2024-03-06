using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace DoanNgocTranChau_Ass2.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IHrAccountService _accountRepository;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string FullName { get; set; }
        public RegisterModel(IHrAccountService accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
               
                if (_accountRepository.GetManagementMember(Email) != null)
                {
                   
                    ViewData["Message"] = "Email already exists!";
                    return Page();
                }

                
                Hraccount newAccount = new Hraccount
                {
                    Email = Email,
                    Password = Password,
                    FullName = FullName,
                    MemberRole = 3 
                };

                _accountRepository.AddAccount(newAccount);

                return RedirectToPage("/Index");
            }

           
            return Page();
        }
    }
}
