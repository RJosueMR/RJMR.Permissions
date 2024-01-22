using AutoMapper;
using RJMR.Core.Application.Interfaces;
using RJMR.Core.Application.Wrapper;
using RJMR.Core.Domain;
using RJMR.Infrastructure.Repository.Interface;
using RJMR.Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Core.Application.Services
{
    public class PermissionTypeApplication : IPermissionTypeApplication
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;
        private readonly IMapper _mapper;

        public PermissionTypeApplication(IPermissionTypeRepository permissionTypeRepository, IMapper mapper)
        {
            _permissionTypeRepository = permissionTypeRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> InsertAsync(PermissionTypeDTO permissionTypeDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> UpdateAsync(PermissionTypeDTO permissionTypeDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<PermissionTypeDTO>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<PermissionTypeDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<PermissionTypeDTO>>();
            try
            {
                var permissionTypes = await _permissionTypeRepository.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<PermissionTypeDTO>>(permissionTypes);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                throw;
            }
            return response;
        }
    }
}
