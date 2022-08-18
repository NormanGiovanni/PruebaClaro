CREATE TABLE [dbo].[TipoDocumentos]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Descripcion] NVARCHAR(50) NOT NULL, 
    [Activo] BIT NOT NULL DEFAULT 1
)
