using Backend.services;
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

builder.Services.AddHttpClient<IPostService, PostService>(
    c => c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts"));

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
