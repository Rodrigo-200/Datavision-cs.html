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
            return RedirectToPage();
        }
        public IActionResult OnPostRegistrer()
        {
            return RedirectToPage();
        }
    }
}
