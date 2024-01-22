using RJMR.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Infrastructure.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPermissionTypeRepository PermissionTypes { get; }

        public IPermissionRepository Permissions { get; }

        public UnitOfWork(IPermissionTypeRepository permissionTypes, IPermissionRepository permissions)
        {
            PermissionTypes = permissionTypes;
            Permissions = permissions;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
