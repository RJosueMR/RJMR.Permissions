using Asp.Versioning;

namespace RJMR.Permissions.WebAPI.Modules.Versioning
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddversioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
                .AddApiExplorer(options =>
                {
                    options.SubstituteApiVersionInUrl = true;
                });
            return services;
        }
    }
}
