using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoUdemy.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id= "6bd38bc4-1b1c-4776-ade6-b8f3e5af6243",
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                new IdentityRole
                {
                    Id = "829e6136-8a89-4a29-87ac-4a5756e3f51b",
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                }


                );
        }
    }
}
