using Microsoft.Extensions.DependencyInjection;
using RJMR.Core.Application.Interfaces;
using RJMR.Core.Application.Mappings;
using RJMR.Core.Application.Services;
using System.Reflection;

namespace RJMR.Core.Application
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton(MappingsProfile.GetMapper());
            services.AddScoped<IPermissionTypeApplication, PermissionTypeApplication>();
            services.AddScoped<IPermissionApplication, PermissionApplication>();
            return services;
        }
    }
}