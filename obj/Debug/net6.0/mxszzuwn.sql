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

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [EmployeeNumber] nvarchar(64) NOT NULL,
    [EmpName] nvarchar(255) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(20) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221129164944_InitialCreate', N'6.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('1d29e595-6ec8-43f0-a494-2a9d341e6667', 'Administrator', 'ADMINISTRATOR', null);
GO

INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('c481e983-4e16-4831-abad-612bd8e774f5', 'Manager', 'MANAGER', null);
GO

INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('04694f62-1c6f-417a-9421-b9014905a54d', 'User', 'USER', null);
GO

INSERT INTO [dbo].[AspNetUsers] ([Id], [EmployeeNumber], [EmpName], [UserName], [NormalizedUserName], 
                [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber],
                [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
                VALUES 
                (N'66adbb2a-e690-48d2-b9da-61764f47c105', N'111111', N'AdminBruker', N'Admin@test.com', N'ADMIN@TEST.COM', 
                N'Admin@test.com', N'ADMIN@TEST.COM', 0, 
                N'AQAAAAEAACcQAAAAEAP4jLaY9UyJu3npZuHwOFeF8pRQ0jx7AaVUmQJ+ZLxU9XDTatEKCxSeBH0e/4b3jQ==', 
                N'QH3DAQXJDY4MJKNFTEQ7J6E4NIH3HTSQ', N'47859bf6-484c-48f3-b0bd-e73f799687fe', NULL, 0, 0, NULL, 1, 0)
GO


        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('66adbb2a-e690-48d2-b9da-61764f47c105', 'c481e983-4e16-4831-abad-612bd8e774f5');
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('66adbb2a-e690-48d2-b9da-61764f47c105', '1d29e595-6ec8-43f0-a494-2a9d341e6667');
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221129165036_SeedRole', N'6.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO


        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('780c74f6-3f34-4b6d-b1b3-a2da5970c0f7', 'a42410b5 - 417f - 4680 - 8c42-c7268d521202');
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221129173540_AdminForAdmin', N'6.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO


        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('780c74f6-3f34-4b6d-b1b3-a2da5970c0f7', 'a42410b5-417f-4680-8c42-c7268d521202');
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221129174155_AdminForAdmin2', N'6.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Teams] (
    [TeamId] int NOT NULL IDENTITY,
    [TeamName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Teams] PRIMARY KEY ([TeamId])
);
GO

CREATE TABLE [Suggestions] (
    [SuggestionId] int NOT NULL IDENTITY,
    [SugName] nvarchar(max) NOT NULL,
    [TeamID] int NOT NULL,
    [SugCreatorID] int NOT NULL,
    [ResponsibleEmployeeID] int NOT NULL,
    [SugDescription] nvarchar(max) NULL,
    [SugCategory] nvarchar(max) NOT NULL,
    [JDISug] bit NOT NULL,
    [progress] real NOT NULL,
    [SugStatus] nvarchar(max) NOT NULL,
    [RegisteredDate] datetime2 NOT NULL,
    [CompletedOrDueDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Suggestions] PRIMARY KEY ([SuggestionId]),
    CONSTRAINT [FK_Suggestions_Teams_TeamID] FOREIGN KEY ([TeamID]) REFERENCES [Teams] ([TeamId]) ON DELETE CASCADE
);
GO

CREATE TABLE [TeamsMembership] (
    [Id] int NOT NULL IDENTITY,
    [TeamID] int NOT NULL,
    [EmployeeNumber] int NOT NULL,
    CONSTRAINT [PK_TeamsMembership] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TeamsMembership_Teams_TeamID] FOREIGN KEY ([TeamID]) REFERENCES [Teams] ([TeamId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Comments] (
    [CommentId] int NOT NULL IDENTITY,
    [CommentDate] datetime2 NOT NULL,
    [CommentContent] nvarchar(max) NOT NULL,
    [SugID] int NOT NULL,
    [EmployeeNumber] int NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentId]),
    CONSTRAINT [FK_Comments_Suggestions_SugID] FOREIGN KEY ([SugID]) REFERENCES [Suggestions] ([SuggestionId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Comments_SugID] ON [Comments] ([SugID]);
GO

CREATE INDEX [IX_Suggestions_TeamID] ON [Suggestions] ([TeamID]);
GO

CREATE INDEX [IX_TeamsMembership_TeamID] ON [TeamsMembership] ([TeamID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221129205735_Suggestions', N'6.0.11');
GO

COMMIT;
GO

