-- DB SETUP
CREATE DATABASE BizBloqzDB
GO

USE BizBloqzDB
GO


-- TABLE SETUP
CREATE TABLE [dbo].[Texts] (
Id UNIQUEIDENTIFIER PRIMARY KEY,
TextValue NVARCHAR(20) NOT NULL
)


-- STORED PROCEDURE SETUP
IF EXISTS ( SELECT 1 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[sp_GetEverySecondRowTexts]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[sp_GetEverySecondRowTexts]
END
GO
CREATE PROCEDURE [dbo].[sp_GetEverySecondRowTexts] 
AS
SELECT Id, TextValue FROM (SELECT ROW_NUMBER() OVER (ORDER BY Id) AS RowNum, Id, TextValue FROM [dbo].Texts) A WHERE RowNum % 2 = 0
GO


-- STORED PROCEDURE UNIT TESTS

-- 1.) No record dbo.Texts table
-- Expected Result: empty
EXEC sp_GetEverySecondRowTexts
GO

-- 2.) Only one record dbo.Texts table
-- Expected Result: empty
INSERT INTO Texts (Id, TextValue)
SELECT NEWID(), 'Test1' 
GO
EXEC sp_GetEverySecondRowTexts
GO

-- 3.) 4 records dbo.Texts table
-- Expected Result: will get the every second row records and this means 2 records
INSERT INTO Texts (Id,TextValue)
SELECT NEWID(),'Tested2' UNION
SELECT NEWID(),'Test3' UNION
SELECT NEWID(),'Test4'
GO
SELECT Id, TextValue FROM Texts
EXEC sp_GetEverySecondRowTexts
GO

TRUNCATE TABLE Texts
GO
