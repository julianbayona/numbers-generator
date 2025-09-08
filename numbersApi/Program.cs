// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
using numbersApi.Logic;
namespace numbersApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    

    public class Program
    {
        static void Main()
    {
        int iterations = 100;
        double minValue = 0;
        double maxValue = 1;

        Console.WriteLine("=== Generación de Números Pseudoaleatorios ===");

        // 1. Método de Cuadrados Medios
        Console.WriteLine("\n--- Cuadrados Medios ---");
        int seedMean = 2222; // Semilla inicial
        for (int i = 0; i < iterations; i++)
        {
            var result = MeanSquaresGenerator.MakeIteration(seedMean);
            seedMean = (int)result[3]; // La extracción se usa como nueva semilla
            Console.WriteLine($"Iteración {i + 1}: Xi={result[0]}, Cuadrado={result[1]}, Ri={result[4]}");
        }

        // 2. Método de Congruencia Lineal
        Console.WriteLine("\n--- Congruencia Lineal ---");
        int x0 = 3;
        int a = 15;
        int c = 9;
        int m = 1024;
        var linearTable = LinearCongruenceGenerator.CalculateTable(x0, a, c, m, iterations, minValue, maxValue);
        foreach (var row in linearTable)
        {
            Console.WriteLine($"Iteración {row[0]}: Xi={row[1]}, Ri={row[2]}, Ni={row[3]}");
        }

        // 3. Método de Congruencia Multiplicativa
        Console.WriteLine("\n--- Congruencia Multiplicativa ---");
        int x0m = 5;
        int t = 27;
        int g = 65536;
        var multiplicativeTable = MultiplicativeCongruenceGenerator.CalculateMethod(x0m, t, g, iterations, minValue, maxValue);
        foreach (var row in multiplicativeTable)
        {
            Console.WriteLine($"Iteración {row[0]}: Xi={row[1]}, Ri={row[2]}, Ni={row[3]}");
        }
    }
}
}