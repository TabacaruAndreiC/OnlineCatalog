-- Crearea tabelului Users
CREATE TABLE Users (
    ID INT PRIMARY KEY,
    Username VARCHAR(50),
    Password VARCHAR(50)
);

-- Crearea tabelului Profesor
CREATE TABLE Profesor (
    ID_profesor INT PRIMARY KEY,
    Nume VARCHAR(50)
);

-- Crearea tabelului Note
CREATE TABLE Note (
    Nota_Crt INT PRIMARY KEY,
    Nota INT,
    Data DATE,
    Teza VARCHAR(50)
);

-- Crearea tabelului Materie
CREATE TABLE Materie (
    MaterieId INT PRIMARY KEY
);

-- Crearea tabelului Elev
CREATE TABLE Elev (
    ID_elev INT PRIMARY KEY,
    Nume VARCHAR(50)
);

-- Crearea tabelului Class
CREATE TABLE Class (
    ID INT PRIMARY KEY,
    Denumire VARCHAR(50),
    Diriginte INT,
    FOREIGN KEY (Diriginte) REFERENCES Profesor(ID_profesor)
);

-- Crearea tabelului Absente
CREATE TABLE Absente (
    Abs_Crt INT PRIMARY KEY,
    Tip VARCHAR(50),
    Data DATE
);

-- Legarea tabelei Users cu tabela Profesor
ALTER TABLE Users
ADD ID_profesor INT,
FOREIGN KEY (ID_profesor) REFERENCES Profesor(ID_profesor);

-- Legarea tabelei Users cu tabela Elev
ALTER TABLE Users
ADD ID_elev INT,
FOREIGN KEY (ID_elev) REFERENCES Elev(ID_elev);

-- Legarea tabelei Note cu tabela Users
ALTER TABLE Note
ADD UserID INT,
FOREIGN KEY (UserID) REFERENCES Users(ID);

-- Legarea tabelei Note cu tabela Materie
ALTER TABLE Note
ADD MaterieId INT,
FOREIGN KEY (MaterieId) REFERENCES Materie(MaterieId);

-- Legarea tabelei Note cu tabela Elev
ALTER TABLE Note
ADD ID_elev INT,
FOREIGN KEY (ID_elev) REFERENCES Elev(ID_elev);

-- Legarea tabelei Elev cu tabela Class
ALTER TABLE Elev
ADD ClassID INT,
FOREIGN KEY (ClassID) REFERENCES Class(ID);

-- Legarea tabelei Absente cu tabela Elev
ALTER TABLE Absente
ADD ID_elev INT,
FOREIGN KEY (ID_elev) REFERENCES Elev(ID_elev);

-- Adăugarea coloanei "Denumire" la tabela "Materie"
ALTER TABLE Materie
ADD Denumire VARCHAR(50);

-- Adăugarea coloanei "MaterieId" în tabela "Absente"
ALTER TABLE Absente
ADD MaterieId INT,
FOREIGN KEY (MaterieId) REFERENCES Materie(MaterieId);

-- Crearea procedurii stocate GetAbs
CREATE PROCEDURE GetAbs
    @ID INT,
    @Denumire VARCHAR(50)
AS
BEGIN
    SELECT Abs_Crt, Tip, Data
    FROM Absente a
    INNER JOIN Elev e ON e.ID_elev = a.ID_elev
    INNER JOIN Materie m ON m.MaterieId = a.MaterieId
    WHERE e.ID_elev = @ID AND m.Denumire = @Denumire
END;

CREATE PROCEDURE AddAbsenta
    @Tip VARCHAR(50),
    @Data DATE,
    @MaterieId INT,
    @ElevId INT
AS
BEGIN
    INSERT INTO Absente (Tip, Data, MaterieId, ID_elev)
    VALUES (@Tip, @Data, @MaterieId, @ElevId)
END;

CREATE PROCEDURE DeleteAbs
    @AbsId INT
AS
BEGIN
    DELETE FROM Absente
    WHERE Abs_Crt = @AbsId
END;

CREATE PROCEDURE GetAllClasses
AS
BEGIN
    SELECT ID, Denumire, Diriginte
    FROM Class
END;

CREATE PROCEDURE GetClass
    @ID INT
AS
BEGIN
    SELECT ID, Denumire
    FROM Class
    WHERE ID = @ID
END;

CREATE PROCEDURE GetClassByName
    @Denumire VARCHAR(50)
AS
BEGIN
    SELECT ID, Denumire
    FROM Class
    WHERE Denumire = @Denumire
END;

CREATE PROCEDURE GetClassesForProfesor
    @ID_profesor INT
AS
BEGIN
    SELECT c.ID, c.Denumire
    FROM Class c
    WHERE c.Diriginte = @ID_profesor
END;

CREATE PROCEDURE GetClassForDiriginte
    @ID_profesor INT
AS
BEGIN
    SELECT c.ID, c.Denumire
    FROM Class c
    WHERE c.Diriginte = @ID_profesor
