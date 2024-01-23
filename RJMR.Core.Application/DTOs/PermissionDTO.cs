using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RJMR.Core.Domain;

public partial class PermissionDTO
{
    public int Id { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string ApellidoEmpleado { get; set; } = null!;

    public int TípoPermiso { get; set; }

    [DataType(DataType.Date)]
    public DateTime FechaPermiso { get; set; }
}
