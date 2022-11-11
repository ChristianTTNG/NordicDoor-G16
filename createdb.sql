--drop database webAppDatabase;
create database if not exists nordicdoorDatabase;
use nordicdoorDatabase;

CREATE OR REPLACE TABLE Employee (
    EmpID varchar(12) NOT NULL,
    EmpName varchar(200),
    PhoneNr varchar(20),
    Email varchar(320),
    IsAdmin tinyint(1),

    CONSTRAINT PK_Employee PRIMARY KEY (EmpID)
);

CREATE OR REPLACE TABLE Team(
    TeamID int auto_increment,
    TeamName varchar(50),
    TeamSize int,

    CONSTRAINT PK_Team PRIMARY KEY (TeamID)
);

CREATE OR REPLACE TABLE TeamMembership(
    TeamID int NOT NULL,
    EmpID varchar(12) NOT NULL,

    CONSTRAINT PK_Membership PRIMARY KEY (EmpID, TeamID),
    CONSTRAINT FK_TEAMID FOREIGN KEY (TeamID) REFERENCES Team (TeamID),
    CONSTRAINT FK_Employee FOREIGN KEY (EmpID) REFERENCES Employee(EmpID)
);

CREATE OR REPLACE TABLE Suggestion(
    SugID int auto_increment,
    SugName varchar(50) not null,
    SugDescription varchar(500),
    EstTime varchar(50) not null,
    SugStatus varchar(50) not null,
    RegisteredDate varchar(24),
    CompletedDate datetime(6), 
    SugCategory varchar(50),

    TeamID int not null,
    SugCreator varchar(12) not null,
    SugResponsible varchar(12),

    CONSTRAINT PK_Suggestion PRIMARY KEY (SugID),
    CONSTRAINT FK_Sug_Team FOREIGN KEY (TeamID) REFERENCES Team (TeamID),
    CONSTRAINT FK_Sug_Creator FOREIGN KEY (SugCreator) REFERENCES Employee(EmpID),
    CONSTRAINT FK_Sug_Responsible FOREIGN KEY (SugResponsible) REFERENCES Employee(EmpID)
);


CREATE OR REPLACE TABLE Comment(
    EmpID varchar(12) not null,
    CommentDate varchar(24),
    SugID int,
    CommentContent varchar (500) not null,
    
    CONSTRAINT FK_Comment_Employee FOREIGN KEY (EmpID) REFERENCES Employee (EmpID),
    CONSTRAINT PK_Comment PRIMARY KEY (EmpID, CommentDate),
    CONSTRAINT FK_Connected_suggestion FOREIGN KEY (SugID) REFERENCES Suggestion(SugID)
);

CREATE OR REPLACE TABLE SuggestionImage(
    ImageURL varchar(150) not null,
    SugState BOOLEAN,
    SugID int not null,

    CONSTRAINT PK_SugImg PRIMARY KEY (ImageURL),
    CONSTRAINT FK_Image_Suggestion FOREIGN KEY (SugID) REFERENCES Suggestion (SugID)
);
 
