
USE CALLCENTER_DB;
GO

IF OBJECT_ID('dbo.HistorialIncidencia', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.HistorialIncidencia
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,

        IdIncidencia INT NOT NULL,

        Fecha DATETIME NOT NULL DEFAULT GETDATE(),

        IdUsuario INT NOT NULL,

        Comentario VARCHAR(1000) NOT NULL,

        IdEstadoResultante INT NOT NULL,

        CONSTRAINT FK_Historial_Incidencias
            FOREIGN KEY (IdIncidencia)
            REFERENCES dbo.Incidencias(Id),

        CONSTRAINT FK_Historial_Usuarios
            FOREIGN KEY (IdUsuario)
            REFERENCES dbo.Usuarios(Id),

        CONSTRAINT FK_Historial_Estados
            FOREIGN KEY (IdEstadoResultante)
            REFERENCES dbo.EstadosIncidencia(Id)
    );
END;
GO

SELECT *
FROM dbo.HistorialIncidencia;
