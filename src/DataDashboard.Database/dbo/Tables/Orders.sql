CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Completed] DATETIME2 NULL, 
    [Placed] DATETIME2 NOT NULL, 
    [Total] DECIMAL NOT NULL, 
    [CustomerId] INT NOT NULL
)
