--------------------------------------------------------------------------------------------------
-- Problem 1 : Create a table in SQL Server with 10 000 000 entries (date + text). Search in the 
--             table by date range. Check the speed (without caching)
--------------------------------------------------------------------------------------------------
USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'DB_Performance'
)
BEGIN
    DROP DATABASE PartitioningDemo
END
GO

-- Create database
CREATE DATABASE DB_Performance
COLLATE SQL_Latin1_General_CP1_CI_AS
GO

-- Edit log size
ALTER DATABASE DB_Performance
modify FILE(name=DB_Performance_log, size=5000mb, filegrowth=1000mb)
GO

-- Edit Data siz
ALTER DATABASE DB_Performance
modify FILE(name=DB_Performance, size=5000mb, filegrowth=1000mb)
GO

USE DB_Performance
GO

-- Create table
CREATE TABLE Performance (
    Id INT IDENTITY PRIMARY KEY,
    Date DATETIME NOT NULL,
    Text TEXT NOT NULL)
GO

-- Fill table with data
BEGIN TRAN
    DECLARE @i INT = 10000000, @date DATETIME = GETDATE()

    WHILE (@i > 0)
    BEGIN
    INSERT INTO Performance (Date, Text) VALUES
        (@date, 'Some text ' + convert(nvarchar,@i))

    SET @date = DATEADD(MINUTE, 1, @date)

    SET @i = @i - 1
    END
COMMIT
GO

-- Clear cache
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS
GO

-- Select from table by Date range
SELECT Id, Date FROM Performance
WHERE Date BETWEEN CAST(DATEADD(DAY, 300, GETDATE()) AS DATE) AND CAST(DATEADD(DAY, 1365, GETDATE()) AS DATE)

-- Check cache
SELECT usecounts, cacheobjtype, objtype, text 
FROM sys.dm_exec_cached_plans 
CROSS APPLY sys.dm_exec_sql_text(plan_handle) 
WHERE usecounts > 0 AND 
			text like '%SELECT Id, Date FROM Performance
WHERE Date BETWEEN CAST(DATEADD(DAY, 300, GETDATE()) AS DATE) AND CAST(DATEADD(DAY, 1365, GETDATE()) AS DATE)%'
ORDER BY usecounts DESC;
GO

-- Check log
DBCC loginfo('DB_Performance')
GO

--------------------------------------------------------------------------------------------------
-- Problem 2 : Add an index to speed-up the search by date. Test the search speed (after cleaning 
--             the cache)
--------------------------------------------------------------------------------------------------
USE DB_Performance
GO

-- Create index for Date column
CREATE INDEX IX_Performance_Date on Performance(Date)
GO

-- Clear cache
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS
GO

-- Select from table by Date range
SELECT Id, Date FROM Performance
WHERE Date BETWEEN CAST(DATEADD(DAY, 300, GETDATE()) AS DATE) AND CAST(DATEADD(DAY, 1365, GETDATE()) AS DATE)