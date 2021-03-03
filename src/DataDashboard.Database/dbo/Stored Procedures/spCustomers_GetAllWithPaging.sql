CREATE PROCEDURE [dbo].[spCustomers_GetAllWithPaging]
	@Offset INT,
	@PageSize INT
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
	OFFSET @Offset ROWS
	FETCH NEXT @PageSize ROWS ONLY;

	SELECT COUNT(*) FROM [dbo].[Customers];
END