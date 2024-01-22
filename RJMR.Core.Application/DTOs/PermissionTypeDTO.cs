using System;
using System.Collections.Generic;

namespace RJMR.Core.Domain;

public partial class PermissionTypeDTO
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;
}
