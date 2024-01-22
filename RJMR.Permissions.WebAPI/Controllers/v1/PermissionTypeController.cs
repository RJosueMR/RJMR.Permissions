using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RJMR.Core.Application.Interfaces;

namespace RJMR.Permissions.WebAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeApplication _permissionTypeApplication;

        public PermissionTypeController(IPermissionTypeApplication permissionTypeApplication)
        {
            _permissionTypeApplication = permissionTypeApplication;
        }

        [HttpGet("ObtenerTiposPermisos")]
        public async Task<IActionResult> ObtenerTiposPermisos()
        {
            var response = await _permissionTypeApplication.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
