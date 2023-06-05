using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE.Models
{

    public class User
    {
        [Key]
        public int Id { get; set; } = default!;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        [NotMapped]
        public virtual IEnumerable<UserDestination> AbsUserDestinations { get; set; } = default!;
    }
}