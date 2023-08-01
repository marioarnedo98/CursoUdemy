using CursoUdemy.Identity.Configurations;
using CursoUdemy.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CursoUdemy.Identity
{
    public class CursoUdemyIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public CursoUdemyIdentityDbContext(DbContextOptions<CursoUdemyIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

    }
}
