CREATE PROC dbo.GetCustomerById
( @Id int)
AS
BEGIN
	SELECT * FROM [dbo].[Customers]
	WHERE Id = @Id
END