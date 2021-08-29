using Microsoft.AspNetCore.Identity;

namespace WebApplicationNet5.Models
{
    public class MyUser : IdentityUser
    {
        public int Year { get; set; }
    }
}