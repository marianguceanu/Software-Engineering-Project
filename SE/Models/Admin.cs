namespace SE.Models
{
    public class Admin : User
    {
        public Admin(string username, string password) : base(username, password)
        {
            Type = "admin";
        }

        public Admin(User user) : base(user.Username, user.Password)
        {
            Type = "admin";
        }
    }
}