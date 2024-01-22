using RJMR.Core.Application.Wrapper;
using RJMR.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Core.Application.Interfaces
{
    public interface IPermissionApplication
    {
        Task<Response<bool>> InsertAsync(PermissionDTO permissionDTO);
        Task<Response<bool>> UpdateAsync(PermissionDTO permissionDTO);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<PermissionDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<PermissionDTO>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<PermissionDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    }
}
