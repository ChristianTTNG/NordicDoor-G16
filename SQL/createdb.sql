--Make database and tables

create database if not exists NordicDoor;
use NordicDoor;

CREATE OR REPLACE TABLE Employee (
    EmployeeID varchar(12) NOT NULL,
    EmpName varchar(200),
    PhoneNr varchar(20),
    Email varchar(320),
    IsAdmin tinyint(1),

    CONSTRAINT PK_Employee PRIMARY KEY (EmployeeID)
);

CREATE OR REPLACE TABLE Team(
    TeamID int auto_increment,
    TeamName varchar(50),

    CONSTRAINT PK_Team PRIMARY KEY (TeamID)
);

CREATE OR REPLACE TABLE TeamMembership(
    TeamID int NOT NULL,
    EmployeeID varchar(12) NOT NULL,

    CONSTRAINT PK_Membership PRIMARY KEY (EmployeeID, TeamID),
    CONSTRAINT FK_TEAMID FOREIGN KEY (TeamID) REFERENCES Team (TeamID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Employee FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE OR REPLACE TABLE Suggestion(
    SuggestionID int auto_increment,
    SugName varchar(50) not null,
    SugDescription varchar(500),
    EstTime varchar(50),
    SugStatus varchar(50),
    RegisteredDate date not null DEFAULT current_date,
    CompletedDate date,
    SugCategory varchar(50),
    IsJdi tinyint(1),

    TeamID int not null,
    SugCreator varchar(12) not null,
    SugResponsible varchar(12) not null,

    CONSTRAINT PK_Suggestion PRIMARY KEY (SuggestionID),
    CONSTRAINT FK_Sug_Team FOREIGN KEY (TeamID) REFERENCES Team (TeamID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Sug_Creator FOREIGN KEY (SugCreator) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Sug_Responsible FOREIGN KEY (SugResponsible) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE OR REPLACE TABLE Comment(
    EmployeeID varchar(12) not null,
    CommentContent varchar (500) not null,
    SuggestionID int,
    CommentDate datetime not null DEFAULT current_timestamp,
    
    CONSTRAINT FK_Comment_Employee FOREIGN KEY (EmployeeID) REFERENCES Employee (EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT PK_Comment PRIMARY KEY (EmployeeID, CommentDate),
    CONSTRAINT FK_Connected_suggestion FOREIGN KEY (SuggestionID) REFERENCES Suggestion(SuggestionID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE OR REPLACE TABLE SuggestionImage(
    ImageURL varchar(150) not null,
    SugState tinyint,
    SuggestionID int not null,

    CONSTRAINT PK_SugImg PRIMARY KEY (ImageURL),
    CONSTRAINT FK_Image_Suggestion FOREIGN KEY (SuggestionID) REFERENCES Suggestion (SuggestionID) ON DELETE CASCADE ON UPDATE CASCADE
);
 
