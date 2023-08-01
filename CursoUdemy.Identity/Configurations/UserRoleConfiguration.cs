using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoUdemy.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId= "6bd38bc4-1b1c-4776-ade6-b8f3e5af6243",
                    UserId= "9b0a8db0-d654-47a9-961c-4923ba15018a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "829e6136-8a89-4a29-87ac-4a5756e3f51b",
                    UserId = "3db2c117-4af3-41ac-93ab-aaf9699c36da"
                }
                );
        }
    }
}
