using Backend.DTOs;
using Backend.Models;
using Backend.services;
using Backend.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddSingleton<IPersonaServices, PersonaService2>();
builder.Services.AddKeyedSingleton<IPersonaServices, PersonaService>("personaservices");
builder.Services.AddKeyedSingleton<IPersonaServices, PersonaService2>("personaservices2");

builder.Services.AddKeyedSingleton<IRandomServices, RandomService>("randomSingleton");
builder.Services.AddKeyedScoped<IRandomServices, RandomService>("randomScope");
builder.Services.AddKeyedTransient<IRandomServices, RandomService>("randomTrasient");

builder.Services.AddScoped<IPostService, PostService>();
//beer service
builder.Services.AddScoped<IBeerServices, BeerServise> ();

// Entity F.
builder.Services.AddHttpClient<IPostService, PostService>(
    c => c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]));

//Validadores 
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValitator>();
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();

builder.Services.AddDbContext<StoreContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnections"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
