using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RJMR.Core.Application.Interfaces;
using RJMR.Core.Application.Services;
using RJMR.Core.Domain;

namespace RJMR.Permissions.WebAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionApplication _permissionApplication;

        public PermissionController(IPermissionApplication permissionApplication)
        {
            _permissionApplication = permissionApplication;
        }

        [HttpPost("SolicitarPermiso")]
        public async Task<IActionResult> SolicitarPermiso([FromBody] PermissionDTO permission)
        {
            var response = await _permissionApplication.InsertAsync(permission);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("ModificarPermiso")]
        public async Task<IActionResult> ModificarPermiso([FromBody] PermissionDTO permission)
        {
            var response = await _permissionApplication.UpdateAsync(permission);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("ObtenerPermisos")]
        public async Task<IActionResult> ObtenerPermisos()
        {
            var response = await _permissionApplication.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
