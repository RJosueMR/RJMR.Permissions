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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IDbPermissionContext _context;

        public PermissionRepository(IDbPermissionContext context)
        {
            this._context = context;
        }

        public async Task<bool> InsertAsync(Permission permission)
        {
            await _context.AddAsync(permission);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Permission permission)
        {
            var current = await _context.Permissions.FindAsync(permission.Id);
            if (current != null)
            {
                _context.Permissions.Entry(current).CurrentValues.SetValues(permission);
                return await _context.SaveChangesAsync() > 0;

            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var current = await _context.Permissions.FindAsync(id);
            if (current != null)
            {
                _context.Permissions.Remove(current);
                return await _context.SaveChangesAsync() > 0;

            }
            return await Task.FromResult(false);
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await _context.Permissions.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task<IEnumerable<Permission>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _context.Permissions
                .OrderBy(s => s.Id)
                .Skip((pageNumber - 1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Permissions.CountAsync();
        }
    }
}
