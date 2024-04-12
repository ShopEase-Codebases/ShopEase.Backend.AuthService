using ShopEase.Backend.Common;
using ShopEase.Backend.PassportService.API;
using ShopEase.Backend.PassportService.Application;
using ShopEase.Backend.PassportService.Infrastructure;
using ShopEase.Backend.PassportService.Persistence;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
                .AddApi(builder.Configuration)
                .AddShopEaseCommon(ShopEase.Backend.PassportService.Application.AssemblyReference.Assembly)
                .AddPersistence(builder.Configuration)
                .AddInfrastructure(builder.Configuration)
                .AddApplication();
}

{
    var app = builder.Build();

    //if (app.Environment.IsDevelopment())
    //{
    //    app.UseSwagger();
    //    app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopEase PassportService API V1"));
    //}

    app.UseSwagger();
    app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopEase PassportService API V1"));

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseExceptionHandler( _ => { } );

    app.MapControllers();
    app.Run();
}
