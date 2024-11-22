using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datavision.Pages
{
    public class AdminPageModel : PageModel
    {
        public void OnGet()
        {

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
