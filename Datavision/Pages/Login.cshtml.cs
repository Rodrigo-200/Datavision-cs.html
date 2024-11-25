using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Datavision.Pages
{
    public class LoginModel : PageModel
    {
        /*[BindProperty]
        [Required(ErrorMessage = "Login inv�lido")]
        public string Password_User { get; set; }*/

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
                //Verificar se o user � um Admin
                if (user.Name == "admin")
                {
                    return RedirectToPage("AdminPage");
                }
                else
                {
                    return RedirectToPage("Index");
                }
            }
            else
            {
                //Colocar mensagem de erro!!!
                ModelState.AddModelError("Login_Inv�lido", "Username ou Password Inv�lida");
                TempData["Fragment"] = "Login_Section";
                return Page();
            }

        }
        public IActionResult OnPostRegistrer()
        {
            string Name_User = Request.Form["Register_Nome_User"];
            string Email = Request.Form["Email"];
            string Password_User = Request.Form["Register_Password"];

            if ((Generic.ListOfUsers.Where(u => u.Name == Name_User).FirstOrDefault() != null) || (Generic.ListOfUsers.Where(u => u.Email == Email).FirstOrDefault() != null))
            {
                //Colocar mensagem de erro!!!
                ModelState.AddModelError("Registo_Inv�lido", "Uma conta com este username ou email j� existe.");
                TempData["Fragment"] = "Register_Section";
                return Page();

            }
            else
            {
                User user = new User();
                user.Name = Name_User;
                user.Email = Email;
                user.Password = Password_User;

                Generic.ListOfUsers.Add(user);
                return RedirectToPage();
            }
        }
    }
}
