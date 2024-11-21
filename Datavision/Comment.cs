namespace Datavision
{
    public class Comment
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }

        public Comment()
        {

        }

        public Comment(string username, string email, string content)
        {
            this.Username = username;
            this.Email = email;
            this.Content = content;
        }
    }
}