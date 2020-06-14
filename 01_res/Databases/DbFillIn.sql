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
    
    