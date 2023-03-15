using Microsoft.AspNetCore.Identity;

namespace OnlineFoodOrder.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
        public string City { get; set; }
    }
}
