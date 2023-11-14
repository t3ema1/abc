using System.ComponentModel.DataAnnotations;

namespace Identity.Models.SignUp
{
    public class RegisterUser
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? role { get; set; }
    }
}
