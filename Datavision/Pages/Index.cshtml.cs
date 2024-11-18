using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datavision.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostComment()
        {
            string name = Request.Form["Username"];
            string email = Request.Form["Commentemail"];
            string Comment = Request.Form["Comment"];

           return RedirectToPage();
        }

        public IActionResult OnPostContact()
        {
            return RedirectToPage();
        }
    }
}
