CREATE PROCEDURE [dbo].[spCustomers_Delete]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[Customers]
	WHERE Id = @Id;
END
