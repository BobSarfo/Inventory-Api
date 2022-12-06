using Inventory.Core;
using Inventory.Shared.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();




builder.Services.AddRouting(options => options.LowercaseUrls = true);

string connStr = builder.Environment.IsProduction() ? builder.Configuration.GetConnectionString
           ("cloudUrl") : builder.Configuration.GetConnectionString("default");
builder.Services.AddDb(connStr);



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
