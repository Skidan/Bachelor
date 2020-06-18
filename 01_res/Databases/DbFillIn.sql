USE [Qualify]
GO

INSERT INTO Clients (Name, Country, Email)
    VALUES
    ('MiTip','Danmark','info@mi.dk'),
    ('Konekesko','Lithuania','info@konekesko.lt'),
    ('Roltex','Poland','wszystko@roltexagro.pl'),
    ('Agricasa','Hungary','info@agricasa.hg'),
    ('Almex, D.o.o.','Serbia','info@almex.rs'),
    ('Agrimasz','Poland','info@agrimasz.pl'),
    ('OOO Umega','Russia','info@umegaagro.ru');

GO

INSERT INTO Departments (Name)
    VALUES
    ('Welding bar'),
    ('Painting bar'),
    ('Assemblying bar'),
    ('Preparation bar'),
    ('Technical dept'),
    ('Logistic dept'),
    ('Quality dept');
GO

INSERT INTO ToolTypes (Name, CheckIntervalWeeks)
    VALUES
    ('Caliper', 108),
    ('Tape-measure', 12),
    ('Micrometer', 54),
    ('Try square', 54),
    ('Level', 54),
    ('Ruler', 108),
    ('Manometer', 32);
GO

INSERT INTO Employees (Name, DepartmentID, Position)
    VALUES
    ('Mikolajus Aivazovskas',2,'Foreman'),
    ('Egidijus Suvirinevicius',1,'Foreman'),
    ('Михаил Кувалдин',3,'Foreman'),
    ('Микита Напильненко',4,'Foreman'),
    ('Justinas Bimbamskis',5,'Engineer'),
    ('Siuntyte Atvaziaite',6,'Manager'),
    ('Keturi Ziedai',7,'Auditor');
GO

INSERT INTO Claims (ClientID, Title, Description, DateStart, DateEnd)
    VALUES
    (1, 'Cylinders of tailgate are leaking', 'Place a full description of a particular claim here to show the text within different types of containers', '2020-06-24 00:00:00.0000000', '2019-10-15 00:00:00.0000000'),
    (2, 'Trailer cover is torn', 'Place a full description of a particular claim here to show the text within different types of containers', '2020-5-5 00:00:00.0000000', null),
    (1, 'Frame get rusted', 'Place a full description of a particular claim here to show the text within different types of containers', '2019-01-30 00:00:00.0000000', null),
    (4, 'We are not got board extensions', 'Place a full description of a particular claim here to show the text within different types of containers', '2020-05-23 00:00:00.0000000', null),
    (3, 'Brakes not working as expected', 'Place a full description of a particular claim here to show the text within different types of containers', '2020-06-06 00:00:00.0000000', null),
    (7, 'Mudguards not fits 710/50 R26.5 tires', 'Place a full description of a particular claim here to show the text within different types of containers', '2020-3-2 00:00:00.0000000', null),
    (6, 'Loose paint on trailer', 'Place a full description of a particular claim here to show the text within different types of containers', '2020-4-16 00:00:00.0000000', null);
GO
