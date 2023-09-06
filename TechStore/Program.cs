using Microsoft.EntityFrameworkCore;
using TechStore.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connStr = builder.Configuration.GetConnectionString("DefaultConnection")!;
    options.UseSqlServer(connStr);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
