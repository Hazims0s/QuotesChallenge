using Microsoft.AspNetCore.Identity;

namespace UI.Models
{
    public class User : IdentityUser
    {
        public string Token { get; set; }
    }
}
