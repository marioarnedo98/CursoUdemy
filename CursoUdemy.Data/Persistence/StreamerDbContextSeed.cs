using CursoUdemy.Domain;
using Microsoft.Extensions.Logging;

namespace CursoUdemy.Infraestructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if (!context.Streamers.Any())
            {
                context.Streamers.AddRange(getPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> getPreconfiguredStreamer()
        {
            return new List<Streamer>()
            {
                new Streamer{CreatedBy = "Mario", Nombre = "Super Nextlof", Url="https://mariomolon.com"},
                new Streamer{CreatedBy = "Mario", Nombre = "Aamazon Plus Ultra", Url="https://samgun2.com"},
            };
        }


    }
}
