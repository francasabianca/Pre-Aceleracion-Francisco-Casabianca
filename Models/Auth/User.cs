using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppDisney.Models
{
    public class User : IdentityUser
    {       
        public bool IsActive { get; set; }
    }
}
