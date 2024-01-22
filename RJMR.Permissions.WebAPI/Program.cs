using Asp.Versioning.ApiExplorer;
using RJMR.Core.Application;
using RJMR.Infrastructure.Persistence;
using RJMR.Infrastructure.Repository;
using RJMR.Permissions.WebAPI.Modules.Swagger;
using RJMR.Permissions.WebAPI.Modules.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureLayerPersistence(builder.Configuration);
builder.Services.AddInfrastructureLayerRepository();

builder.Services.AddApplicationLayer();

builder.Services.AddversioningExtension();
builder.Services.AddSwaggerExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
