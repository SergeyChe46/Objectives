using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Objectives.Models;
using Objectives.Models.Security;
using Objectives.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    cfg => cfg.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);

var jwtSettings = builder.Configuration.GetSection("JWTSettings");

// builder.Services
//     .AddAuthentication(opt =>
//     {
//         opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     })
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidateLifetime = true,
//             ValidateIssuerSigningKey = true,
//             ValidIssuer = jwtSettings["validIssuer"],
//             ValidAudience = jwtSettings["validAudience"],
//             IssuerSigningKey = new SymmetricSecurityKey(
//                 Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value)
//             )
//         };
//     });

builder.Services.AddTransient<IObjectiveRepository, ObjectiveRepository>();
builder.Services.AddTransient<IPerformerRepository, PerformerRepository>();

builder.Services.AddCors(c =>
{
    c.AddPolicy(
        "AllowOrigin",
        options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
