﻿using CursoUdemy.Data;
using CursoUdemy.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

//await addNewRecords();

//QueryStreaming();

//await QueryFilter();

//await QueryMethods();

//await QueryLinq();

//await TrackingAndNotTracking();

//await AddNewStreamerWithVideo();

//await AddNewStreamerWithVideoId();

//await AddNewActorWithVideo();

//await addNewDirectorWithVideo();

await MultipleEntitiesQuery();

Console.WriteLine("Presione cualquier tecla para terminar el programa");

Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext.Videos.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);

    var videoWithDirector = await dbContext.Videos
        .Where(video => video.Director != null)
        .Include(x => x.Director)
        .Select(q => new {
            Director_Nombre_Completo = $"{q.Director.Nombre} {q.Director.Apellido}",
            Movie = q.Nombre
         }
        ).ToListAsync();

    foreach ( var video in videoWithDirector)
    {
        Console.WriteLine($"{video.Movie} - {video.Director_Nombre_Completo}");
    }
}

async Task addNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1
    };
    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt",
    };


    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{

    var batman = new Video
    {
        Nombre = "Batman",
        StreamerId = 4
    };

    await dbContext.AddAsync(batman);

    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var pantalla = new Streamer
    {
        Nombre = "Pantalla"
    };

    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantalla
    };

    await dbContext.AddAsync(hungerGames);

    await dbContext.SaveChangesAsync();
}

async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await dbContext.Streamers.FirstOrDefaultAsync(x => x.Id == 1);
    //Usando NO Tracking significa que se volatiliza cuando termina la query, no se podra updatear, como pasa mas abajo
    var streamerWithNoTracking = await dbContext.Streamers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTracking.Nombre = "Netflix Super";
    streamerWithNoTracking.Nombre = "Amazon Plus";

    await dbContext.SaveChangesAsync();
}

async Task QueryLinq()
{
    Console.WriteLine("Ingrese");
    var streamerNombre = Console.ReadLine();

    var streamers = await (from i in dbContext.Streamers where EF.Functions.Like(i.Nombre, $"%{streamerNombre}%") select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task QueryMethods()
    {

    var streamer = dbContext.Streamers;

    var streamer1 = await streamer.Where(y => y.Nombre!.Contains("a")).FirstAsync();
    
    var streamer2 = await streamer.Where(y => y.Nombre!.Contains("a")).FirstOrDefaultAsync();

    var streamer3 = await streamer.FirstOrDefaultAsync(y => y.Nombre!.Contains("a"));

    var streamer4 = await streamer.Where(y => y.Id == 1).SingleAsync();
    var streamer5 = await streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();

    var streamer6 = await streamer.FindAsync(1);
}

async Task QueryFilter()
{
    Console.WriteLine($"Ingrese el texto:");
    var streamingName = Console.ReadLine();

    var streamers = await dbContext.Streamers.Where(x => x.Nombre!.Equals(streamingName)).ToListAsync();

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
