namespace Datavision
{
    public class Review
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int Stars { get; set; }

        public Review()
        {
        }

        public Review(string username, string email, string content, int Stars)
        {
            this.Username = username;
            this.Email = email;
            this.Content = content;
            this.Stars = Stars;
        }
    }
}