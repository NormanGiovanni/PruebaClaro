CREATE TABLE [dbo].[Clientes]
(
	[Id] BIGINT IDENTITY (1, 1)  NOT NULL PRIMARY KEY, 
    [Tipo documento] INT NOT NULL, 
    [Identificacion] NVARCHAR(20) NOT NULL, 
    [Nombre] NVARCHAR(250) NOT NULL, 
    [Estado] BIT NOT NULL DEFAULT 1 
)
