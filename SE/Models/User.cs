namespace SE.Models
{
    public class User
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Type = "normal";
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}