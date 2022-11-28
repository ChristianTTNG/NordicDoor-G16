create database if not exists NordicDoor;
use NordicDoor;

ALTER DATABASE NordicDoor DEFAULT CHARACTER SET utf8mb4;

CREATE OR REPLACE TABLE Employee (
    EmployeeId int NOT NULL,
    EmpName varchar(200) NOT NULL,
    IsAdmin bit NOT NULL,
    CONSTRAINT PK_Employee PRIMARY KEY (EmployeeId)
);

CREATE OR REPLACE TABLE `Team` (
    `TeamID` int auto_increment,
    `TeamName` varchar(50) NOT NULL,
    CONSTRAINT `PK_Team` PRIMARY KEY (`TeamID`)
);

CREATE OR REPLACE TABLE `Suggestion` (
    `SuggestionId` int auto_increment,
    `SugName` varchar(50) NOT NULL,
    `TeamID` int NOT NULL,
    `SugCreatorID` int NOT NULL,
    `ResponsibleEmployeeID` int NOT NULL,
    `SugDescription` varchar(500) NOT NULL,
    `SugCategory` varchar(50) NOT NULL,
    `JDISug` bit NOT NULL,
    `progress` real NOT NULL,
    `SugStatus` varchar(50) NOT NULL,
    `RegisteredDate` datetime NOT NULL,
    `CompletedOrDueDate` datetime NOT NULL,
    CONSTRAINT `PK_Suggestion` PRIMARY KEY (`SuggestionId`),
    CONSTRAINT `FK_Suggestion_Employee_ResponsibleEmployeeID` FOREIGN KEY (`ResponsibleEmployeeID`) REFERENCES `Employee` (`EmployeeId`) ON DELETE CASCADE,
    CONSTRAINT `FK_Suggestion_Employee_SugCreatorID` FOREIGN KEY (`SugCreatorID`) REFERENCES `Employee` (`EmployeeId`),
    CONSTRAINT `FK_Suggestion_Team_TeamID` FOREIGN KEY (`TeamID`) REFERENCES `Team` (`TeamID`) ON DELETE CASCADE
);

CREATE OR REPLACE TABLE `TeamMembership` (
    `Id` int auto_increment,
    `TeamID` int NOT NULL,
    `EmployeeID` int NOT NULL,
    CONSTRAINT `PK_TeamMembership` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_TeamMembership_Employee_EmployeeID` FOREIGN KEY (`EmployeeID`) REFERENCES `Employee` (`EmployeeId`) ON DELETE CASCADE,
    CONSTRAINT `FK_TeamMembership_Team_TeamID` FOREIGN KEY (`TeamID`) REFERENCES `Team` (`TeamID`) ON DELETE CASCADE
);

CREATE OR REPLACE TABLE `Comment` (
    `CommentId` int auto_increment,
    `CommentDate` datetime not null DEFAULT current_timestamp,
    `CommentContent` varchar(500) NOT NULL,
    `SugID` int NOT NULL,
    `EmployeeID` int NOT NULL,
    CONSTRAINT `PK_Comment` PRIMARY KEY (`CommentId`),
    CONSTRAINT `FK_Comment_Employee_EmployeeID` FOREIGN KEY (`EmployeeID`) REFERENCES `Employee` (`EmployeeId`),
    CONSTRAINT `FK_Comment_Suggestion_SugID` FOREIGN KEY (`SugID`) REFERENCES `Suggestion` (`SuggestionId`) ON DELETE CASCADE
);

CREATE OR REPLACE TABLE `SugImage` (
    `ImageId` int auto_increment,
    `Name` varchar(500) NOT NULL,
    `ContentType` varchar(500) NOT NULL,
    `ImageData` varbinary(500) NOT NULL,
    `SugID` int NOT NULL,
    CONSTRAINT `PK_SugImage` PRIMARY KEY (`ImageId`),
    CONSTRAINT `FK_SugImage_Suggestion_SugID` FOREIGN KEY (`SugID`) REFERENCES `Suggestion` (`SuggestionId`) ON DELETE CASCADE
);

CREATE INDEX `IX_Comment_EmployeeID` ON `Comment` (`EmployeeID`);

CREATE INDEX `IX_Comment_SugID` ON `Comment` (`SugID`);

CREATE INDEX `IX_Suggestion_ResponsibleEmployeeID` ON `Suggestion` (`ResponsibleEmployeeID`);

CREATE INDEX `IX_Suggestion_SugCreatorID` ON `Suggestion` (`SugCreatorID`);

CREATE INDEX `IX_Suggestion_TeamID` ON `Suggestion` (`TeamID`);

CREATE INDEX `IX_SugImage_SugID` ON `SugImage` (`SugID`);

CREATE INDEX `IX_TeamMembership_EmployeeID` ON `TeamMembership` (`EmployeeID`);

CREATE INDEX `IX_TeamMembership_TeamID` ON `TeamMembership` (`TeamID`);