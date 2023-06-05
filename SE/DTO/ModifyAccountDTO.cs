using System.ComponentModel.DataAnnotations;

namespace SE.DTO
{
    public class ModifyAccountDTO
    {
        [Required]
        public string Username { get; set; } = default!;
        [Required]
        public string OldPassword { get; set; } = default!;
        [Required]
        public string NewPassword { get; set; } = default!;
    }
}