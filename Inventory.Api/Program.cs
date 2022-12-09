using Inventory.Core;
using Inventory.Core.Domain.DTOs;
using Inventory.Shared.Swagger;
using MediatR;
using Shared.Core.Exceptions;
using System.Reflection;


IConfiguration configuration;
string connectionString;
var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.Development.json")
        .AddEnvironmentVariables()
        .Build();
    connectionString = configuration["ConnectionStrings:DBConnection"];
}
else
{
    configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();
    connectionString = configuration["ConnectionStrings:DBConnection"];
}
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddErrorHandling();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddDomainCore();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactDevClient",
                 builder =>
                 {
                     builder
                     .WithOrigins(configuration["origins"])
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                 });
    options.AddPolicy("AllowReactClient",
      builder =>
      {
          builder
          .WithOrigins(configuration["origins"])
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
});

builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(SalesResponse).Assembly);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

string? connStr = builder.Environment.IsProduction() ? builder.Configuration.GetConnectionString
           ("cloudUrl") : builder.Configuration.GetConnectionString("default");

builder.Services.AddDb(connectionString );


var app = builder.Build();





// Configure the HTTP request pipeline.

app.UseCors("AllowReactDevClient");
app.UseCors("AllowReactClient");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "v1 Active");

app.UseDbMigration();

app.UseErrorHandling();

app.UseAuthorization();

app.MapControllers();

app.Run();
