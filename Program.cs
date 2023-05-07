using Microsoft.EntityFrameworkCore;
using Objectives.Models;
using Objectives.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(cfg =>
    cfg.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddTransient<IObjectiveRepository, ObjectiveRepository>();
builder.Services.AddTransient<IPerformerRepository, PerformerRepository>();

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
