using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Services.Interfaces.Dwarf;
using StoneheartRealms.Services.Interfaces.Job;
using StoneheartRealms.Services.Services;
using StoneheartRealms.Services.Services.Job;
using StoneheartRealms.Services.Services.Needs;
using StoneheartRealms.Services.Services.Production;
using StoneheartRealms.Services.Services.StorageManager;
using StoneheartRealms.Services.Services.TickSystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DI 
builder.Services.AddScoped<INeedDecayService, NeedDecayService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<ITickService, TickService>();
builder.Services.AddScoped<IDwarfService, DwarfService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobProduction, JobProduction>();

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
