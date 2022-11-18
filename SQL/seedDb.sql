--Employees

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (1, 'Geir Kvernes', '45384958', 'Geir@nordic.door', '0');

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (2, 'Pål Hauken', '45323458', 'Pål@nordic.door', '0');

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (3, 'Inge Geir', '48284958', 'Inge@nordic.door', '0');

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (4, 'Krissander Maler', '45384483', 'Krissander@nordic.door', '0');

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (5, 'Kim Marius', '42395258', 'Kim@nordic.door', '0');

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (6, 'Anne Nilsen', '49284958', 'Anne@nordic.door', '0');

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (7, 'Tor Langås', '45123958', 'Tor@nordic.door', '1');

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (8, 'Cathrine Pedersen', '45341258', 'Cathrine@nordic.door', '0');

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (9, 'Mai-britt Nakken', '45382358', 'Mai@nordic.door', '0');

INSERT INTO Employee (EmployeeID, EmpName, PhoneNr, Email, IsAdmin)
VALUES (10, 'Tor Løkkeberg', '45484912', 'Tor@nordic.door', '1');


--Teams

INSERT INTO Team VALUES (1, 'Kantine', 5);

INSERT INTO Team VALUES (2, 'Event',9);

INSERT INTO Team VALUES (3, 'Planlegging', 12);

INSERT INTO Team VALUES (4, 'Kundeservice', 21);

INSERT INTO Team VALUES (5, 'Logistikk', 8);

INSERT INTO Team VALUES (6, 'Produksjon', 46);

INSERT INTO Team VALUES (7, 'Lager', 11);

INSERT INTO Team VALUES (8, 'Design', 7);

INSERT INTO Team VALUES (9, 'Partier', 4);

INSERT INTO Team VALUES (10, 'Workshop', 29);


--TeamMemberships

INSERT INTO TeamMembership VALUES (1, 10);

INSERT INTO TeamMembership VALUES (2, 9);

INSERT INTO TeamMembership VALUES (3, 8);

INSERT INTO TeamMembership VALUES (4, 7);

INSERT INTO TeamMembership VALUES (5, 6);

INSERT INTO TeamMembership VALUES (6, 5);

INSERT INTO TeamMembership VALUES (7, 4);

INSERT INTO TeamMembership VALUES (8, 3);

INSERT INTO TeamMembership VALUES (9, 2);

INSERT INTO TeamMembership VALUES (10, 1);


--Suggestions

INSERT INTO Suggestion (SugName, SugDescription, EstTime, SugStatus, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('Fikse vifte', 'Vifte må fikses', '2022-11-16', 'plan', 'HMS', '1', '1', '2', '0');

INSERT INTO Suggestion (SugName, SugDescription, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('Vaske gulvet', 'Noen sølte mat', 'HMS', '1', '6', '3', '1');

INSERT INTO Suggestion (SugName, SugDescription, EstTime, SugStatus, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('Bestille deler', 'Deler til maskin på lageret må bestilles', '2022-11-30', 'act', 'Kvalitet', '4', '5', '3', '0');

INSERT INTO Suggestion (SugName, SugDescription, EstTime, SugStatus, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('Montere dør', 'Døren er ute av plass', '2022-11-18', 'plan', 'Kvalitet', '2', '3', '3', '0');

INSERT INTO Suggestion (SugName, SugDescription, EstTime, SugStatus, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('Flytte pakker', 'Det er mange tunge pakker som står i veien på lageret', '2022-11-20', 'plan', 'HMS', '3', '6', '6', '0');

INSERT INTO Suggestion (SugName, SugDescription, EstTime, SugStatus, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('Bestille mekaniker til gaffeltruck', 'Gaffeltrucken trenger fagfolk for å fikses', '2022-12-10', 'plan', 'Kvalitet', '8', '5', '2', '0');

INSERT INTO Suggestion (SugName, SugDescription, EstTime, SugStatus, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('En seng har ikke drift', 'Defekt tannhjul', '2022-11-27', 'act', 'Kvalitet', '6', '10', '6', '0');

INSERT INTO Suggestion (SugName, SugDescription, EstTime, SugStatus, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('Dør-oversikt', 'Døroversikten er ikke riktig og må rettes på', '2022-11-28', 'Kommunikasjon', 'HMS', '9', '5', '2', '0');

INSERT INTO Suggestion (SugName, SugDescription, EstTime, SugStatus, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('Ny blåsestasjon', 'Den gammle er for "gammel"', '2022-12-20', 'plan', 'Effiktivisering', '3', '5', '2', '0');

INSERT INTO Suggestion (SugName, SugDescription, SugCategory, TeamID, SugCreator, SugResponsible, IsJdi)
VALUES ('Montere hanskeholder', 'Pizza', 'HMS', '7', '1', '8', '1');


--Comments

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (2, 'Out too the been like hard off. Improve enquire welcome own beloved matters her. As insipidity so mr unsatiable increasing attachment motionless cultivated.', 1, '2022-05-21 21:30:10');

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (1, 'For norland produce age wishing. To figure on it spring season up. Her provision acuteness had excellent two why intention.', 2, '2022-05-23 12:46:22');

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (7, 'Domestic confined any but son bachelor advanced remember. How proceed offered her offence shy forming.', 3, '2022-06-02 09:54:13');

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (2, 'Excited him now natural saw passage offices you minuter. At by asked being court hopes. Farther so friends am to detract.', 4, '2022-06-10 19:03:04');

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (2, 'Am of mr friendly by strongly peculiar juvenile.', 5, '2022-06-16 23:05:43');

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (1, 'Whatever settling goodness too and honoured she building answered her.', 6, '2022-07-03 13:03:59');

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (7, 'Examine she brother prudent add day ham.', 7, '2022-07-18 12:32:36');

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (10, 'Civilly why how end viewing attempt related enquire visitor.', 8, '2022-07-29 08:21:53');

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (4, 'Her extensive perceived may any sincerity extremity.', 9, '2022-10-23 19:23:51');

INSERT INTO Comment (EmployeeID, CommentContent, SuggestionID, CommentDate)
VALUES (2, 'Comfort reached gay perhaps chamber his six detract besides add.', 10, '2022-11-03 21:54:32');


--SuggestionImages

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/2YGjV0f.png', 2, 1);

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/pLmG5sP.png', 1, 2);

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/389Ad8u.png', 4, 3);

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/2039oiA.png', 3, 4);

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/239487a.png', 1, 5);

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/P6a209b.png', 2, 6);

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/90802Bk.png', 4, 7);

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/POa209b.png', 1, 8);

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/HIUHW38.png', 1, 9);

INSERT INTO SuggestionImage VALUES ('https://i.imgur.com/JIOH221.png', 3, 10);