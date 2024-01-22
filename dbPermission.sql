CREATE DATABASE dbPermission
GO

USE dbPermission
GO

CREATE TABLE PermissionType (
	Id INTEGER IDENTITY,
	Descripcion TEXT NOT NULL,
	PRIMARY KEY (Id)
)
GO

CREATE TABLE Permission (
	Id INTEGER IDENTITY,
	NombreEmpleado TEXT NOT NULL,
	ApellidoEmpleado TEXT NOT NULL,
	TípoPermiso INTEGER NOT NULL,
	FechaPermiso DATE NOT NULL,
	PRIMARY KEY(Id),
	CONSTRAINT fk_permissiontype_permission FOREIGN KEY(TípoPermiso) REFERENCES PermissionType(Id)
)
GO

-- Fill data for Permission Types
INSERT INTO PermissionType VALUES('Vacaciones Anuales'),('Permiso por Enfermedad'),('Permiso por Asuntos Personales'),
	('Día de Descanso Compensatorio'),('Permiso por Maternidad/Paternidad')
GO


-- Stored Procedures for PermissionType
CREATE PROCEDURE sp_insert_permission_type (
	@descripcion TEXT
)
AS
BEGIN
	INSERT INTO PermissionType VALUES (@descripcion)
END
GO

CREATE PROCEDURE sp_update_permission_type (
	@id INTEGER,
	@descripcion TEXT
)
AS
BEGIN
	UPDATE PermissionType SET Descripcion = @descripcion
	WHERE Id = @id
END
GO

CREATE PROCEDURE sp_delete_permission_type (
	@id INTEGER
)
AS
BEGIN
	DELETE FROM PermissionType WHERE Id = @id
END
GO

CREATE PROCEDURE sp_get_all_permission_types
AS
BEGIN
	SELECT Id, Descripcion
	FROM PermissionType
END
GO

CREATE PROCEDURE sp_get_permission_type_by_id (
	@id INTEGER
)
AS
BEGIN
	SELECT Id, Descripcion
	FROM PermissionType
	WHERE Id = @id
END
GO


-- Stored Procedures for Permission
CREATE PROCEDURE sp_insert_permission (
	@mombreEmpleado TEXT,
	@apellidoEmpleado TEXT,
	@típoPermiso INTEGER,
	@fechaPermiso DATE
)
AS
BEGIN
	INSERT INTO Permission VALUES (@mombreEmpleado, @apellidoEmpleado, @típoPermiso, @fechaPermiso)
END
GO

CREATE PROCEDURE sp_update_permission (
	@id INTEGER,
	@mombreEmpleado TEXT,
	@apellidoEmpleado TEXT,
	@típoPermiso INTEGER,
	@fechaPermiso DATE
)
AS
BEGIN
	UPDATE Permission
	SET NombreEmpleado = @mombreEmpleado, 
		ApellidoEmpleado = @apellidoEmpleado,
		TípoPermiso = @típoPermiso,
		FechaPermiso = @fechaPermiso
	WHERE Id = @id
END
GO

CREATE PROCEDURE sp_delete_permission (
	@id INTEGER
)
AS
BEGIN
	DELETE FROM Permission WHERE Id = @id
END
GO

CREATE PROCEDURE sp_get_all_permissions
AS
BEGIN
	SELECT P.Id, P.NombreEmpleado, P.ApellidoEmpleado, P.TípoPermiso, PT.Descripcion, P.FechaPermiso
	FROM Permission AS P INNER JOIN PermissionType PT ON P.TípoPermiso = PT.Id
END
GO

CREATE PROCEDURE sp_get_all_permissions_with_pagination (
	@pageNumber INTEGER = 1,
	@maxRecords INTEGER
)
AS
BEGIN
	SELECT P.Id, P.NombreEmpleado, P.ApellidoEmpleado, P.TípoPermiso, PT.Descripcion, P.FechaPermiso
	FROM Permission AS P INNER JOIN PermissionType PT ON P.TípoPermiso = PT.Id
	ORDER BY P.Id
	OFFSET (@pageNumber-1)*@maxRecords ROWS
    FETCH NEXT @maxRecords ROWS ONLY
END
GO

CREATE PROCEDURE sp_get_permission_by_id (
	@id INTEGER
)
AS
BEGIN
	SELECT P.Id, P.NombreEmpleado, P.ApellidoEmpleado, P.TípoPermiso, PT.Descripcion, P.FechaPermiso
	FROM Permission AS P INNER JOIN PermissionType PT ON P.TípoPermiso = PT.Id
	WHERE P.Id = @id
END
GO