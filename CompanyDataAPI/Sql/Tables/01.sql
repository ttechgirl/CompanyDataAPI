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

CREATE TABLE [Department] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [Supervisor] nvarchar(max) NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [ModifiedOn] datetime2 NULL,
    [ModifiedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Employee] (
    [Id] uniqueidentifier NOT NULL,
    [LastName] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [MiddleName] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [JobRole] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [State] nvarchar(max) NULL,
    [WagesInDollar] float NOT NULL,
    [DepartmentId] uniqueidentifier NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [ModifiedOn] datetime2 NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [DeletedOn] datetime2 NULL,
    [DeletedBy] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employee_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Department] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedOn', N'ModifiedBy', N'ModifiedOn', N'Name', N'Supervisor') AND [object_id] = OBJECT_ID(N'[Department]'))
    SET IDENTITY_INSERT [Department] ON;
INSERT INTO [Department] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Name], [Supervisor])
VALUES ('43738933-acf0-4479-8624-0ef1bec0383d', N'HR', NULL, N'HR', NULL, N'Engineering & Product', N'paul@company.com'),
('6c7e9c5d-89ae-43d9-8f19-feb71af65e8f', N'HR', NULL, N'HR', NULL, N'Marketing & Sales', N'Adex@company.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedOn', N'ModifiedBy', N'ModifiedOn', N'Name', N'Supervisor') AND [object_id] = OBJECT_ID(N'[Department]'))
    SET IDENTITY_INSERT [Department] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'City', N'CreatedBy', N'CreatedOn', N'DeletedBy', N'DeletedOn', N'DepartmentId', N'Email', N'FirstName', N'IsDeleted', N'JobRole', N'LastName', N'MiddleName', N'ModifiedBy', N'ModifiedOn', N'PhoneNumber', N'State', N'WagesInDollar') AND [object_id] = OBJECT_ID(N'[Employee]'))
    SET IDENTITY_INSERT [Employee] ON;
INSERT INTO [Employee] ([Id], [Address], [City], [CreatedBy], [CreatedOn], [DeletedBy], [DeletedOn], [DepartmentId], [Email], [FirstName], [IsDeleted], [JobRole], [LastName], [MiddleName], [ModifiedBy], [ModifiedOn], [PhoneNumber], [State], [WagesInDollar])
VALUES ('7713bf21-9e81-4949-abf7-d5a64f281d69', N'30 Alpha estate lekki', N'Ikeja', N'HR', NULL, N'HR', NULL, '6c7e9c5d-89ae-43d9-8f19-feb71af65e8f', N'Adex@company.com', N'Michael', CAST(0 AS bit), N'Media Lead', N'Adex', NULL, N'HR', NULL, N'0907794487', N'Lagos', 5500.0E0),
('acc627bb-7733-4e13-876e-7d49a3838c12', N'8,Mesa Road', N'Houston', N'HR', NULL, N'HR', NULL, '43738933-acf0-4479-8624-0ef1bec0383d', N'paul@company.com', N'Isaac', CAST(0 AS bit), N'Tech Lead', N'Paul', NULL, N'HR', NULL, N'+1312754448', N'Texas', 4500.0E0),
('d17d52bd-9178-41d1-b399-705f6b7899b9', N'12,ogunnaike street GRA', N'Ikeja', N'HR', NULL, N'HR', NULL, '6c7e9c5d-89ae-43d9-8f19-feb71af65e8f', N'cherry@company.com', N'Cherri', CAST(0 AS bit), N'Media', N'Evans', N'Beauty', N'HR', NULL, N'07027544487', N'Lagos', 2500.0E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'City', N'CreatedBy', N'CreatedOn', N'DeletedBy', N'DeletedOn', N'DepartmentId', N'Email', N'FirstName', N'IsDeleted', N'JobRole', N'LastName', N'MiddleName', N'ModifiedBy', N'ModifiedOn', N'PhoneNumber', N'State', N'WagesInDollar') AND [object_id] = OBJECT_ID(N'[Employee]'))
    SET IDENTITY_INSERT [Employee] OFF;
GO

CREATE INDEX [IX_Employee_DepartmentId] ON [Employee] ([DepartmentId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241206153020_Initial', N'7.0.5');
GO

COMMIT;
GO

