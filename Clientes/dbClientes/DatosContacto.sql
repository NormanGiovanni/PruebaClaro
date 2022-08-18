CREATE TABLE [dbo].[DatosContacto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [idCliente] BIGINT NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [CelularContacto] NVARCHAR(20) NOT NULL, 
    [Direccion] NVARCHAR(180) NOT NULL, 
    [Direccion de Instalacion] NVARCHAR(180) NOT NULL
)
