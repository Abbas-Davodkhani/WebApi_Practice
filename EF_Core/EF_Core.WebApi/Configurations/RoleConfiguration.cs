using EF_Core.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.ConsoleApp.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData
                (
                    new Role
                    {
                        Id = 1,
                        Name = "Admin",
                        Description = "Admin"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "User",
                        Description = "User"
                    }
                );
        }
    }
}
