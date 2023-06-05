IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Company] (
    [Id] uniqueidentifier NOT NULL,
    [Address] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [State] nvarchar(max) NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Employee] (
    [Id] uniqueidentifier NOT NULL,
    [LastName] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [MiddleName] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Department] nvarchar(max) NULL,
    [JobRole] nvarchar(max) NULL,
    [Supervisor] uniqueidentifier NULL,
    [WagesInDollar] float NOT NULL,
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employee_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'City', N'State') AND [object_id] = OBJECT_ID(N'[Company]'))
    SET IDENTITY_INSERT [Company] ON;
INSERT INTO [Company] ([Id], [Address], [City], [State])
VALUES ('43738933-acf0-4479-8624-0ef1bec0383d', N'8,Mesa Road', N'Houston', N'Texas'),
('6c7e9c5d-89ae-43d9-8f19-feb71af65e8f', N'12,ogunnaike street GRA', N'Ikeja', N'Lagos');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'City', N'State') AND [object_id] = OBJECT_ID(N'[Company]'))
    SET IDENTITY_INSERT [Company] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CompanyId', N'Department', N'Email', N'FirstName', N'JobRole', N'LastName', N'MiddleName', N'PhoneNumber', N'Supervisor', N'WagesInDollar') AND [object_id] = OBJECT_ID(N'[Employee]'))
    SET IDENTITY_INSERT [Employee] ON;
INSERT INTO [Employee] ([Id], [CompanyId], [Department], [Email], [FirstName], [JobRole], [LastName], [MiddleName], [PhoneNumber], [Supervisor], [WagesInDollar])
VALUES ('1eff9885-7088-4da3-9b8c-d086cfa99ee6', '6c7e9c5d-89ae-43d9-8f19-feb71af65e8f', N'Digital', N'paulI@gmail.com', N'Cherri', N'Media', N'Evans', N'Beauty', N'07027544487', '43738933-acf0-4479-8624-0ef1bec0383d', 2500.0E0),
('e237f904-35e4-4f31-b854-b49c61a8b443', '43738933-acf0-4479-8624-0ef1bec0383d', N'Digital', N'digitalteam@gmail.com', N'Isaac', N'Lead', N'Paul', NULL, N'+1312754448', NULL, 4500.0E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CompanyId', N'Department', N'Email', N'FirstName', N'JobRole', N'LastName', N'MiddleName', N'PhoneNumber', N'Supervisor', N'WagesInDollar') AND [object_id] = OBJECT_ID(N'[Employee]'))
    SET IDENTITY_INSERT [Employee] OFF;
GO

CREATE INDEX [IX_Employee_CompanyId] ON [Employee] ([CompanyId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230601180547_initial', N'7.0.5');
GO

COMMIT;
GO

