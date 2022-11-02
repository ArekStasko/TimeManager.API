CREATE VIEW vwActivityCategory AS
SELECT A.[Id], A.[Name], A.[Description], C.[Name] AS CategoryName
FROM [dbo].[Activities] AS A 
INNER JOIN [dbo].[Categories] AS C
ON A.[CategoryId] = C.[Id]