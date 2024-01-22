using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RJMR.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Infrastructure.Persistence.Interface
{
    public interface IDbPermissionContext
    {
        DbSet<Permission> Permissions { get; set; }
        DbSet<PermissionType> PermissionTypes { get; set; }
        Task<int> SaveChangesAsync();
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
