CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

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


CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('519a96ea-13e0-4a59-85b7-3a495487702e', 'Administrator', 'ADMINISTRATOR', null);


INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('257d0f47-6f4d-4b97-91a6-725f4920ad97', 'Manager', 'MANAGER', null);

INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('0c669e2f-f988-4b38-8398-8a769cec5abb', 'User', 'USER', null);

INSERT INTO [dbo].[AspNetUsers] ([Id], [EmployeeNumber], [EmpName], [UserName], [NormalizedUserName], 
                [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber],
                [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
                VALUES 
                (N'aaaee442-381d-48a0-8e8b-a508b886b58e', N'111111', N'AdminBruker', N'Admin@test.com', N'ADMIN@TEST.COM', 
                N'Admin@test.com', N'ADMIN@TEST.COM', 0, 
                N'AQAAAAEAACcQAAAAEAP4jLaY9UyJu3npZuHwOFeF8pRQ0jx7AaVUmQJ+ZLxU9XDTatEKCxSeBH0e/4b3jQ==', 
                N'QH3DAQXJDY4MJKNFTEQ7J6E4NIH3HTSQ', N'47859bf6-484c-48f3-b0bd-e73f799687fe', NULL, 0, 0, NULL, 1, 0)

        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('aaaee442-381d-48a0-8e8b-a508b886b58e', '257d0f47-6f4d-4b97-91a6-725f4920ad97');
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('aaaee442-381d-48a0-8e8b-a508b886b58e', '519a96ea-13e0-4a59-85b7-3a495487702e');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221129165036_SeedRole', N'6.0.11');

CREATE TABLE [Teams] (
    [TeamId] int NOT NULL IDENTITY,
    [TeamName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Teams] PRIMARY KEY ([TeamId])
);

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

CREATE TABLE [TeamsMembership] (
    [Id] int NOT NULL IDENTITY,
    [TeamID] int NOT NULL,
    [EmployeeNumber] int NOT NULL,
    CONSTRAINT [PK_TeamsMembership] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TeamsMembership_Teams_TeamID] FOREIGN KEY ([TeamID]) REFERENCES [Teams] ([TeamId]) ON DELETE CASCADE
);

CREATE TABLE [Comments] (
    [CommentId] int NOT NULL IDENTITY,
    [CommentDate] datetime2 NOT NULL,
    [CommentContent] nvarchar(max) NOT NULL,
    [SugID] int NOT NULL,
    [EmployeeNumber] int NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentId]),
    CONSTRAINT [FK_Comments_Suggestions_SugID] FOREIGN KEY ([SugID]) REFERENCES [Suggestions] ([SuggestionId]) ON DELETE CASCADE
);

CREATE INDEX [IX_Comments_SugID] ON [Comments] ([SugID]);

CREATE INDEX [IX_Suggestions_TeamID] ON [Suggestions] ([TeamID]);

CREATE INDEX [IX_TeamsMembership_TeamID] ON [TeamsMembership] ([TeamID]);


