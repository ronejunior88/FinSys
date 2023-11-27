
IF NOT EXISTS(SELECT 'FinSys' FROM sys.databases)
CREATE DATABASE FinSys
GO

IF NOT EXISTS(SELECT 'Expending' FROM sys.tables)
CREATE TABLE Expending (
[Id] uniqueidentifier PRIMARY KEY NOT NULL,
[Value] decimal(18,2) NOT NULL,
[Description] VARCHAR(150) NOT NULL
)
GO

IF EXISTS(SELECT 'Expending' FROM sys.tables)
ALTER TABLE Expending
ADD [Inative] BIT NOT NULL;
GO

IF EXISTS(SELECT 'Expending' FROM sys.tables)
ALTER TABLE Expending
ADD [DateExpiration] DATETIME NOT NULL;
GO

IF EXISTS(SELECT 'Expending' FROM sys.tables)
ALTER TABLE Expending
ADD [DateRelease] DATETIME NOT NULL;
GO

IF EXISTS(SELECT 'Expending' FROM sys.tables)
ALTER TABLE Expending
ADD [DatePayment] DATETIME;
GO

 
