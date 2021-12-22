DROP TABLE Inventory;
DROP TABLE Orders;
DROP TABLE Products;
DROP TABLE Stores;
DROP TABLE Customers;


CREATE TABLE Customers(
CustomerID INT PRIMARY KEY,
FirstName nvarchar(25),
LastName nvarchar(25),
LoginName nvarchar(50))

CREATE TABLE Stores(
StoreNum INT PRIMARY KEY,
StoreLocation nvarchar(50)) 

CREATE TABLE Products(
ProductID INT PRIMARY KEY,
ProductName nvarchar(50) NOT NULL UNIQUE,
Price DECIMAL NOT NULL,
ProductDescription nvarchar(250) NOT NULL);

CREATE TABLE ShoppingCart(
CartID INT PRIMARY KEY,
StoreID INT FOREIGN KEY REFERENCES Stores(StoreNum),
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
CartTotal DECIMAL NOT NULL);

CREATE TABLE ShoppingCartItems(
CartItemID INT PRIMARY KEY,
LineID uniqueidentifier NOT NULL,
CartID INT FOREIGN KEY REFERENCES ShoppingCart(CartID),
ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
ItemQuantity INT,
ItemTotal DECIMAL NOT NULL);

CREATE TABLE Orders(
OrderID INT PRIMARY KEY NOT NULL,
StoreID INT FOREIGN KEY REFERENCES Stores(StoreNum),
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
OrderTotal DECIMAL NOT NULL);

CREATE TABLE OrderItems(
OrderItemID INT PRIMARY KEY,
LineID uniqueidentifier NOT NULL,
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
ItemQuantity INT,
ItemTotal DECIMAL NOT NULL);

CREATE TABLE Inventory(
StoreNum INT FOREIGN KEY REFERENCES Stores(StoreNum),
ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
ProductQuantity INT );


--Creating preset Customers
INSERT INTO Customers
	   (CustomerID, FirstName, LastName, LoginName)
VALUES (1, 'Craig', 'Coles', 'CraigColes');
INSERT INTO Customers
	   (CustomerID, FirstName, LastName, LoginName)
VALUES (2, 'Emily', 'Dishman', 'EmilyDishman');

--Adding store locations to Stores table
INSERT INTO Stores
	  (StoreNum, StoreLocation)
VALUES(1, 'Saginaw, MI');
INSERT INTO Stores
	  (StoreNum, StoreLocation)
VALUES(2, 'Southfield, MI');
INSERT INTO Stores
	  (StoreNum,StoreLocation)
VALUES(3, 'Detriot, MI'); 

--Adding products 
INSERT INTO Products
	  (ProductID, ProductName, Price, ProductDescription)
VALUES(1, 'Roland four-piece drum kit', '350', 'Perfect starter kit for any beginner!');
INSERT INTO Products
	  (ProductID, ProductName, Price, ProductDescription)
VALUES(2, 'Squire Fender Guitar', '250', 'Professional quality, beginner price!');
INSERT INTO Products
	  (ProductID, ProductName, Price, ProductDescription)
VALUES(3, 'Vic Firth drumsticks', '4.50', 'Perfectly weighted for an expeirenced player. More weight and force means more noise!');

--Store one location inventory
INSERT INTO Inventory
	   (StoreNum, ProductID, ProductQuantity)
VALUES (1, 1, 4);
INSERT INTO Inventory
	   (StoreNum, ProductID, ProductQuantity)
VALUES (1, 2, 12);
INSERT INTO Inventory
	   (StoreNum, ProductID, ProductQuantity)
VALUES (1, 3, 23);

--Store two location inventory
INSERT INTO Inventory
	   (StoreNum, ProductID, ProductQuantity)
VALUES (2, 1, 12);
INSERT INTO Inventory
	   (StoreNum, ProductID, ProductQuantity)
VALUES (2, 2, 4);
INSERT INTO Inventory
	   (StoreNum, ProductID, ProductQuantity)
VALUES (2, 3, 32);

--Store three location inventory
INSERT INTO Inventory
	   (StoreNum, ProductID, ProductQuantity)
VALUES (3, 1, 2);
INSERT INTO Inventory
	   (StoreNum, ProductID, ProductQuantity)
VALUES (3, 2, 15);
INSERT INTO Inventory
	   (StoreNum, ProductID, ProductQuantity)
VALUES (3, 3, 34);



SELECT * FROM Inventory;

--add IDs
SELECT MAX(CustomerID) + 1
FROM Customers


--Join example
SELECT StoreLocation, ProductName, ProductQuantity
FROM Inventory 
LEFT OUTER JOIN Stores
ON Stores.StoreNum = Inventory.StoreNum
LEFT OUTER JOIN Products
ON Products.ProductID = Inventory.ProductID
WHERE ProductName LIKE '%drum%';


 