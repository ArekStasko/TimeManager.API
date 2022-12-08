CREATE VIEW vwCategories AS 
SELECT C.Id, C.Name, COUNT(A.Id) AS ActTasksNum
FROM [dbo].[Categories] as C
INNER JOIN [dbo].[ActTasks] as A
ON C.Id = A.CategoryId
GROUP BY C.Id, C.Name