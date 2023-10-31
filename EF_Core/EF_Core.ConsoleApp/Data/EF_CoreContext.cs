using EF_Core.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.ConsoleApp.Data
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OILJRSE\\SQLEXPRESS;Initial Catalog=EFCoreDb;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
