USE [master];

DROP DATABASE IF EXISTS [TimeLoggerDb]
GO

CREATE DATABASE [TimeLoggerDb]
GO

USE [TimeLoggerDb]
GO

DROP TABLE IF EXISTS [User];
DROP TABLE IF EXISTS [Customer];
DROP TABLE IF EXISTS [Project];
DROP TABLE IF EXISTS [Registration];

CREATE TABLE [User] (
[ID] INT NOT NULL IDENTITY(1,1),
[AccountName] VARCHAR(32) NOT NULL,

PRIMARY KEY ([ID])
);

CREATE TABLE [Customer] (
[ID] INT NOT NULL IDENTITY(1,1),
[AccountName] VARCHAR(32) NOT NULL,

PRIMARY KEY ([ID])
);

CREATE TABLE [Project] (
[ID] INT NOT NULL IDENTITY(1,1),
[Name] VARCHAR(255) NOT NULL,
[DateOfCreation] DATE DEFAULT GETDATE(),
[Deadline] DATE DEFAULT DATEADD(DAY, 7, GETDATE()),
[UserID] INT NOT NULL,
[CustomerID] INT NOT NULL,

PRIMARY KEY ([ID]),
FOREIGN KEY ([UserID]) REFERENCES [User]([ID]),
FOREIGN KEY ([CustomerID]) REFERENCES [Customer]([ID])
);

DROP PROCEDURE IF EXISTS [proc_insert_project]
GO

CREATE PROCEDURE [proc_insert_project] (
	@name VARCHAR(255),
	@userId INT,
	@customerId INT,
	@dateOfCreation DATE,
	@deadline DATE)
AS
	BEGIN
		INSERT INTO [Project] ([Name], [UserID], [CustomerID], [DateOfCreation], [Deadline])
		VALUES (@name, @userId, @customerId, @dateOfCreation, @deadline);
	END
GO