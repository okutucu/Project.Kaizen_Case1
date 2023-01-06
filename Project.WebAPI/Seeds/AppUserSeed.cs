using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.WebAPI.Models;

namespace Project.WebAPI.Seeds
{
    public class AppUserSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            
            //string adminPassword = BCrypt.Net.BCrypt.HashPassword("admin123");
            //string userPassWord = BCrypt.Net.BCrypt.HashPassword("user123");
            builder.HasData
                (
                new AppUser() { Id = 1, UserName = "admin", Password = "admin123", Role = Enums.Role.Admin, CreatedDate = DateTime.Now},
                new AppUser() { Id = 2, UserName = "user", Password = "user123", Role = Enums.Role.User, CreatedDate = DateTime.Now}
                );
        }
    }
}
