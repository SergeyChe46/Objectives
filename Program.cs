using NLog;
using Objectives.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup()
    .LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

builder.Services.AddSwaggerGen();
builder.Services.DatabaseService(configuration);
builder.Services.ConfigureJWT(configuration);
builder.Services.DIServices();
builder.Services.CorsServices();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(
    options => options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
