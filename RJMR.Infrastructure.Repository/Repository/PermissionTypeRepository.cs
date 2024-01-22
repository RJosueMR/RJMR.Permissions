using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RJMR.Core.Domain;
using RJMR.Infrastructure.Persistence.Data;
using RJMR.Infrastructure.Persistence.Interface;
using RJMR.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Infrastructure.Repository.Repository
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly IDbPermissionContext _context;

        public PermissionTypeRepository(IDbPermissionContext context)
        {
            this._context = context;
        }

        public async Task<bool> InsertAsync(PermissionType permissionType)
        {
            await _context.AddAsync(permissionType);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(PermissionType permissionType)
        {
            var current = await _context.PermissionTypes.FindAsync(permissionType.Id);
            if (current != null)
            {
                _context.PermissionTypes.Entry(current).CurrentValues.SetValues(permissionType);
                return await _context.SaveChangesAsync() > 0;

            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var current = await _context.PermissionTypes.FindAsync(id);
            if (current != null)
            {
                _context.PermissionTypes.Remove(current);
                return await _context.SaveChangesAsync() > 0;

            }
            return await Task.FromResult(false);
        }

        public async Task<PermissionType> GetByIdAsync(int id)
        {
            return await _context.PermissionTypes.Where(pt => pt.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PermissionType>> GetAllAsync()
        {
            return await _context.PermissionTypes.ToListAsync();
        }

        public async Task<IEnumerable<PermissionType>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
