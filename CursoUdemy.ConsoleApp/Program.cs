using CursoUdemy.Data;
using CursoUdemy.Domain;

StreamerDbContext dbContext = new();

//await addNewRecords();

QueryStreaming();

void QueryStreaming()
{
    var streamers = dbContext.Streamers.ToList();

    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task addNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney +",
        Url = "https://www.disneyplus.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
{
    new Video
    {
     Nombre = "Lilo y Stitch",
     StreamerId = streamer.Id
    },
    new Video
    {
        Nombre = "101 Dalmatas",
        StreamerId = streamer.Id
    },
    new Video
    {
        Nombre = "El jorobado caido",
        StreamerId = streamer.Id
    },
    new Video {
        Nombre="Pocahontas",
        StreamerId = streamer.Id
    }
};

    await dbContext.AddRangeAsync(movies);

    await dbContext.SaveChangesAsync();
}
