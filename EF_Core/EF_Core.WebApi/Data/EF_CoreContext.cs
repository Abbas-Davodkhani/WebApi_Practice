using EF_Core.ConsoleApp.Configuration;
using EF_Core.WebApi.Configurations;
using EF_Core.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.WebApi.Data
{
    public class EF_CoreContext : DbContext
    {
        public EF_CoreContext()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MINICASE-1-CORE\\SA;Database=EF_CoreDb;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
