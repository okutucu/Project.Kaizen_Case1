using Microsoft.AspNetCore.Identity;
using Project.WebAPI.Enums;

namespace Project.WebAPI.Models
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
