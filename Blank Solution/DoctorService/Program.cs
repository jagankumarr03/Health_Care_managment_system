using Microsoft.EntityFrameworkCore;
using DoctorService.Data;
using DoctorService.Repositories;
using DoctorService.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace DoctorService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DB CONNECTION

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString(
                        "DefaultConnection")));

            // DEPENDENCY INJECTION

            builder.Services.AddScoped<
                IDoctorRepository,
                DoctorRepository>();

            builder.Services.AddScoped<
                IDoctorService,
                DoctorServiceManager>();

            // JWT AUTHENTICATION

            builder.Services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme)

            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,

                    ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                    ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                    IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]))
                };
            });

            // AUTHORIZATION

            builder.Services.AddAuthorization();

            // CONTROLLERS

            builder.Services.AddControllers();

            // SWAGGER

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // SWAGGER

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // AUTHENTICATION

            app.UseAuthentication();

            // AUTHORIZATION

            app.UseAuthorization();

            // MAP CONTROLLERS

            app.MapControllers();

            app.Run();
        }
    }
}