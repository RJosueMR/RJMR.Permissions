using RJMR.Core.Application.Wrapper;
using RJMR.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Core.Application.Interfaces
{
    public interface IPermissionTypeApplication
    {
        Task<Response<bool>> InsertAsync(PermissionTypeDTO permissionTypeDTO);
        Task<Response<bool>> UpdateAsync(PermissionTypeDTO permissionTypeDTO);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<PermissionTypeDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<PermissionTypeDTO>>> GetAllAsync();
    }
}
