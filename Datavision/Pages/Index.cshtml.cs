using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

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
            if (HttpContext.Session.GetString("Login") != "User")
            {
                RedirectToPage("/");
            }
        }
        public IActionResult OnPostReview()
        {
            string name = Request.Form["username"];
            string email = Request.Form["email"];
            string message = Request.Form["review"];
            int stars = int.Parse(Request.Form["stars"]);

            Review newReview = new Review(name, email, message, stars);
            Generic.reviews.Add(newReview);

            return Page();
        }
        public IActionResult OnPostComment()
        {
            string name = Request.Form["CommentUsername"];
            string email = Request.Form["Commentemail"];
            string Comment = Request.Form["Comment"];
            Comment newComment = new Comment
            {
                Username = name,
                Email = email,
                Content = Comment
            };

            Generic.ListOfComments.Add(newComment);


            TempData["Fragment"] = "comment";
            return Page();
        }

        public IActionResult OnPostContact()
        {
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string phone = Request.Form["phone"];
            string message = Request.Form["message"];

            Generic.contacts.Add(new Contact(name, email, phone, message));
            TempData["Fragment"] = "contact";
            return RedirectToPage("");
        }
    }
}
