using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using System.Reflection;

namespace Project.WebAPI.Context
{
    public class CodeDbContext : DbContext
    {
        public CodeDbContext(DbContextOptions<CodeDbContext> options) : base(options){}

        public DbSet<Code> Codes { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Çalıştığımız assemblydeki tüm configür dosylarının dbcontext'e tanımladık.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
