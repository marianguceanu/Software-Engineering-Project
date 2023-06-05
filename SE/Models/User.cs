using System.ComponentModel.DataAnnotations;
namespace SE.Models
{

    public class User
    {
        [Key]
        public int Id { get; set; } = default!;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Type = "normal";
        public virtual ICollection<UserDestination> AbsUserDestinations { get; set; } = default!;
    }
}