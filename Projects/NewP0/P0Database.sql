CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY,
FirstName nvarchar(25),
LastName nvarchar(25),
LoginName nvarchar(50),
Pass nvarchar(50));

CREATE TABLE Stores(
StoreNum INT PRIMARY KEY IDENTITY,
StoreLocation nvarchar(50)) 

CREATE TABLE Products(
ProductID INT PRIMARY KEY IDENTITY,
ProductName nvarchar(50) NOT NULL UNIQUE,
Price DECIMAL NOT NULL,
ProductDescription nvarchar(250) NOT NULL);

CREATE TABLE PastOrders(
LineID INT PRIMARY KEY IDENTITY, 
OrderID uniqueidentifier NOT NULL,
StoreID INT FOREIGN KEY REFERENCES Stores(StoreNum),
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
OrderTotal DECIMAL NOT NULL);

CREATE TABLE Inventory(
StoreNum INT FOREIGN KEY REFERENCES Stores(StoreNum),
ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
ProductQuantity INT );

--Creating preset Customers
INSERT INTO Customers
	   (FirstName, LastName, LoginName)
VALUES ('Craig', 'Coles', 'CraigColes');
INSERT INTO Customers
	   (FirstName, LastName, LoginName)
VALUES ('Emily', 'Dishman', 'EmilyDishman');

--Adding store locations to Stores table
INSERT INTO Stores
	  (StoreLocation)
VALUES('Saginaw, MI');
INSERT INTO Stores
	  (StoreLocation)
VALUES('Southfield, MI');
INSERT INTO Stores
	  (StoreLocation)
VALUES('Detriot, MI'); 

--Adding products 
--INSERT INTO Products
	   --(ProductName, Price, ProductDescription)