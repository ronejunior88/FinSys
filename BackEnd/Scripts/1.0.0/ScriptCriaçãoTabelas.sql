
IF NOT EXISTS(SELECT 'FinSys' FROM sys.databases)
CREATE DATABASE FinSys

GO

IF NOT EXISTS(SELECT 'Expending' FROM sys.tables)
CREATE TABLE Expending (
[Id] uniqueidentifier PRIMARY KEY NOT NULL,
[Value] FLOAT NOT NULL,
[Description] VARCHAR(150) NOT NULL
)

GO

IF EXISTS(SELECT 'Expending' FROM sys.tables)
ALTER TABLE Expending
ADD [Inative] BIT NOT NULL;

GO

 
