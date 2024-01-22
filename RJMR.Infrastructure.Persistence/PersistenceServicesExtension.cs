    using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RJMR.Infrastructure.Persistence.Data;
using RJMR.Infrastructure.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Infrastructure.Persistence
{
    public static class PersistenceServicesExtension
    {
        public static IServiceCollection AddInfrastructureLayerPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddDbContext<DbPermissionContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("dbPermission"),
                    b => b.MigrationsAssembly(typeof(DbPermissionContext).Assembly.FullName));
            });
            services.AddScoped<IDbPermissionContext, DbPermissionContext>();
            return services;
        }
    }
}
