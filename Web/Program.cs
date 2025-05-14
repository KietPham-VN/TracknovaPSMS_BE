using System.Text;
using Application.Helpers.Implementations;
using Application.Helpers.Interfaces;
using Application.Repositories.Implementations;
using Application.Repositories.Interfaces;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Domain.Abstractions;
using DotNetEnv;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructures.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Web.ActionFilters;
using Web.Middlewares;

// 👇 Load environment variables from .env
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// ✅ Load .env variables safely
var dbConnection = Environment.GetEnvironmentVariable("DB_CONNECTION")
    ?? throw new InvalidOperationException("DB_CONNECTION is missing from .env");

var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
    ?? throw new InvalidOperationException("JWT_KEY is missing from .env");

var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
    ?? "tracknova";

var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
    ?? "tracknova_users";

// ✅ Register DbContext using connection string from .env
builder.Services.AddDbContext<IApplicationDbContext, TracknovaContext>(options =>
    options.UseMySql(dbConnection, ServerVersion.Parse("8.0.42-mysql")));

// ✅ Add services & DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtHelper, JwtHelper>();

// ✅ Add FluentValidation
builder.Services
    .AddFluentValidationAutoValidation()
    .AddValidatorsFromAssemblyContaining<UserRegisterRequestValidator>();

// ✅ Add authentication (JWT)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

// ✅ Add Swagger with JWT support
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Tracknova API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập token theo dạng: Bearer {your token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

// ✅ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();