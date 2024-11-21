using System.Security.Claims;

namespace Datavision
{
    public class Generic
    {
        public static List<User> ListOfUsers = new List<User>() {
            new User() { Name="admin",Email="admin@gmail.com",Password="1234"},
            };
        public static User CurrentUser = new User();
        public static List<Comment> ListOfComments = new List<Comment>();
        public static List<Comment> reviews = new List<Comment>();
        public static List<Contact> contacts = new List<Contact>() 
        { new Contact("Olek", "bub@gmail.com", "+351 910 703 456", "dhajsdhajsdhasjdhasjdhasjdhasjdhasddahdhasjdasjhdasjdsajd") };

    }
}
