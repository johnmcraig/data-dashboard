CREATE PROCEDURE [dbo].[spCustomers_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		[Id], 
		[Name], 
		[Email], 
		[State] 
	FROM 
		[dbo].[Customers]
	WHERE Id = @Id;
END
