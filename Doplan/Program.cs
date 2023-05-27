using Doplan.Data.Context;
using Doplan.Data.Entities;
using Doplan.Data.Repositories;
using Doplan.Interfaces.Repositories;
using Doplan.Interfaces.Services;
using Doplan.Services;
using Doplan.Services.Registration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DoplanDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// For Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DoplanDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ITaskToDoRepository, TaskToDoRepository>();
builder.Services.AddScoped<ITaskToDoService, TaskToDoService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddMapper();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowedOrigins = "_myAllowedOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowedOrigins,
                          builder =>
                          {
                              builder.AllowAnyOrigin()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

var logFile = "D:\\University\\Doplan\\LogFiles\\LogInfoDoplan.txt";
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .Enrich.FromLogContext()
    .WriteTo.File(logFile,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

// Додавання Serilog до фабрики логера
builder.Logging.AddSerilog();

var app = builder.Build();

app.UseCors(MyAllowedOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
