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
            string name = Request.Form["CommentUsername"];
            string email = Request.Form["Commentemail"];
            string Comment = Request.Form["Comment"];

            Comment NewComment = new Comment();
            NewComment.Username = name;
            NewComment.Email = email;
            NewComment.Content = Comment;

            Generic.ListOfComments.Add(NewComment);

           return RedirectToPage();
        }

        public IActionResult OnPostContact()
        {
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string phone = Request.Form["phone"];
            string message = Request.Form["message"];

            Generic.contacts.Add(new Contact(name, email, phone, message));

            return RedirectToPage("AdminPage");
        }
    }
}