END;

CREATE PROCEDURE GetStudentByUsername
    @Username VARCHAR(50)
AS
BEGIN
    SELECT e.ID_elev, e.Nume
    FROM Elev e
    INNER JOIN Users u ON e.ID_elev = u.ID_elev
    WHERE u.Username = @Username
END;

CREATE PROCEDURE GetStudentFromClass
    @ClasaID INT
AS
BEGIN
    SELECT e.ID_elev, e.Nume
    FROM Elev e
    INNER JOIN Class c ON e.ClassID = c.ID
    WHERE c.ID = @ClasaID
END;

CREATE PROCEDURE GetStudentByName
    @Name VARCHAR(50)
AS
BEGIN
    SELECT e.ID_elev, e.Nume
    FROM Elev e
    WHERE e.Nume = @Name
END;

CREATE PROCEDURE GetSubjectsForStudent
    @ID INT
AS
BEGIN
    SELECT m.MaterieId, m.Denumire
    FROM Materie m
    INNER JOIN ElevMaterie em ON m.MaterieId = em.MaterieId
    WHERE em.ElevId = @ID
END;

CREATE PROCEDURE GetSubjectsWithTeza
    @ID INT
AS
BEGIN
    SELECT m.MaterieId, m.Denumire
    FROM Materie m
    INNER JOIN ElevMaterie em ON m.MaterieId = em.MaterieId
    WHERE em.ElevId = @ID
    AND em.Teza = 1
END;


CREATE TABLE ElevMaterie (
    ElevId INT,
    MaterieId INT,
    Teza BIT,
    -- Add any other necessary columns
    CONSTRAINT PK_ElevMaterie PRIMARY KEY (ElevId, MaterieId),
    CONSTRAINT FK_ElevMaterie_Elev FOREIGN KEY (ElevId) REFERENCES Elev (ID_elev),
    CONSTRAINT FK_ElevMaterie_Materie FOREIGN KEY (MaterieId) REFERENCES Materie (MaterieId)
);


CREATE PROCEDURE GetSubjectsForClass
    @ID INT,
    @ClasaID INT
AS
BEGIN
    SELECT m.MaterieId, m.Denumire
    FROM Materie m
    INNER JOIN MaterieProfesor mp ON m.MaterieId = mp.MaterieId
    WHERE mp.ProfesorId = @ID
    AND m.ClasaID = @ClasaID
END;

CREATE PROCEDURE GetAllSubjectsForClass
    @clasaId INT
AS
BEGIN
    SELECT m.MaterieId, m.Denumire
    FROM Materie m
    INNER JOIN Class c ON m.MaterieId = c.ID
    WHERE c.ID = @clasaId
END;

CREATE PROCEDURE ModifyGrade
    @NotaID INT,
    @Nota INT
AS
BEGIN
    UPDATE Note
    SET Nota = @Nota
    WHERE Nota_Crt = @NotaID
END;


CREATE PROCEDURE DeleteGrade
    @NotaId INT
AS
BEGIN
    DELETE FROM Note
    WHERE Nota_Crt = @NotaId
END;


CREATE PROCEDURE GetGrade
    @ID INT,
    @Denumire VARCHAR(100)
AS
BEGIN
    SELECT Nota_Crt, Nota, Data, Teza
    FROM Note
    WHERE ID_elev = @ID AND MaterieID = (SELECT MaterieId FROM Materie WHERE Denumire = @Denumire)
END;

CREATE PROCEDURE AddGrades
    @Nota INT,
    @Data DATETIME,
    @Teza VARCHAR(3),
    @Materie INT,
    @Elev INT
AS
BEGIN
    INSERT INTO Note (Nota, Data, Teza, MaterieID, ID_elev)
    VALUES (@Nota, @Data, @Teza, @Materie, @Elev)
END;

CREATE PROCEDURE GetProfesorByUsername
    @Username VARCHAR(100)
AS
BEGIN
    SELECT ID_profesor, Nume
    FROM Profesor
    WHERE Nume = @Username
END;


-- Procedura pentru a obține toți utilizatorii
CREATE PROCEDURE GetAllUsers
AS
BEGIN
    SELECT ID, Username, Password
    FROM Users
END;

-- Procedura pentru a adăuga un utilizator
CREATE PROCEDURE AddUser
    @username VARCHAR(100),
    @password VARCHAR(100)
AS
BEGIN
    INSERT INTO Users (Username, Password)
    VALUES (@username, @password)
END;

-- Procedura pentru a adăuga un elev
CREATE PROCEDURE AddElev
	@ID INT,
    @Nume VARCHAR(100),
    @Clasa INT
AS
BEGIN
   INSERT INTO Elev(ID_elev,Nume, ClassID)
   VALUES (@ID, @Nume, @Clasa);
END;


-- Procedura pentru a adăuga un profesor

-- Procedura pentru a adăuga un diriginte
CREATE PROCEDURE AddDiriginte
	@ID INT,
    @Nume VARCHAR(100),
    @Clasa VARCHAR(100)
