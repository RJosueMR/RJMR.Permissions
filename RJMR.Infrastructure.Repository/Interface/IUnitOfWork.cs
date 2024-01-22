using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Infrastructure.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionTypeRepository PermissionTypes { get; }
        IPermissionRepository Permissions { get; }
    }
}
