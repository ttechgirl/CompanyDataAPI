BEGIN TRANSACTION;
GO

ALTER TABLE [Employee] ADD [Gender] int NULL;
GO

UPDATE [Employee] SET [Gender] = 2
WHERE [Id] = '7713bf21-9e81-4949-abf7-d5a64f281d69';
SELECT @@ROWCOUNT;

GO

UPDATE [Employee] SET [Gender] = 1
WHERE [Id] = 'acc627bb-7733-4e13-876e-7d49a3838c12';
SELECT @@ROWCOUNT;

GO

UPDATE [Employee] SET [Gender] = 1
WHERE [Id] = 'd17d52bd-9178-41d1-b399-705f6b7899b9';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241206233124_UpdateEmployee', N'7.0.5');
GO

COMMIT;
GO