AS
BEGIN
    INSERT INTO Profesor(ID_profesor,Nume, Clasa)
    VALUES (@Id,@Nume, @Clasa)
END;

-- Procedura pentru a obține ID-ul utilizatorului după nume de utilizator
CREATE PROCEDURE GetUserIDByUsername
    @username VARCHAR(100)
AS
BEGIN
    SELECT ID
    FROM Users
    WHERE Username = @username
END;

-- Procedura pentru a modifica un utilizator
CREATE PROCEDURE ModifyUser
    @username VARCHAR(100),
    @password VARCHAR(100),
    @id INT,
    @Nume VARCHAR(100),
    @Clasa VARCHAR(100),
    @tip VARCHAR(100)
AS
BEGIN
    UPDATE Users
    SET Username = @username, Password = @password
    WHERE ID = @id;
    
    IF @tip = 'Elev'
    BEGIN
        UPDATE Elev
        SET Nume = @Nume, ClassID = @Clasa
        WHERE ID_elev = @id
    END;
    
    IF @tip = 'Profesor'
    BEGIN
        UPDATE Profesor
        SET Nume = @Nume
        WHERE ID_profesor = @id
    END;
    
    IF @tip = 'Diriginte'
    BEGIN
        UPDATE Diriginte
        SET Nume = @Nume
        WHERE ID_diriginte = @id
    END;
END;

-- Procedura pentru a șterge un utilizator
CREATE PROCEDURE DeleteUser
    @id INT
AS
BEGIN
    DELETE FROM Users
    WHERE ID = @id
END;

-- Procedura pentru a obține un utilizator după ID
CREATE PROCEDURE GetUserById
    @id INT
AS
BEGIN
    SELECT ID, Username, Password
    FROM Users
    WHERE ID = @id
END;


INSERT INTO Users (ID,Username, Password)
VALUES (2,'admin@admin', 'admin');

INSERT INTO Users (ID,Username, Password, ID_profesor)
VALUES (4,'cornel@profesor', 'cornel', 1);

INSERT INTO Profesor(ID_profesor, Nume)
Values (1, 'Cornel')

INSERT INTO Users (ID,Username, Password, ID_elev)
VALUES (3,'vlad@elev', 'vlad', 1);

SELECT * FROM Elev

SELECT * FROM Materie

SELECT * FROM Users

SELECT * FROM Class

SELECT * FROM Profesor

SELECT * FROM Note

SELECT * FROM ElevMaterie

DELETE FROM Users WHERE ID = 26;

DELETE FROM Class WHERE ID=1

DELETE FROM Profesor WHERE ID_profesor=22

INSERT INTO ElevMaterie(ElevId, MaterieId, Teza)
VALUES (2, 3, 6)

INSERT INTO Materie(MaterieId, Denumire)
VALUES (4, 'Desen')

INSERT INTO Elev(ID_elev, Nume, ClassID)
VALUES (5, 'Razvan', 4)

INSERT INTO Profesor(ID_profesor, Nume)
Values (2, 'Maria')

INSERT INTO Users (ID,Username, Password, ID_profesor)
VALUES (1,'maria@diriginte', 'maria', 2);

INSERT INTO Users (ID,Username, Password, ID_profesor)
VALUES (10, 'PopaIon@elev', 'ion', 2);

INSERT INTO Class(ID, Denumire, Diriginte)
Values ( 5, '8', 1)

CREATE PROCEDURE GetDiriginteByUsername
    @Username VARCHAR(100)
AS
BEGIN
    SELECT p.ID_profesor, p.Nume, u.Username
    FROM Profesor p
    INNER JOIN Class c ON p.ID_profesor = c.Diriginte
    INNER JOIN Users u ON u.ID_profesor = p.ID_profesor
    WHERE u.Username = @Username
END;


CREATE PROCEDURE GetAbsNumber
    @ID INT,
    @AbsCount INT OUTPUT
AS
BEGIN
    SELECT @AbsCount = COUNT(*)
    FROM Absente
    WHERE ID_elev = @ID
END;

INSERT INTO Note(Nota_Crt, Nota, Data, Teza, UserID, MaterieId, ID_elev)
Values(4, 10, '2023-09-09', 'Nu', 10, 3, 2)

INSERT INTO Absente(Abs_Crt, Tip, Data, ID_elev, MaterieId)
VALUES (5, 'Nemotivata', '2023.11.20' , 2, 3)

CREATE PROCEDURE AddUser
    @id INT,
    @username VARCHAR(100),
    @password VARCHAR(100)
AS
BEGIN
    INSERT INTO Users (ID, Username, Password)
    VALUES (@id, @username, @password);
END;


CREATE PROCEDURE AddProfesor
    @ID INT,
    @Nume VARCHAR(100),
    @Clasa INT
AS
BEGIN
    INSERT INTO Profesor (ID_profesor, Nume, Clasa)
    VALUES (@ID, @Nume, @Clasa);
END;
