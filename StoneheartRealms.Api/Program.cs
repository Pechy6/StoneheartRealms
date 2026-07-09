using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Services.Interfaces.Dwarf;
using StoneheartRealms.Services.Interfaces.Job;
using StoneheartRealms.Services.Services;
using StoneheartRealms.Services.Services.Job;
using StoneheartRealms.Services.Services.Needs;
using StoneheartRealms.Services.Services.Needs.Sleep;
using StoneheartRealms.Services.Services.Production;
using StoneheartRealms.Services.Services.Resources;
using StoneheartRealms.Services.Services.States.Dwarves;
using StoneheartRealms.Services.Services.StorageManager;
using StoneheartRealms.Services.Services.TickSystem;
using IResourceService = StoneheartRealms.Services.Services.Resources.IResourceService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DI 
builder.Services.AddScoped<INeedDecayService, NeedDecayService>();
builder.Services.AddScoped<INeedRecoveryService, NeedRecoveryService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<ITickService, TickService>();
builder.Services.AddScoped<IDwarfService, DwarfService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobProduction, JobProduction>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<IDwarfStateService, DwarfStateService>();
builder.Services.AddScoped<ISleepService, SleepService>();

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
