using Microsoft.AspNetCore.Identity;

namespace dgPad.Models.ViewModels
{
        public class AuthDetailsViewModel
        {
                public string Cookie { get; set; }
                public IdentityUser User { get; set; }
        }
}
