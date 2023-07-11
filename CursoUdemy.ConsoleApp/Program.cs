using CursoUdemy.Data;
using CursoUdemy.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

//await addNewRecords();

//QueryStreaming();

await QueryFilter();

Console.WriteLine("Presione cualquier tecla para terminar el programa");

Console.ReadKey();

async Task QueryFilter()
{
    Console.WriteLine($"Ingrese el texto:");
    var streamingName = Console.ReadLine();

    var streamers = await dbContext.Streamers.Where(x => x.Nombre.Equals(streamingName)).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{ streamer.Id} - {streamer.Nombre}");
    }

    //var StreamerPartialResults = await dbContext.Streamers.Where(x => x.Nombre.Contains(streamingName)).ToListAsync();

    var StreamerPartialResults = await dbContext.Streamers.Where(x => EF.Functions.Like(x.Nombre,$"%{streamingName}%" )).ToListAsync();

    foreach (var streamer in StreamerPartialResults) { Console.WriteLine($"{streamer.Nombre} - {streamer.Id}"); }

}


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
