using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Interfaces;
using TechStore.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connStr = builder.Configuration.GetConnectionString("DefaultConnection")!;
    options.UseSqlServer(connStr);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
