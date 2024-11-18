using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datavision.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostLogin()
        {
            string Name_User = Request.Form["Nome_User"];    
            string Password_User = Request.Form["Password"];

            User user = Generic.ListOfUsers.Where(u => u.Name == Name_User && u.Password == Password_User).FirstOrDefault();

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToPage();
            }

        }
        public IActionResult OnPostRegistrer()
        {
            string Name_User = Request.Form["Register_Nome_User"];
            string Email = Request.Form["Email"];
            string Password_User = Request.Form["Register_Password"];


            User user = new User();
            user.Name = Name_User;
            user.Email = Email;
            user.Password = Password_User;

            if(Name_User=="")
            {

            }

        }
    }
}
