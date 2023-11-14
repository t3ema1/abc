using System.ComponentModel.DataAnnotations;

namespace Identity.Models.Login
{
    public class LoginModel
    {


        [Required]
        public string? Username { get; set; }



        [Required]
        public string? Password { get; set; }

    }
}
