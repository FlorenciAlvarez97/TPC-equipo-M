USE CALLCENTER_DB;
GO
IF OBJECT_ID('dbo.TiposIncidencia', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.TiposIncidencia (
        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Nombre varchar(100) NOT NULL UNIQUE,
        Descripcion varchar(300) NULL,
        Activo bit NOT NULL DEFAULT 1
    );
END
GO
IF NOT EXISTS (SELECT 1 FROM dbo.TiposIncidencia)
BEGIN
    INSERT INTO dbo.TiposIncidencia (Nombre, Descripcion) VALUES
    ('Consulta', 'Consulta general de un cliente'),
    ('Reclamo', 'Reclamo por un servicio o producto'),
    ('Soporte tecnico', 'Problema tecnico a resolver'),
    ('Facturacion', 'Consultas o errores de facturacion');
END
GO