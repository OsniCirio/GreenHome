using GreenHome.Application.Interfaces;
using GreenHome.Application.Services;
using GreenHome.Domain.Entities;
using GreenHome.Infrastructure.Repository;
using GreenHome.Repository;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

var mongoSettings = builder.Configuration
    .GetSection("MongoDbSettings")
    .Get<MongoDbSettings>()!;

builder.Services.AddSingleton<IMongoClient>(_ =>
    new MongoClient(mongoSettings.ConnectionString));

builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(mongoSettings.DatabaseName);
});

builder.Services.AddScoped<IVegetalRepository, VegetalRepository>();
builder.Services.AddScoped<IRegraCultivoRepository, RegraCultivoRepository>();
builder.Services.AddScoped<IDispositivoRepository, DispositivoRepository>();

builder.Services.AddScoped<IVegetalService, VegetalService>();
builder.Services.AddScoped<IRegraCultivoService, RegraCultivoService>();
builder.Services.AddScoped<IDispositivoService, DispositivoService>();

builder.Services.AddScoped<ILeituraSensorRepository, LeituraSensorRepository>();
builder.Services.AddScoped<ITelemetriaService, TelemetriaService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = " Api - Controle de Automação Agricula",
        Version = "v1"
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
