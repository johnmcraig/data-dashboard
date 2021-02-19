CREATE PROCEDURE [dbo].[spCustomers_Update]
	@Id int,
	@Name NVARCHAR(50),
	@Email NVARCHAR(50),
	@State NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Customers] 
	SET [Name] = @Name, Email = @Email, [State] = @State 
	WHERE Id = @Id;

END
