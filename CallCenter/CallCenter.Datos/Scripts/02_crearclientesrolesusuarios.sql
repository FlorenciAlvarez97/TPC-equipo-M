USE master
GO
IF DB_ID('CALLCENTER_DB') IS NULL CREATE DATABASE CALLCENTER_DB
GO
USE CALLCENTER_DB
GO

IF OBJECT_ID('dbo.Roles') IS NULL
    CREATE TABLE dbo.Roles (
        Id int NOT NULL PRIMARY KEY,
        Nombre varchar(50) NOT NULL UNIQUE
    )
GO
IF NOT EXISTS (SELECT 1 FROM dbo.Roles)
    INSERT INTO dbo.Roles (Id, Nombre) VALUES
        (1, 'Administrador'), (2, 'Telefonista'), (3, 'Supervisor')
GO

IF OBJECT_ID('dbo.Clientes') IS NULL
    CREATE TABLE dbo.Clientes (
        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Nombre varchar(100) NOT NULL,
        Apellido varchar(100) NOT NULL,
        Email varchar(150) NOT NULL,
        Telefono varchar(30) NULL,
        Direccion varchar(200) NULL,
        Activo bit NOT NULL DEFAULT 1
    )
GO

IF OBJECT_ID('dbo.Usuarios') IS NULL
    CREATE TABLE dbo.Usuarios (
        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Nombre varchar(100) NOT NULL,
        NombreUsuario varchar(50) NOT NULL UNIQUE,
        Contrasena varchar(200) NOT NULL,
        IdRol int NOT NULL FOREIGN KEY REFERENCES dbo.Roles(Id),
        Activo bit NOT NULL DEFAULT 1
    )
GO

SELECT Id, Nombre FROM dbo.Roles