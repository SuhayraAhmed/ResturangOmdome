using Microsoft.EntityFrameworkCore;
using ResturangOmdome.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Databas
builder.Services.AddDbContext<APIDbContext>(options =>
    options.UseSqlite("Data Source=restaurangeraAPI.db"));

// Standardtjänster
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
