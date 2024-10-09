using Microsoft.EntityFrameworkCore;
using RangoAgil.API.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RangoDbContext>(
    o => o.UseSqlite(builder.Configuration.GetConnectionString("RangoDbConStr"))
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/rangos/{numero}/{nome}", (int numero, string nome) => {
    return $"{nome} - {numero}";
});

app.MapGet("/rangos/{numero}", (int numero) => {
    return $"Número: {numero}";
});

app.Run();
