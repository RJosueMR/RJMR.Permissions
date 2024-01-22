using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RJMR.Infrastructure.Repository.Interface;
using RJMR.Infrastructure.Repository.Repository;

namespace RJMR.Infrastructure.Repository
{
    public static class RepositoryServicesExtension
    {
        public static IServiceCollection AddInfrastructureLayerRepository(this IServiceCollection services)
        {
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
