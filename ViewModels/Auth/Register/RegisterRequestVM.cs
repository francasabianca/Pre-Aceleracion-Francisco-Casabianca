using System.ComponentModel.DataAnnotations;

namespace AppDisney.ViewModels.Auth
{
    public class RegisterRequestVM
    {
        [Required, MinLength(6)]
        public string UserName { get; set; }       
        [Required, MinLength(6)]
        public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
