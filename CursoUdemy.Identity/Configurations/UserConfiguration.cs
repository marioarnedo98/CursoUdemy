using CursoUdemy.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoUdemy.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "9b0a8db0-d654-47a9-961c-4923ba15018a",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Mario",
                    Apellidos= "Arnedo",
                    UserName ="marnedo",
                    NormalizedUserName = "marnedo",
                    PasswordHash = hasher.HashPassword(null, "Emesa2016"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "3db2c117-4af3-41ac-93ab-aaf9699c36da",
                    Email = "juan@localhost.com",
                    NormalizedEmail = "juan@localhost.com",
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    UserName = "jperez",
                    NormalizedUserName = "jperez",
                    PasswordHash = hasher.HashPassword(null, "Emesa2016"),
                    EmailConfirmed = true
                }
                );
        }
    }
}
