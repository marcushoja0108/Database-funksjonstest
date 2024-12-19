CREATE TABLE [dbo].[Table]
(
	[RegNumber] NVARCHAR(MAX) NOT NULL PRIMARY KEY, 
    [Brand] NVARCHAR(MAX) NOT NULL, 
    [Model] NVARCHAR(MAX) NOT NULL, 
    [ModelYear] INT NOT NULL, 
    [Color] NVARCHAR(MAX) NOT NULL, 
    [KmRange] INT NOT NULL
)
