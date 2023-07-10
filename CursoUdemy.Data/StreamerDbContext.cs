
using CursoUdemy.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoUdemy.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress;Initial Catalog=Streamer;Integrated Security=True; TrustServerCertificate=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        public DbSet <Streamer> Streamers { get; set; }

        public DbSet <Video> Videos { get; set; }

    }
}
