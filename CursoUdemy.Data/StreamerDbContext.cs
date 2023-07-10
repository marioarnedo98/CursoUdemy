
using CursoUdemy.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoUdemy.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=localhost/sqlexpress; Initial Catalog= Streamer; Integrated Security = True");
        }
        public DbSet <Streamer> Streamers { get; set; }

        public DbSet <Video> Videos { get; set; }

    }
}
