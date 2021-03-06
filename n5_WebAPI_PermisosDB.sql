USE [master];
GO
/****** Object:  Database [n5_core_securityDB]    Script Date: 14/06/2022 09:52:20 a. m. ******/
CREATE DATABASE [n5_core_securityDB];
GO
ALTER DATABASE [n5_core_securityDB] SET COMPATIBILITY_LEVEL = 150;
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
    EXEC [n5_core_securityDB].[dbo].[sp_fulltext_database] @action = 'enable';
END;
GO
ALTER DATABASE [n5_core_securityDB] SET ANSI_NULL_DEFAULT OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET ANSI_NULLS OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET ANSI_PADDING OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET ANSI_WARNINGS OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET ARITHABORT OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET AUTO_CLOSE ON;
GO
ALTER DATABASE [n5_core_securityDB] SET AUTO_SHRINK OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET AUTO_UPDATE_STATISTICS ON;
GO
ALTER DATABASE [n5_core_securityDB] SET CURSOR_CLOSE_ON_COMMIT OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET CURSOR_DEFAULT GLOBAL;
GO
ALTER DATABASE [n5_core_securityDB] SET CONCAT_NULL_YIELDS_NULL OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET NUMERIC_ROUNDABORT OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET QUOTED_IDENTIFIER OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET RECURSIVE_TRIGGERS OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET ENABLE_BROKER;
GO
ALTER DATABASE [n5_core_securityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET DATE_CORRELATION_OPTIMIZATION OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET TRUSTWORTHY OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET PARAMETERIZATION SIMPLE;
GO
ALTER DATABASE [n5_core_securityDB] SET READ_COMMITTED_SNAPSHOT OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET HONOR_BROKER_PRIORITY OFF;
GO
ALTER DATABASE [n5_core_securityDB] SET RECOVERY SIMPLE;
GO
ALTER DATABASE [n5_core_securityDB] SET MULTI_USER;
GO
ALTER DATABASE [n5_core_securityDB] SET PAGE_VERIFY CHECKSUM;
GO
ALTER DATABASE [n5_core_securityDB] SET DB_CHAINING OFF;
GO
ALTER DATABASE [n5_core_securityDB]
SET FILESTREAM
    (
        NON_TRANSACTED_ACCESS = OFF
    );
GO
ALTER DATABASE [n5_core_securityDB] SET TARGET_RECOVERY_TIME = 60 SECONDS;
GO
ALTER DATABASE [n5_core_securityDB] SET DELAYED_DURABILITY = DISABLED;
GO
ALTER DATABASE [n5_core_securityDB] SET QUERY_STORE = OFF;
GO
USE [n5_core_securityDB];
GO
/****** Object:  User [admin]    Script Date: 14/06/2022 09:52:20 a. m. ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA = [dbo];
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/06/2022 09:52:21 a. m. ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[__EFMigrationsHistory]
(
    [MigrationId] [NVARCHAR](150) NOT NULL,
    [ProductVersion] [NVARCHAR](32) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory]
        PRIMARY KEY CLUSTERED ([MigrationId] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
              ALLOW_PAGE_LOCKS = ON
             ) ON [PRIMARY]
) ON [PRIMARY];
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 14/06/2022 09:52:21 a. m. ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[Permisos]
(
    [IdPermisos] [INT] IDENTITY(1, 1) NOT NULL,
    [NombreEmpleado] [NVARCHAR](100) NOT NULL,
    [ApellidoEmpleado] [NVARCHAR](100) NOT NULL,
    [IdTipoPermiso] [INT] NOT NULL,
    [FechaPermiso] [DATETIME2](7) NOT NULL,
    [FechaCreacion] [DATETIME2](7) NOT NULL,
    [FechaModificacion] [DATETIME2](7) NOT NULL,
    CONSTRAINT [PK_Permisos]
        PRIMARY KEY CLUSTERED ([IdPermisos] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
              ALLOW_PAGE_LOCKS = ON
             ) ON [PRIMARY]
) ON [PRIMARY];
GO
/****** Object:  Table [dbo].[TipoPermisos]    Script Date: 14/06/2022 09:52:21 a. m. ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[TipoPermisos]
(
    [IdTipoPermiso] [INT] IDENTITY(1, 1) NOT NULL,
    [Descripion] [NVARCHAR](40) NOT NULL,
    CONSTRAINT [PK_TipoPermisos]
        PRIMARY KEY CLUSTERED ([IdTipoPermiso] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
              ALLOW_PAGE_LOCKS = ON
             ) ON [PRIMARY]
) ON [PRIMARY];
GO


INSERT INTO [dbo].[TipoPermisos]
(
    [Descripion]
)
VALUES
('CON GOCE DE SUELDO'),
('SIN GOCE DE SUELDO')


/****** Object:  StoredProcedure [dbo].[_sp_Permisos_Agregar]    Script Date: 14/06/2022 09:52:21 a. m. ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
-- =============================================
-- Author:		Francisco Pérez
-- Description:	Agrega al catálogo de Permisos un nuevo registro
-- =============================================
CREATE PROCEDURE [dbo].[_sp_Permisos_Agregar]
    -- Params
    @nombreEmpleado VARCHAR(100),
    @apellidoEmpleado VARCHAR(100),
    @fechaPermiso DATETIME,
    @idTipoPermiso INT,
    @success BIT OUTPUT
AS
BEGIN

    DECLARE @Error VARCHAR(MAX);
    DECLARE @Id INT;

    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS
        (
            SELECT IdTipoPermiso
            FROM dbo.TipoPermisos
            WHERE IdTipoPermiso = @idTipoPermiso
        )
        BEGIN
            SET @Error = 'El tipo de permiso no es válido.';
            THROW 51000, @Error, 1;
        END;

        IF ISNULL(@nombreEmpleado, '') = ''
            RAISERROR('El nombre del empleado es requerido.', 16, 2);

        IF ISNULL(@apellidoEmpleado, '') = ''
            RAISERROR('El apellido del empleado es requerido.', 16, 2);

        IF ISNULL(@fechaPermiso, '') = ''
            RAISERROR('Es necesario especificar la fecha del permiso.', 16, 2);

        INSERT INTO dbo.Permisos
        (
            NombreEmpleado,
            ApellidoEmpleado,
            IdTipoPermiso,
            FechaPermiso,
            FechaCreacion,
            FechaModificacion
        )
        VALUES
        (   @nombreEmpleado,   -- NombreEmpleado - nvarchar(100)
            @apellidoEmpleado, -- ApellidoEmpleado - nvarchar(100)
            @idTipoPermiso,    -- IdTipoPermiso - int
            @fechaPermiso,     -- FechaPermiso - datetime2(7)
            GETDATE(), GETDATE());

        SET @Id = SCOPE_IDENTITY();

        IF ISNULL(@Id, 0) < 1
        BEGIN
            SET @Error = '¡Ocurrió un error al registrar el permiso!';
            THROW 51000, @Error, 1;
        END;


        COMMIT TRAN;
        SET @success = 1;
        EXECUTE dbo._sp_Permisos_Obtener @idPermiso = @Id; -- bigint

    END TRY
    BEGIN CATCH
        SET @Error = ERROR_MESSAGE();
        ROLLBACK TRAN;
        SET @Id = 0;
        SET @success = 0;
        RAISERROR(@Error, 16, 2);
    END CATCH;

END;
GO
/****** Object:  StoredProcedure [dbo].[_sp_Permisos_Editar]    Script Date: 14/06/2022 09:52:21 a. m. ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
-- =============================================
-- Author:		Francisco Pérez
-- Description:	Modifica un registro del catálogo Permisos
-- =============================================
CREATE PROCEDURE [dbo].[_sp_Permisos_Editar]
    -- Params
    @idPermiso BIGINT,
    @nombreEmpleado VARCHAR(100),
    @apellidoEmpleado VARCHAR(100),
    @fechaPermiso DATE,
    @idTipoPermiso INT,
    @success BIT OUTPUT
AS
BEGIN

    DECLARE @Error VARCHAR(MAX);
    DECLARE @Id INT;

    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS
        (
            SELECT IdTipoPermiso
            FROM dbo.TipoPermisos
            WHERE IdTipoPermiso = @idTipoPermiso
        )
        BEGIN
            SET @Error = 'El tipo de permiso no es válido.';
            THROW 51000, @Error, 1;
        END;


        IF NOT EXISTS
        (
            SELECT IdPermisos
            FROM dbo.Permisos
            WHERE IdPermisos = @idPermiso
        )
        BEGIN
            SET @Error = 'Elemento no encontrado para modificar.';
            THROW 51000, @Error, 1;
        END;

        IF ISNULL(@fechaPermiso, '') = ''
            RAISERROR('Es necesario especificar la fecha del permiso.', 16, 2);

        UPDATE dbo.Permisos
        SET FechaPermiso = @fechaPermiso,
            IdTipoPermiso = @idTipoPermiso,
            FechaModificacion = GETDATE(),
            NombreEmpleado = @nombreEmpleado,
            ApellidoEmpleado = @apellidoEmpleado
        WHERE IdPermisos = @idPermiso;

        COMMIT TRAN;

        SET @success = 1;
        EXECUTE dbo._sp_Permisos_Obtener @idPermiso = @idPermiso; -- bigint
    END TRY
    BEGIN CATCH
        SET @Error = ERROR_MESSAGE();
        ROLLBACK TRAN;
        SET @Id = 0;
        SET @success = 0;
        RAISERROR(@Error, 16, 2);
    END CATCH;

END;
GO
/****** Object:  StoredProcedure [dbo].[_sp_Permisos_Obtener]    Script Date: 14/06/2022 09:52:21 a. m. ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
-- =============================================
-- Author:		Francisco Pérez
-- Description:	Modifica un registro del catálogo Permisos
-- =============================================
CREATE PROCEDURE [dbo].[_sp_Permisos_Obtener]
    -- Params
    @idPermiso BIGINT = 0
AS
BEGIN

    SELECT IdPermisos AS idPermiso,
           NombreEmpleado,
           ApellidoEmpleado,
           CONCAT_WS(' ', NombreEmpleado, ApellidoEmpleado) AS NombreCompletoEmpleado,
           FechaPermiso,
           TipoPermisos.IdTipoPermiso,
           Descripion AS descripcionTipoPermiso
    FROM dbo.Permisos
        INNER JOIN dbo.TipoPermisos
            ON TipoPermisos.IdTipoPermiso = Permisos.IdTipoPermiso
    WHERE IdPermisos = IIF(@idPermiso > 0, @idPermiso, IdPermisos)
    ORDER BY idPermiso DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[_sp_TipoPermisos_Obtener]    Script Date: 14/06/2022 09:52:21 a. m. ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
-- =============================================
-- Author:		Francisco Pérez
-- Description:	Obtiene los elementos de la tabla TipoPermisos
-- =============================================
CREATE PROCEDURE [dbo].[_sp_TipoPermisos_Obtener]
-- Parámetros
AS
BEGIN
    --
    SELECT IdTipoPermiso,
           Descripion AS Descripcion
    FROM dbo.TipoPermisos;
END;
GO
USE [master];
GO
ALTER DATABASE [n5_core_securityDB] SET READ_WRITE;
GO
