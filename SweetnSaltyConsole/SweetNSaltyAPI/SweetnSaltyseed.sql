CREATE DATABASE SweetnSalty;
DROP TABLE PersonFlavorJunction;
DROP TABLE Flavor;
DROP TABLE Person;

CREATE TABLE Person(
PersonID INT PRIMARY KEY IDENTITY,
FirstName nvarchar(25),
LastName nvarchar(25)
);

CREATE TABLE Flavor(
FlavorID INT PRIMARY KEY IDENTITY,
FlavorName nvarchar(25)
);

CREATE TABLE PersonFlavorJunction(
PersonFlavorID INT PRIMARY KEY,
PersonID INT FOREIGN KEY REFERENCES Person(PersonID),
FlavorID INT FOREIGN KEY REFERENCES Flavor(FlavorID)
);

INSERT INTO Flavor (FlavorName) VALUES ('Sweet');
SELECT TOP 1 PersonID FROM Person ORDER BY PersonID DESC;

SELECT TOP 1 p.PersonID, f.FlavorID 
FROM Person p 
LEFT OUTER JOIN Flavor f 
ON f.FlavorName = 'Sweet' 
ORDER BY PersonID DESC;

