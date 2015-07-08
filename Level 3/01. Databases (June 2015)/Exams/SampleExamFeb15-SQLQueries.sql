--USE Ads
--GO

----------------------------------
-- Problem 1
----------------------------------
--SELECT
--    a.Title
--FROM Ads AS a
--ORDER BY a.Title ASC

----------------------------------
-- Problem 2
----------------------------------
--SELECT
--    a.Title,
--    a.Date
--FROM Ads AS a
--WHERE a.Date BETWEEN '26-Dec-2014' AND '02-Jan-2015'
--ORDER BY a.Date ASC

----------------------------------
-- Problem 3
----------------------------------
--SELECT
--    a.Title,
--    a.Date,
--    CASE
--        WHEN a.ImageDataURL IS NOT NULL THEN 'yes' ELSE 'no'
--    END AS [Has Image]
--FROM Ads AS a
--ORDER BY a.Id

----------------------------------
-- Problem 4
----------------------------------
--SELECT 
--    * 
--FROM Ads AS a
--WHERE 
--    a.CategoryId IS NULL OR 
--    a.TownId IS NULL OR 
--    a.ImageDataURL IS NULL

----------------------------------
-- Problem 5
----------------------------------
--SELECT
--    a.Title,
--    t.Name AS [Town]
--FROM Ads AS a
--LEFT JOIN Towns AS t
--    ON a.TownId = t.Id
--ORDER BY a.Id ASC

----------------------------------
-- Problem 6
----------------------------------
--SELECT
--    a.Title,
--    c.Name AS [CategoryName],
--    t.Name AS [TownName],
--    s.Status AS [Status]
--FROM Ads AS a
--LEFT JOIN Categories AS c
--    ON a.CategoryId = c.Id
--LEFT JOIN Towns AS t
--    ON a.TownId = t.Id
--LEFT JOIN AdStatuses AS s
--    On a.StatusId = s.Id
--ORDER BY a.Id ASC

----------------------------------
-- Problem 7
----------------------------------
--SELECT
--    a.Title,
--    c.Name AS [CategoryName],
--    t.Name AS [TownName],
--    s.Status
--FROM Ads AS a
--JOIN Towns AS t
--    ON a.TownId = t.Id AND t.Name IN ('Sofia', 'Stara Zagora', 'Blagoevgrad')
--JOIN AdStatuses AS s
--    ON a.StatusId = s.Id AND s.Status = 'Published'
--JOIN Categories AS c
--    ON a.CategoryId = c.Id
--ORDER BY a.Title ASC

----------------------------------
-- Problem 8
----------------------------------
--SELECT
--    MIN(a.Date) AS [MinDate],
--    MAX(a.Date) AS [MaxDate]
--FROM Ads AS a

----------------------------------
-- Problem 9
----------------------------------
--SELECT TOP 10
--    a.Title,
--    a.Date,
--    s.Status
--FROM Ads AS a
--JOIN AdStatuses AS s
--    ON a.StatusId = s.Id
--ORDER BY a.Date DESC

----------------------------------
-- Problem 10
----------------------------------
--DECLARE @minYear INT = YEAR((SELECT MIN(Date) FROM Ads))
    
--DECLARE @minMonth INT = MONTH((SELECT MIN(Date) FROM Ads))

--SELECT 
--    a.Id,
--    a.Title,
--    a.Date,
--    s.Status
--FROM Ads AS a
--JOIN AdStatuses AS s
--    ON a.StatusId = s.Id AND s.Status != 'Published'
--WHERE YEAR(a.Date) = @minYear AND MONTH(a.Date) = @minMonth
--ORDER BY a.Id ASC

--GO

----------------------------------
-- Problem 11
----------------------------------
--SELECT 
--    s.Status,
--    COUNT(s.Id) AS [Count]
--FROM AdStatuses AS s
--LEFT JOIN Ads AS a
--    ON s.Id = a.StatusId
--GROUP BY s.Status
--ORDER BY s.Status

----------------------------------
-- Problem 12
----------------------------------
