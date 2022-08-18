CREATE PROCEDURE [dbo].[CambioEstadoCliente] (@CodCliente bigint, @Estado bit)
AS
	BEGIN
		UPDATE [dbo].[Clientes] SET Estado = @Estado WHERE id = @codCliente;
	END
