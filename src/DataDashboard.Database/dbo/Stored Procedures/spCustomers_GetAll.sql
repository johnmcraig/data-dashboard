CREATE PROCEDURE [dbo].[spCustomers_GetAll]

AS
BEGIN
	SELECT 
		[Id], 
		[Name], 
		[Email], 
		[State] 
	FROM 
		[dbo].[Customers] cus
	ORDER BY
		cus.[Name]
END
