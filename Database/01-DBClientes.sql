IF DB_ID(N'DBClientes') IS NULL
BEGIN
    CREATE DATABASE DBClientes;
END;
GO

USE DBClientes;
GO

IF OBJECT_ID(N'dbo.Clientes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Clientes
    (
        Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Clientes PRIMARY KEY,
        NumeroIdentificacion NVARCHAR(30) NOT NULL,
        Nombres NVARCHAR(100) NOT NULL,
        Apellidos NVARCHAR(100) NOT NULL,
        Email NVARCHAR(150) NOT NULL,
        Telefono NVARCHAR(30) NULL,
        FechaCreacion DATETIME2(0) NOT NULL CONSTRAINT DF_Clientes_FechaCreacion DEFAULT SYSUTCDATETIME(),
        CONSTRAINT UQ_Clientes_NumeroIdentificacion UNIQUE (NumeroIdentificacion)
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Clientes WHERE NumeroIdentificacion = N'1001001001')
BEGIN
    INSERT INTO dbo.Clientes (NumeroIdentificacion, Nombres, Apellidos, Email, Telefono)
    VALUES (N'1001001001', N'Ana', N'García López', N'ana.garcia@example.com', N'3001234567');
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Clientes WHERE NumeroIdentificacion = N'1001001002')
BEGIN
    INSERT INTO dbo.Clientes (NumeroIdentificacion, Nombres, Apellidos, Email, Telefono)
    VALUES (N'1001001002', N'Carlos', N'Martínez Pérez', N'carlos.martinez@example.com', N'3017654321');
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Clientes WHERE NumeroIdentificacion = N'1001001003')
BEGIN
    INSERT INTO dbo.Clientes (NumeroIdentificacion, Nombres, Apellidos, Email, Telefono)
    VALUES (N'1001001003', N'Laura', N'Rodríguez Díaz', N'laura.rodriguez@example.com', N'3109876543');
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ObtenerClientePorIdentificacion
    @NumeroIdentificacion NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, NumeroIdentificacion, Nombres, Apellidos, Email, Telefono, FechaCreacion
    FROM dbo.Clientes
    WHERE NumeroIdentificacion = @NumeroIdentificacion;
END;
GO
