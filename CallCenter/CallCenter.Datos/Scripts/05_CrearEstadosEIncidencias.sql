
USE CALLCENTER_DB;
GO

IF OBJECT_ID('dbo.EstadosIncidencia', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.EstadosIncidencia
    (
        Id INT NOT NULL PRIMARY KEY,
        Nombre VARCHAR(50) NOT NULL UNIQUE
    );
END;
GO


IF NOT EXISTS (SELECT 1 FROM dbo.EstadosIncidencia)
BEGIN
    INSERT INTO dbo.EstadosIncidencia (Id, Nombre)
    VALUES
        (1, 'Abierto'),
        (2, 'Asignado'),
        (3, 'En Análisis'),
        (4, 'Resuelto'),
        (5, 'Cerrado'),
        (6, 'Reabierto');
END;
GO

SELECT Id, Nombre
FROM dbo.EstadosIncidencia
ORDER BY Id;


IF OBJECT_ID('dbo.Incidencias', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Incidencias
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Numero INT NOT NULL UNIQUE,
        FechaAlta DATETIME NOT NULL DEFAULT GETDATE(),
        FechaUltimaModificacion DATETIME NULL,

        Descripcion VARCHAR(1000) NOT NULL,
        Resolucion VARCHAR(1000) NULL,
        ComentarioCierre VARCHAR(1000) NULL,

        IdCliente INT NOT NULL,
        IdTipoIncidencia INT NOT NULL,
        IdPrioridad INT NOT NULL,
        IdEstado INT NOT NULL DEFAULT 1,

        IdUsuarioCreador INT NOT NULL,
        IdUsuarioAsignado INT NOT NULL,
        IdUsuarioUltimaModificacion INT NULL,

        CONSTRAINT FK_Incidencias_Clientes
            FOREIGN KEY (IdCliente) REFERENCES dbo.Clientes(Id),

        CONSTRAINT FK_Incidencias_Tipos
            FOREIGN KEY (IdTipoIncidencia) REFERENCES dbo.TiposIncidencia(Id),

        CONSTRAINT FK_Incidencias_Prioridades
            FOREIGN KEY (IdPrioridad) REFERENCES dbo.Prioridades(Id),

        CONSTRAINT FK_Incidencias_Estados
            FOREIGN KEY (IdEstado) REFERENCES dbo.EstadosIncidencia(Id),

        CONSTRAINT FK_Incidencias_Creador
            FOREIGN KEY (IdUsuarioCreador) REFERENCES dbo.Usuarios(Id),

        CONSTRAINT FK_Incidencias_Asignado
            FOREIGN KEY (IdUsuarioAsignado) REFERENCES dbo.Usuarios(Id),

        CONSTRAINT FK_Incidencias_UltimaModificacion
            FOREIGN KEY (IdUsuarioUltimaModificacion) REFERENCES dbo.Usuarios(Id)
    );
END;
GO
