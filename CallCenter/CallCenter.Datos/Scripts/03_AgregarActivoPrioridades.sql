USE CALLCENTER_DB;
GO

IF COL_LENGTH('dbo.Prioridades', 'Activo') IS NULL
BEGIN
    ALTER TABLE dbo.Prioridades
    ADD Activo BIT NOT NULL
        CONSTRAINT DF_Prioridades_Activo DEFAULT (1);
END;
GO

SELECT Id, Nombre, Nivel, Activo
FROM dbo.Prioridades
ORDER BY Nivel, Id;