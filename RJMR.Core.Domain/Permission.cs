using System;
using System.Collections.Generic;

namespace RJMR.Core.Domain;

public partial class Permission
{
    public int Id { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string ApellidoEmpleado { get; set; } = null!;

    public int TípoPermiso { get; set; }

    public DateOnly FechaPermiso { get; set; }

    public virtual PermissionType TípoPermisoNavigation { get; set; } = null!;
}
