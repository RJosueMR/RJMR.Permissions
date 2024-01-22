using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RJMR.Permissions.WebAPI.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateDescriptionForApiVersion(description));
            }
        }

        static OpenApiInfo CreateDescriptionForApiVersion(ApiVersionDescription versionDescription)
        {
            var info = new OpenApiInfo()
            {
                Version = versionDescription.ApiVersion.ToString(),
                Title = "Permission WebAPI",
                Description = "WebAPI desarrollada para la gestión de permisos.",
                Contact = new OpenApiContact()
                {
                    Name = "Robert Josué Mendoza Rojas",
                    Email = "jomero0708@gmail.com",
                    Url = new Uri("https://github.com/RJosueMR")
                }
            };
            if (versionDescription.IsDeprecated)
            {
                info.Description += "\n Esta versión ha quedado obsoleta.";
            }
            return info;
        }
    }
}
