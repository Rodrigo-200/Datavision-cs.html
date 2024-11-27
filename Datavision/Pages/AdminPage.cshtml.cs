using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datavision.Pages
{
    public class AdminPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Login") != "Admin")
            {
                return RedirectToPage("/Login");
            }
            // Return the page if the user is logged in
            return Page();
        }
        public IActionResult OnPost(int id) {

            if (id >= 0 && id < Generic.contacts.Count)
            {
                Generic.contacts.RemoveAt(id);
            }

            return RedirectToPage();
        }
    }
}
