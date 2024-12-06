BEGIN TRANSACTION;
GO

ALTER TABLE [Employee] DROP CONSTRAINT [FK_Employee_Company_CompanyId];
GO

DROP TABLE [Company];
GO

DELETE FROM [Employee]
WHERE [Id] = '1eff9885-7088-4da3-9b8c-d086cfa99ee6';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Employee]
WHERE [Id] = 'e237f904-35e4-4f31-b854-b49c61a8b443';
SELECT @@ROWCOUNT;

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employee]') AND [c].[name] = N'Supervisor');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Employee] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Employee] DROP COLUMN [Supervisor];
GO

EXEC sp_rename N'[Employee].[Department]', N'ModifiedBy', N'COLUMN';
GO

EXEC sp_rename N'[Employee].[CompanyId]', N'DepartmentId', N'COLUMN';
GO

EXEC sp_rename N'[Employee].[IX_Employee_CompanyId]', N'IX_Employee_DepartmentId', N'INDEX';
GO

ALTER TABLE [Employee] ADD [Address] nvarchar(max) NULL;
GO

ALTER TABLE [Employee] ADD [CreatedBy] nvarchar(max) NULL;
GO

ALTER TABLE [Employee] ADD [CreatedOn] datetime2 NULL;
GO

ALTER TABLE [Employee] ADD [ModifiedOn] datetime2 NULL;
GO

CREATE TABLE [Department] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [Supervisor] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [State] nvarchar(max) NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [ModifiedOn] datetime2 NULL,
    [ModifiedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CreatedBy', N'CreatedOn', N'ModifiedBy', N'ModifiedOn', N'Name', N'State', N'Supervisor') AND [object_id] = OBJECT_ID(N'[Department]'))
    SET IDENTITY_INSERT [Department] ON;
INSERT INTO [Department] ([Id], [City], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Name], [State], [Supervisor])
VALUES ('43738933-acf0-4479-8624-0ef1bec0383d', N'Houston', N'HR', '2024-12-06T14:20:04.8746173+01:00', N'HR', NULL, N'Enginearing & Product', N'Texas', N'paul@company.com'),
('6c7e9c5d-89ae-43d9-8f19-feb71af65e8f', N'Ikeja', N'HR', '2024-12-06T14:20:04.8746354+01:00', N'HR', NULL, N'Marketing & Sales', N'Lagos', N'Adex@company.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CreatedBy', N'CreatedOn', N'ModifiedBy', N'ModifiedOn', N'Name', N'State', N'Supervisor') AND [object_id] = OBJECT_ID(N'[Department]'))
    SET IDENTITY_INSERT [Department] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedBy', N'CreatedOn', N'DepartmentId', N'Email', N'FirstName', N'JobRole', N'LastName', N'MiddleName', N'ModifiedBy', N'ModifiedOn', N'PhoneNumber', N'WagesInDollar') AND [object_id] = OBJECT_ID(N'[Employee]'))
    SET IDENTITY_INSERT [Employee] ON;
INSERT INTO [Employee] ([Id], [Address], [CreatedBy], [CreatedOn], [DepartmentId], [Email], [FirstName], [JobRole], [LastName], [MiddleName], [ModifiedBy], [ModifiedOn], [PhoneNumber], [WagesInDollar])
VALUES ('7713bf21-9e81-4949-abf7-d5a64f281d69', N'30 Alpha estate lekki', N'HR', '2024-12-06T14:20:04.8746772+01:00', '6c7e9c5d-89ae-43d9-8f19-feb71af65e8f', N'Adex@company.com', N'Michael', N'Media Lead', N'Adex', NULL, N'HR', NULL, N'0907794487', 5500.0E0),
('acc627bb-7733-4e13-876e-7d49a3838c12', N'8,Mesa Road', N'HR', '2024-12-06T14:20:04.8746739+01:00', '43738933-acf0-4479-8624-0ef1bec0383d', N'paul@company.com', N'Isaac', N'Lead', N'Paul', NULL, N'HR', NULL, N'+1312754448', 4500.0E0),
('d17d52bd-9178-41d1-b399-705f6b7899b9', N'12,ogunnaike street GRA', N'HR', '2024-12-06T14:20:04.8746761+01:00', '6c7e9c5d-89ae-43d9-8f19-feb71af65e8f', N'cherry@company.com', N'Cherri', N'Media', N'Evans', N'Beauty', N'HR', NULL, N'07027544487', 2500.0E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedBy', N'CreatedOn', N'DepartmentId', N'Email', N'FirstName', N'JobRole', N'LastName', N'MiddleName', N'ModifiedBy', N'ModifiedOn', N'PhoneNumber', N'WagesInDollar') AND [object_id] = OBJECT_ID(N'[Employee]'))
    SET IDENTITY_INSERT [Employee] OFF;
GO

ALTER TABLE [Employee] ADD CONSTRAINT [FK_Employee_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Department] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241206132005_Modifications', N'7.0.5');
GO

COMMIT;
GO

