using System;
using System.Collections.Generic;

namespace RJMR.Core.Domain;

public partial class PermissionType
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
