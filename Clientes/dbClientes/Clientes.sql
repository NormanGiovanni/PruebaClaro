CREATE TABLE [dbo].[Clientes]
(
	[Id] BIGINT IDENTITY (1, 1)  NOT NULL PRIMARY KEY, 
    [Tipo documento] INT NOT NULL, 
    [Identificacion] NVARCHAR(20) NOT NULL, 
    [Nombre] NVARCHAR(250) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Celular] NVARCHAR(20) NOT NULL, 
    [Direccion] NVARCHAR(180) NOT NULL, 
    [Direccion de Instalacion] NVARCHAR(180) NOT NULL,
    [Estado] BIT NOT NULL DEFAULT 1,
    FOREIGN KEY ([Tipo documento]) REFERENCES TipoDocumentos(Id)
)
