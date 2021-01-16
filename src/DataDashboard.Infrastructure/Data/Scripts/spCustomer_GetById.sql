CREATE PROCEDURE [dbo].[spCustomer_GetById]
( @Id int)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Customers]
	WHERE Id = @Id
END