namespace Datavision
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

        public Contact(string Name, string Email, string Phone, string Message)
        {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Message = Message;
        }
    }
}