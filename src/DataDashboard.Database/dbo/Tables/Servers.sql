﻿CREATE TABLE [dbo].[Servers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Names] NVARCHAR(50) NOT NULL, 
    [IsOnline] BIT NOT NULL
)
