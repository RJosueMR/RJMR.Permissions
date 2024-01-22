using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace RJMR.Permissions.WebAPI.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            return services;
        }
    }
}
