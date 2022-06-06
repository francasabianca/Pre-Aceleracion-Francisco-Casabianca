using System;

namespace AppDisney.ViewModels.Auth.Login
{
    public class LoginResponseVM
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
