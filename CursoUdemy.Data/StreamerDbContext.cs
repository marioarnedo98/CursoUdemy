
using CursoUdemy.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoUdemy.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress;Initial Catalog=Streamer;Integrated Security=True; TrustServerCertificate=True");
        }
        public DbSet <Streamer> Streamers { get; set; }

        public DbSet <Video> Videos { get; set; }

    }
}
