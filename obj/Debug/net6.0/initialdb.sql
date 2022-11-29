CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

CREATE TABLE `Comment` (
    `CommentID` INTEGER NOT NULL,
    `CommentDate` TEXT NULL,
    `CommentContent` TEXT NULL,
    `SugID` INTEGER NOT NULL,
    CONSTRAINT `PK_Comment` PRIMARY KEY (`CommentID`)
);

CREATE TABLE `Suggestion` (
    `SuggestionID` INTEGER NOT NULL,
    `SugName` TEXT NULL,
    `Description` TEXT NULL,
    `RegisteredDate` TEXT NULL,
    `CompletedDate` TEXT NULL,
    `SugCategory` TEXT NULL,
    `EmployeeID` INTEGER NOT NULL,
    `ResponsibleEmp` INTEGER NOT NULL,
    `TeamID` INTEGER NOT NULL,
    `DueDate` TEXT NULL,
    `SugStatus` TEXT NULL,
    `IsJDI` INTEGER NOT NULL,
    CONSTRAINT `PK_Suggestion` PRIMARY KEY (`SuggestionID`)
);

CREATE TABLE `SuggestionImage` (
    `SuggestionImageID` INTEGER NOT NULL,
    `ImageURL` TEXT NOT NULL,
    `SugState` INTEGER NOT NULL,
    `SuggestionID` INTEGER NOT NULL,
    CONSTRAINT `PK_SuggestionImage` PRIMARY KEY (`SuggestionImageID`)
);

CREATE TABLE `Team` (
    `TeamID` INTEGER NOT NULL,
    `TeamName` TEXT NULL,
    `TeamSize` INTEGER NOT NULL,
    CONSTRAINT `PK_Team` PRIMARY KEY (`TeamID`)
);

CREATE TABLE `TeamMembership` (
    `TeamMembershipID` INTEGER NOT NULL,
    `TeamID` INTEGER NOT NULL,
    `EmployeeID` INTEGER NOT NULL,
    CONSTRAINT `PK_TeamMembership` PRIMARY KEY (`TeamMembershipID`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20221031122041_initial', '6.0.11');

COMMIT;

