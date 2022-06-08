using System.ComponentModel.DataAnnotations;

namespace AppDisney.ViewModels.Auth.Login
{
    public class LoginRequestVM
    {
        [Required, MinLength(6)]
        public string UserName { get; set; }
        
        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}
