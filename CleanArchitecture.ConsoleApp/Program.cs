﻿using CleanArchitecture.Data.Persistence;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

StreamerDbContext dbContext = new();
await ImprimeDigitos2();
//await ImprimeDigitos();
//await MultipleEntitiesQuery();
//await AddNewDirectorWithVideo();
//await AddNewActorWithVideo();
//await AddNewStreamerWhithVideoId();
//await AddNewStreamerWhithVideo();
//await streamingNoTracking();
//await QueryLinQ();
//await QueryMethods();
//await QueryFilter();
//await AddNewRecords();
//QueryStreaming();

Console.WriteLine($"Precione cualquier tecla para terminar el programa");
Console.ReadKey();


async Task ImprimeDigitos2()
{
    int[] arreglo;

    // Pedir al usuario que ingrese los valores del arreglo
    Console.Write("Ingrese el tamaño del arreglo: ");
    int n = int.Parse(Console.ReadLine());
    arreglo = new int[n];

    for (int i = 0; i < n; i++)
    {
        Console.Write("Ingrese el valor para el elemento " + i + ": ");
        arreglo[i] = int.Parse(Console.ReadLine());
    }

    // Encontrar el número máximo en el arreglo
    int maximo = arreglo[0];
    for (int i = 1; i < n; i++)
    {
        if (arreglo[i] > maximo)
        {
            maximo = arreglo[i];
        }
    }

    // Imprimir el número máximo
    Console.WriteLine("El número máximo es " + maximo);
}

async Task ImprimeDigitos()
{

    int[] Numeros = new int[10];

    Console.WriteLine("Por favor, ingrese 10 números enteros del 1 al 5:");

    // Pedir al usuario que ingrese los valores del arreglo
    for (int i = 0; i < Numeros.Length; i++)
    {
        Console.Write("Número " + (i + 1) + ": ");
        int num = int.Parse(Console.ReadLine());
        while (num < 1 || num > 5)
        {
            Console.WriteLine("El número debe estar entre 1 y 5. Por favor, ingrese un número válido.");
            Console.Write("Número " + (i + 1) + ": ");
            num = int.Parse(Console.ReadLine());
        }
        Numeros[i] = num;
    }

    Console.WriteLine("Histograma del array myArray:");

    // Imprimir un asterisco (*) por cada ocurrencia de cada número en el arreglo
    for (int i = 1; i <= 5; i++)
    {
        Console.Write(i + ": ");
        for (int j = 0; j < Numeros.Length; j++)
        {
            if (Numeros[j] == i)
            {
                Console.Write("*");
            }
        }
        Console.WriteLine();
    }


}

async Task MultipleEntitiesQuery()
{
   // var videoWithActores = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);

    //var actor = await dbContext!.Actores!.Select(q => q.Nombre).ToListAsync();

    var videoWithDirector = await dbContext!.Videos!
                            .Where(q => q.Director != null)
                            .Include(q => q.Director)
                            .Select(q => 
                            new {
                                 Director_Nombre_Completo = $"{q.Director!.Nombre} {q.Director!.Apellido}" ,
                                 Movie = q.Nombre
                                }
                            ).ToListAsync();



    foreach (var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_Nombre_Completo}");
    }

}
async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1
    };
    await dbContext.AddAsync( director );
    await dbContext.SaveChangesAsync();
}
async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();


    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext.AddAsync( videoActor );
    await dbContext.SaveChangesAsync();


}
async Task AddNewStreamerWhithVideoId()
{

    var batmanForever = new Video()
    {
        Nombre = "Batman Forever",
        StreamerId = 4
    };

    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();

}
async Task AddNewStreamerWhithVideo()
{
    var pantaya = new Streamer
    {
        Nombre = "Pantaya"
    };

    var hungerGames = new Video()
    {
        Nombre = "Hunger Games",
        Streamer = pantaya
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();

}
async Task streamingNoTracking() 
{ 
    var streamingWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);

    var streamingNoTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);


    streamingWithTracking!.Nombre = "Netflix Super";
    streamingNoTracking!.Nombre = "Amazon Plus";

    await dbContext!.SaveChangesAsync();

}
async Task QueryLinQ(){

    Console.WriteLine("Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();

    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i!.Nombre!, $"%{streamerNombre}%")
                           select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

}
async Task QueryMethods()
{
    var streamer = dbContext!.Streamers!;

    var firstAsync = await streamer.Where(y => y!.Nombre!.Contains("a")).FirstAsync();

    var firstOrDefaultAsync = await streamer.Where(y => y!.Nombre!.Contains("a")).FirstOrDefaultAsync();

    var firstOrDefaultAsync2 = await streamer.FirstOrDefaultAsync(y => y!.Nombre!.Contains("a"));

    var singleAsync = await streamer.Where(y => y.Id == 1).SingleAsync();

    var singleOrDefaultAsync = await streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();

    var resultado = await streamer.FindAsync(1);

}
async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compañia de streaming: ");
    var streamNombre = Console.ReadLine();

    var streamers = await dbContext!.Streamers!.Where(x => x!.Nombre!.Equals(streamNombre)).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

    //var streamePartialResults = await dbContext!.Streamers!.Where(x => x!.Nombre!.Contains(streamNombre)).ToListAsync();

    var streamePartialResults = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x!.Nombre!, $"%{streamNombre}%")).ToListAsync();

    foreach (var streamer in streamePartialResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }


}
void QueryStreaming()
{
    var Streamers = dbContext!.Streamers!.ToList();

    foreach (var Streamer in Streamers)
    {

        Console.WriteLine($"{Streamer.Id} - {Streamer.Nombre}");

    }

}
async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "www.Disney.com"
    };

    dbContext!.Streamers!.Add(streamer);
    await dbContext.SaveChangesAsync();


    var movies = new List<Video>
{
    new Video
    {
        Nombre = "La cenicienta",
        StreamerId = streamer.Id,
    },


    new Video
    {
        Nombre = "1001 Dalmatas",
        StreamerId = streamer.Id,
    },

    new Video
    {
        Nombre = "El Jorobado De Notradame",
        StreamerId = streamer.Id,
    },

    new Video
    {
        Nombre = "Star Wars",
        StreamerId = streamer.Id,
    },

};

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();


}