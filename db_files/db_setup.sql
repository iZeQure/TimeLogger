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

CREATE TABLE [Registration] (
[ID] INT NOT NULL IDENTITY(1,1),
[RegistrationTime] TIME(0) NOT NULL,
[ProjectID] INT NOT NULL,

PRIMARY KEY ([ID]),
FOREIGN KEY ([ProjectID]) REFERENCES [Project]([ID])
);

DROP PROCEDURE IF EXISTS [proc_Insert_project]
DROP PROCEDURE IF EXISTS [proc_SelectById_project]
DROP PROCEDURE IF EXISTS [proc_SelectAll_projects]
DROP PROCEDURE IF EXISTS [proc_SelectAllSortedByDeadline_projects]
DROP PROCEDURE IF EXISTS [proc_SelectAllSortedByDeadlineDescending_projects]

DROP PROCEDURE IF EXISTS [proc_Insert_registration]
GO

CREATE PROCEDURE [proc_Insert_project] (
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

CREATE PROCEDURE [proc_SelectById_project] (
	@projectId INT)
AS
	BEGIN
		SELECT 
			[Project].[ID] AS 'ProjectID',
			[Project].[Name] AS 'ProjectName',
			[Project].[DateOfCreation] AS 'ProjectDateOfCreation',
			[Project].[Deadline] AS 'ProjectDeadline',
			[Project].[UserID] AS 'ProjectOwner',
			[Project].[CustomerID] AS 'ProjectForCustomerID'
		FROM [Project] WHERE [Project].[ID] = @projectId;
	END
GO

CREATE PROCEDURE [proc_SelectAll_projects]
AS
	BEGIN
		SELECT 
			[Project].[ID] AS 'ProjectID',
			[Project].[Name] AS 'ProjectName',
			[Project].[DateOfCreation] AS 'ProjectDateOfCreation',
			[Project].[Deadline] AS 'ProjectDeadline',
			[Project].[UserID] AS 'ProjectOwner',
			[Project].[CustomerID] AS 'ProjectForCustomerID',

			[Registration].[ID] AS 'RegistrationID',
			[Registration].[ProjectID] AS 'RegistrationForProjectID',
			[Registration].[RegistrationTime] AS 'RegistrationTime'
		FROM [Project]
		INNER JOIN [Registration]
		ON [Registration].[ProjectID] = [Project].[ID];
	END
GO

CREATE PROCEDURE [proc_SelectAllSortedByDeadline_projects]
AS
	BEGIN
		SELECT * FROM [Project] ORDER BY [Deadline] ASC;
	END
GO

CREATE PROCEDURE [proc_SelectAllSortedByDeadlineDescending_projects]
AS
	BEGIN
		SELECT * FROM [Project] ORDER BY [Deadline] DESC;
	END
GO

CREATE PROCEDURE [proc_Insert_registration] (
	@time TIME(0),
	@projectID INT)
AS
	BEGIN
		INSERT INTO [Registration] ([RegistrationTime], [ProjectID])
		VALUES (@time, @projectID);
	END
GO