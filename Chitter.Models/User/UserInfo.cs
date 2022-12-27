namespace Chitter.Models.User
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}