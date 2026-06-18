using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Services.Interfaces.Dwarf;
using StoneheartRealms.Services.Interfaces.Job;
using StoneheartRealms.Services.Services;
using StoneheartRealms.Services.Services.Job;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IDwarfService, DwarfService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContext<StoneheartRealmsDbContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
