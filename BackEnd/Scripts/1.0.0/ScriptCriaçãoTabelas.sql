
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

IF NOT EXISTS(SELECT 'SystemUser' FROM sys.tables)
CREATE TABLE SystemUser (
[Id] uniqueidentifier PRIMARY KEY NOT NULL,
[Name] VARCHAR(150) NOT NULL,
[Email] VARCHAR(200) NOT NULL,
[PasswordHash] VARBINARY(MAX) NULL,
[PasswordSalt] VARBINARY(MAX) NULL,
[DateBirth] VARCHAR(500)
)
GO
 
