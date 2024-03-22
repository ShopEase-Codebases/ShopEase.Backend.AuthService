using ShopEase.Backend.Common;
using ShopEase.Backend.PassportService.API;
using ShopEase.Backend.PassportService.Application;
using ShopEase.Backend.PassportService.Infrastructure;
using ShopEase.Backend.PassportService.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
            .AddApi()
            .AddApplication()
            .AddInfrastructure(builder.Configuration)
            .AddPersistence(builder.Configuration);

builder.Services.AddCQRSMessaging(ShopEase.Backend.PassportService.Application.AssemblyReference.Assembly);

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
