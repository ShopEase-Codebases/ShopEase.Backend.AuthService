﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShopEase.Backend.PassportService.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(
                                    configuration.GetSection("AppSettings:Secret").Value!)),
                            ValidateIssuer = true,
                            ValidIssuer = configuration.GetSection("AppSettings:Issuer").Value,
                            ValidateAudience = false
                        });

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            
            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "ShopEase PassportService API",
                    Description = "ShopEase PassportService combines the Auth Service and the User Service of ShopEase!",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Kaustab Samanta",
                        Email = "scriptsage001@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/kaustab-samanta-b513511a1")
                    }
                });
            });

            return services;
        }
    }
}
