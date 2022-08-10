CREATE VIEW vwCategories AS 
SELECT C.Id, C.Name, COUNT(A.Id) AS ActivitiesNum
FROM [dbo].[Categories] as C
INNER JOIN [dbo].[Activities] as A
ON C.Id = A.CategoryId
GROUP BY C.Id, C.Name