using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using RJMR.Core.Domain;
using RJMR.Infrastructure.Persistence.Interface;


namespace RJMR.Infrastructure.Persistence.Data;

public partial class DbPermissionContext : DbContext, IDbPermissionContext
{
    public DbPermissionContext(DbContextOptions<DbPermissionContext> options) : base(options)
    {
    }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionType> PermissionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC072E165D45");

            entity.ToTable("Permission");

            entity.Property(e => e.ApellidoEmpleado).HasColumnType("text");
            entity.Property(e => e.NombreEmpleado).HasColumnType("text");

            entity.HasOne(d => d.TípoPermisoNavigation).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.TípoPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_permissiontype_permission");
        });

        modelBuilder.Entity<PermissionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC079473217F");

            entity.ToTable("PermissionType");

            entity.Property(e => e.Descripcion).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity) where TEntity : class
    {
        return base.AddAsync<TEntity>(entity);
    }
}
