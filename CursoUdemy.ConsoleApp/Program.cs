using CursoUdemy.Data;
using CursoUdemy.Domain;

StreamerDbContext dbContext = new();

Streamer streamer = new(){
    Nombre = "Amazon Prime",
    Url = "https://www.primevideo.com"
};

dbContext!.Streamers!.Add(streamer);

await dbContext.SaveChangesAsync();

var movies = new List<Video>
{
    new Video
    {
     Nombre = "Mad Max",
     StreamerId = 1
    },
    new Video
    {
        Nombre = "El señor de los anillos",
        StreamerId = streamer.Id
    },
    new Video
    {
        Nombre = "Crepusculo",
        StreamerId = streamer.Id
    },
    new Video { 
        Nombre="Manuelita",
        StreamerId = streamer.Id
    }
};

await dbContext.AddRangeAsync(movies);

await dbContext.SaveChangesAsync();

