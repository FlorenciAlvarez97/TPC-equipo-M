USE master;
GO

-- Crear la base solamente si todavía no existe.
IF DB_ID(N'CALLCENTER_DB') IS NULL
BEGIN
    CREATE DATABASE CALLCENTER_DB;
END;
GO

USE CALLCENTER_DB;
GO

IF OBJECT_ID(N'dbo.Prioridades', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Prioridades
    (
        Id INT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_Prioridades PRIMARY KEY,

        Nombre NVARCHAR(50) NOT NULL,

        Nivel INT NOT NULL
    );
END;
GO

IF NOT EXISTS (
    SELECT 1
    FROM dbo.Prioridades
    WHERE Nombre = N'Baja'
)
BEGIN
    INSERT INTO dbo.Prioridades (Nombre, Nivel)
    VALUES (N'Baja', 1);
END;

IF NOT EXISTS (
    SELECT 1
    FROM dbo.Prioridades
    WHERE Nombre = N'Media'
)
BEGIN
    INSERT INTO dbo.Prioridades (Nombre, Nivel)
    VALUES (N'Media', 2);
END;

IF NOT EXISTS (
    SELECT 1
    FROM dbo.Prioridades
    WHERE Nombre = N'Alta'
)
BEGIN
    INSERT INTO dbo.Prioridades (Nombre, Nivel)
    VALUES (N'Alta', 3);
END;
GO

-- Comprobar los datos guardados.
SELECT Id, Nombre, Nivel
FROM dbo.Prioridades
ORDER BY Nivel;