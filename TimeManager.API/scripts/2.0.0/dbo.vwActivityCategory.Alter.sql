ALTER VIEW vwActivityCategory AS
SELECT A.[Id], A.[Name], A.[Description], C.[Id] AS CategoryId, C.[Name] AS CategoryName, A.[DateAdded], A.[DateCompleted], A.[Deadline]
FROM [dbo].[Activities] AS A 
INNER JOIN [dbo].[Categories] AS C
ON A.[CategoryId] = C.[Id]