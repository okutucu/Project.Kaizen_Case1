using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;

namespace Project.WebAPI.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.Property(au => au.UserName).IsRequired().HasMaxLength(20);
            builder.Property(au => au.Password).IsRequired();
            builder.Property(au => au.Role).IsRequired().HasMaxLength(15);

            builder.ToTable("AppUsers");

        }
    }
}
