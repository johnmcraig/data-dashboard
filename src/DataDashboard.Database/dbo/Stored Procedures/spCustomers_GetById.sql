CREATE PROCEDURE [dbo].[spCustomers_GetById]
	@Id int
AS
	SET NOCOUNT ON;

	SELECT [Id], [Name], [Email], [State] FROM [dbo].[Customers]
	WHERE Id = @Id
RETURN 0
