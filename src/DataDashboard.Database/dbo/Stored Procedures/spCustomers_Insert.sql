CREATE PROCEDURE [dbo].[spCustomers_Insert]
	@Id int OUTPUT, 
	@Name nvarchar(50), 
	@Email nvarchar(50), 
	@State nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO 
		[dbo].[Customers] (
		[Name], 
		[Email], 
		[State]
	) 
	VALUES(
		@Name, 
		@Email, 
		@State
	);
	
	SET @Id = SCOPE_IDENTITY();

END

