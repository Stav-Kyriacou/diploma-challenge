IF OBJECT_ID('Order') IS NOT NULL
DROP TABLE [Order]
GO
IF OBJECT_ID('Customer') IS NOT NULL
DROP TABLE Customer
GO
IF OBJECT_ID('Product') IS NOT NULL
DROP TABLE Product
GO
IF OBJECT_ID('Region') IS NOT NULL
DROP TABLE Region
GO
IF OBJECT_ID('Shipping') IS NOT NULL
DROP TABLE Shipping
GO
IF OBJECT_ID('Category') IS NOT NULL
DROP TABLE Category
GO
IF OBJECT_ID('Segment') IS NOT NULL
DROP TABLE Segment
GO

CREATE TABLE Region
(
    Region NVARCHAR(20) NOT NULL,
    PRIMARY KEY (Region)
);
GO
CREATE TABLE Shipping
(
    ShipMode NVARCHAR(50) NOT NULL,
    PRIMARY KEY (ShipMode)
);
GO
CREATE TABLE Category
(
    CatID INT NOT NULL,
    CatName NVARCHAR(50) NOT NULL,
    PRIMARY KEY (CatID)
);
GO
CREATE TABLE Segment
(
    SegID INT NOT NULL,
    SegName NVARCHAR(50) NOT NULL,
    PRIMARY KEY (SegID)
);
GO
CREATE TABLE Product
(
    ProdID NVARCHAR(30) NOT NULL,
    [Description] NVARCHAR(100) NOT NULL,
    UnitPrice FLOAT NOT NULL,
    CatID INT NOT NULL,
    PRIMARY KEY (ProdID),
    FOREIGN KEY (CatID) REFERENCES Category (CatID)
);
GO
CREATE TABLE Customer
(
    CustID NVARCHAR(20) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Country NVARCHAR(50) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    [State] NVARCHAR(50) NOT NULL,
    PostCode INT NOT NULL,
    SegID INT NOT NULL,
    Region NVARCHAR(20) NOT NULL,
    PRIMARY KEY (CustID),
    FOREIGN KEY (SegID) REFERENCES Segment (SegID),
    FOREIGN KEY (Region) REFERENCES Region (Region)
);
GO
CREATE TABLE [Order]
(
    OrderID INT NOT NULL,
    OrderDate NVARCHAR(20) NOT NULL,
    Quantity INT NOT NULL,
    ShipDate NVARCHAR(20) NOT NULL,
    CustID NVARCHAR(20) NOT NULL,
    ProdID NVARCHAR(30) NOT NULL,
    ShipMode NVARCHAR(50) NOT NULL,
    PRIMARY KEY (OrderID),
    FOREIGN KEY (CustID) REFERENCES Customer (CustID),
    FOREIGN KEY (ProdID) REFERENCES Product (ProdID),
    FOREIGN KEY (ShipMode) REFERENCES Shipping (ShipMode)
);
GO

INSERT INTO Region
    (Region)
VALUES
    ('South'),
    ('Central'),
    ('West'),
    ('East'),
    ('North');

INSERT INTO Shipping
    (ShipMode)
VALUES
    ('Second Class'),
    ('Standard Class'),
    ('First Class'),
    ('Overnight Express');

INSERT INTO Segment
    (SegID, SegName)
VALUES
    (1, 'Consumer'),
    (2, 'Corporate'),
    (3, 'Home Office');

INSERT INTO Category
    (CatID, CatName)
VALUES
    (1, 'Furniture'),
    (2, 'Office Supplies'),
    (3, 'Technology');

INSERT INTO Product
    (ProdID, CatID, [Description], UnitPrice)
VALUES
    ('FUR-BO-10001798', 1, 'Bush Somerset Collection Bookcase', 261.96),
    ('FUR-CH-10000454', 3, 'Mitel 5320 IP Phone VoIP phone', 731.94),
    ('OFF-LA-10000240', 2, 'Self-Adhesive Address Labels for Typewriters by Universal', 14.62);

INSERT INTO Customer
    (CustID, FullName, SegID, Country, City, [State], PostCode, Region)
VALUES
    ('CG-12520', 'Claire Gute', 1, 'United States', 'Henderson', 'Oklahoma', 42420, 'Central'),
    ('DV-13045', 'Darrin Van Huff', 2, 'United States', 'Los Angeles', 'California', 90036, 'West'),
    ('SO-20335', 'Sean O''Donnell', 1, 'United States', 'Fort Lauderdale', 'Florida', 33311, 'South'),
    ('BH-11710', 'Brosina Hoffman', 3, 'United States', 'Los Angeles', 'California', 90032, 'West');

INSERT INTO [Order]
    (OrderID, CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode)
VALUES
    (1, 'CG-12520', 'FUR-BO-10001798', '2016/11/08', 2, '2016/11/11', 'Second Class'),
    (2, 'CG-12520', 'FUR-CH-10000454', '2016/11/08', 3, '2016/11/11', 'Second Class'),
    (3, 'CG-12520', 'OFF-LA-10000240', '2016/06/12', 2, '2016/06/16', 'Second Class'),
    (4, 'DV-13045', 'OFF-LA-10000240', '2015/11/21', 2, '2015/11/26', 'Second Class'),
    (5, 'DV-13045', 'OFF-LA-10000240', '2014/10/11', 1, '2014/10/15', 'Standard Class'),
    (6, 'DV-13045', 'FUR-CH-10000454', '2016/11/12', 9, '2016/11/16', 'Standard Class'),
    (7, 'SO-20335', 'OFF-LA-10000240', '2016/09/02', 5, '2016/09/08', 'Standard Class'),
    (8, 'SO-20335', 'FUR-BO-10001798', '2017/08/25', 2, '2017/08/29', 'Overnight Express'),
    (9, 'SO-20335', 'FUR-CH-10000454', '2017/06/22', 2, '2017/06/26', 'Standard Class'),
    (10, 'SO-20335', 'FUR-BO-10001798', '2017/05/01', 3, '2017/05/02', 'First Class');