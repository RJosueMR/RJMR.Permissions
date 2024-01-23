using AutoMapper;
using RJMR.Core.Application.Interfaces;
using RJMR.Core.Application.Wrapper;
using RJMR.Core.Domain;
using RJMR.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJMR.Core.Application.Services
{
    public class PermissionApplication : IPermissionApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermissionApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> InsertAsync(PermissionDTO permissionDTO)
        {
            var response = new Response<bool>();
            try
            {
                var permission = _mapper.Map<Permission>(permissionDTO);
                response.Data = await _unitOfWork.Permissions.InsertAsync(permission);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                throw;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(PermissionDTO permissionDTO)
        {
            var response = new Response<bool>();
            try
            {
                var permission = _mapper.Map<Permission>(permissionDTO);
                response.Data = await _unitOfWork.Permissions.UpdateAsync(permission);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                throw;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _unitOfWork.Permissions.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                throw;
            }
            return response;
        }

        public async Task<Response<PermissionDTO>> GetByIdAsync(int id)
        {
            var response = new Response<PermissionDTO>();
            try
            {
                var permission = await _unitOfWork.Permissions.GetByIdAsync(id);
                response.Data = _mapper.Map<PermissionDTO>(permission);
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

        public async Task<Response<IEnumerable<PermissionDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<PermissionDTO>>();
            try
            {
                var permissions = await _unitOfWork.Permissions.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
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

        public async Task<ResponsePagination<IEnumerable<PermissionDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<PermissionDTO>>();
            try
            {
                var permissions = await _unitOfWork.Permissions.GetAllWithPaginationAsync(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
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
