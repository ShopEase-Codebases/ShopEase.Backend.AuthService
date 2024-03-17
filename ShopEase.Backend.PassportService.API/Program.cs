using Microsoft.EntityFrameworkCore;
using ShopEase.Backend.PassportService.Application.Helpers;
using ShopEase.Backend.PassportService.Persistence;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Application Settings
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// Register Application DB Context
var connectionString = builder.Configuration.GetConnectionString("ShopEaseDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Registers all the Concrete implementations as all of its interfaces
builder.Services
            .Scan(selector => selector
                    .FromAssemblies(
                            ShopEase.Backend.PassportService.Infrastructure.AssemblyReference.Assembly, 
                            ShopEase.Backend.PassportService.Persistence.AssemblyReference.Assembly)
                    .AddClasses(false)
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
