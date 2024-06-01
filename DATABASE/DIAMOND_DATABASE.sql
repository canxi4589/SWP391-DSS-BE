CREATE DATABASE DIAMOND_DB
GO
USE DIAMOND_DB

GO
-- Table: Size
CREATE TABLE Size (
    sizeId INT IDENTITY PRIMARY KEY,
    sizeName VARCHAR(255) NOT NULL,
    sizeValue VARCHAR(255) NOT NULL,
	sizePrice Money
);
GO
-- Table: MetalType
CREATE TABLE Metaltype (
    metaltypeId INT IDENTITY PRIMARY KEY,
    metaltypeName VARCHAR(255) NOT NULL,
    metaltypePrice Money
);
GO
-- Table: Category
CREATE TABLE Category (
    categoryId INT IDENTITY PRIMARY KEY,
    categoryName VARCHAR(255) NOT NULL
);
GO
-- Table: SubCategory
CREATE TABLE SubCategory (
    subCategoryId INT IDENTITY PRIMARY KEY,
    subCategoryName VARCHAR(255) NOT NULL,
    categoryId INT,
    FOREIGN KEY (categoryId) REFERENCES Category(categoryId)
);
GO
-- Table: Cover
CREATE TABLE Cover (
    coverId INT IDENTITY PRIMARY KEY,
    coverName VARCHAR(255) NOT NULL,
    status VARCHAR(50),
    unitPrice Money,
    subCategoryId INT NOT NULL,
    categoryId INT NOT NULL,
    FOREIGN KEY (subCategoryId) REFERENCES SubCategory(subCategoryId),
    FOREIGN KEY (categoryId) REFERENCES Category(categoryId)
);
GO
-- Table: CoverSize
CREATE TABLE CoverSize (
    sizeId INT,
    coverId INT,
    status VARCHAR(50),
    PRIMARY KEY (sizeId, coverId),
    FOREIGN KEY (sizeId) REFERENCES Size(sizeId),
    FOREIGN KEY (coverId) REFERENCES Cover(coverId)
);
GO
-- Table: CoverMetalType
CREATE TABLE CoverMetaltype (
    metaltypeId INT,
    coverId INT,
    status VARCHAR(50),
    PRIMARY KEY (metaltypeId, coverId),
    FOREIGN KEY (metaltypeId) REFERENCES Metaltype(metaltypeId),
    FOREIGN KEY (coverId) REFERENCES Cover(coverId)
);
GO
-- Table: Diamond
CREATE TABLE Diamond (
    diamondId INT IDENTITY PRIMARY KEY,
    diamondName VARCHAR(255) NOT NULL,
    caratWeight DECIMAL(5, 2) NOT NULL,
    color VARCHAR(50) NOT NULL,
    clarity VARCHAR(50) NOT NULL,
    cut VARCHAR(50) NOT NULL,
    shape VARCHAR(50) NOT NULL,
    price Money NOT NULL
);
GO
-- Table: Product
CREATE TABLE Product (
    productId INT IDENTITY PRIMARY KEY,
    productName NVARCHAR(255) NOT NULL,
    unitPrice Money,
    diamondId INT,
    coverId INT,
	metaltypeId INT,
	sizeId INT,
	PP VARCHAR(50),
    FOREIGN KEY (diamondId) REFERENCES Diamond(diamondId),
    FOREIGN KEY (coverId) REFERENCES Cover(coverId),
	FOREIGN KEY (metaltypeId) REFERENCES Metaltype(metaltypeId),
    FOREIGN KEY (sizeId) REFERENCES Size(sizeId)
);
GO
-- Table: User
CREATE TABLE [User] (
    userId INT IDENTITY PRIMARY KEY,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    status VARCHAR(50) NOT NULL,
    role VARCHAR(50) NOT NULL
);
GO
-- Table: Customer

CREATE TABLE Customer (
    cusId INT PRIMARY KEY,
    cusFirstName VARCHAR(255) NOT NULL,
    cusLastName VARCHAR(255) NOT NULL,
    cusPhoneNum VARCHAR(20) NOT NULL,
    FOREIGN KEY (cusId) REFERENCES [User](userId)
);
GO
-- Table: Manager
CREATE TABLE Manager (
    manId INT  PRIMARY KEY,
    manName VARCHAR(255) NOT NULL,
    manPhone VARCHAR(20),
    FOREIGN KEY (manId) REFERENCES [User](userId)
);
GO
-- Table: SaleStaff
CREATE TABLE SaleStaff (
    sStaffId INT  PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    phone VARCHAR(20),
    email VARCHAR(255),
    managerId INT,
    FOREIGN KEY (sStaffId) REFERENCES [User](userId),
    FOREIGN KEY (managerId) REFERENCES Manager(manId)
);
GO
-- Table: DeliveryStaff
CREATE TABLE DeliveryStaff (
    dStaffId INT  PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    managerId INT,
    FOREIGN KEY (dStaffId) REFERENCES [User](userId),
    FOREIGN KEY (managerId) REFERENCES Manager(manId)
);
GO
-- Table: Cart
CREATE TABLE Cart (
    cartId INT PRIMARY KEY,
    cartQuantity INT NOT NULL,
    FOREIGN KEY (cartId) REFERENCES Customer(cusId)
);
GO
-- Table: CartProduct
CREATE TABLE CartProduct (
    cartId INT,
    productId INT,
    quantity INT NOT NULL,
    PRIMARY KEY (cartId, productId),
    FOREIGN KEY (cartId) REFERENCES Cart(cartId),
    FOREIGN KEY (productId) REFERENCES Product(productId)
);
GO
CREATE TABLE favorite (
    favoriteId INT PRIMARY KEY,
    quantity INT NOT NULL,
    FOREIGN KEY (favoriteId) REFERENCES Customer(cusId)
);

CREATE TABLE favoriteProduct (
    favoriteId INT,
    productId INT,
    quantity INT NOT NULL,
    PRIMARY KEY (favoriteId, productId),
    FOREIGN KEY (favoriteId) REFERENCES favorite(favoriteId),
    FOREIGN KEY (productId) REFERENCES Product(productId)
);
GO
-- Table: Address
CREATE TABLE Address (
    addressId INT PRIMARY KEY,
    street VARCHAR(255),
    state VARCHAR(50),
    city VARCHAR(50),
    zipCode VARCHAR(20),
    country VARCHAR(50),
    FOREIGN KEY (addressId) REFERENCES Customer(cusId)
);
GO
-- Table: ShippingMethod
CREATE TABLE ShippingMethod (
    shippingMethodId INT IDENTITY PRIMARY KEY,
    methodName VARCHAR(255) NOT NULL,
    cost DECIMAL(10, 2) NOT NULL,
    description VARCHAR(255),
    date DATE
);
GO
-- Table: Order
CREATE TABLE [Order] (
    orderId INT IDENTITY PRIMARY KEY,
    orderDate DATETIME NOT NULL,
    totalAmount DECIMAL(10, 2) NOT NULL,
    status VARCHAR(50),
    cusId INT,
    shippingMethodId INT,
    FOREIGN KEY (cusId) REFERENCES Customer(cusId),
    FOREIGN KEY (shippingMethodId) REFERENCES ShippingMethod(shippingMethodId)
);
GO
-- Table: ProductOrder
CREATE TABLE ProductOrder (
    productId INT,
    orderId INT,
    quantity INT NOT NULL,
    PRIMARY KEY (productId, orderId),
    FOREIGN KEY (productId) REFERENCES Product(productId),
    FOREIGN KEY (orderId) REFERENCES [Order](orderId)
);
GO
-- Table: Shipping
CREATE TABLE Shipping (
    shippingId INT IDENTITY PRIMARY KEY,
    status VARCHAR(50),
    orderId INT,
    saleStaffId INT,
    deliveryStaffId INT,
    FOREIGN KEY (orderId) REFERENCES [Order](orderId),
    FOREIGN KEY (saleStaffId) REFERENCES SaleStaff(sStaffId),
    FOREIGN KEY (deliveryStaffId) REFERENCES DeliveryStaff(dStaffId)
);
GO
-- Table: Review
CREATE TABLE Review (
    reviewId INT IDENTITY PRIMARY KEY,
    review TEXT,
    rating INT,
    reviewDate DATE,
    cusId INT,
    FOREIGN KEY (cusId) REFERENCES Customer(cusId)
);
GO
-- Table: Voucher
CREATE TABLE Voucher (
    voucherId INT IDENTITY PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    expDate DATE NOT NULL,
	quantity INT,
	rate INT,
    cusId INT,
    FOREIGN KEY (cusId) REFERENCES Customer(cusId)
);
GO
-- Table: CustomerVoucher
CREATE TABLE CustomerVoucher (
    cusId INT,
    voucherId INT,
    PRIMARY KEY (cusId, voucherId),
    FOREIGN KEY (cusId) REFERENCES Customer(cusId),
    FOREIGN KEY (voucherId) REFERENCES Voucher(voucherId)
);	

-- Disable foreign key constraints temporarily
EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all";

-- Delete data from leaf tables first
DELETE FROM CoverSize;
DELETE FROM CoverMetalType;
DELETE FROM CartProduct;
DELETE FROM ProductOrder;
DELETE FROM CustomerVoucher;
DELETE FROM Review;
DELETE FROM Voucher;
DELETE FROM Address;

-- Delete data from tables with foreign keys
DELETE FROM Cart;
DELETE FROM Shipping;
DELETE FROM [Order];
DELETE FROM SaleStaff;
DELETE FROM DeliveryStaff;
DELETE FROM Manager;
DELETE FROM Customer;

-- Delete data from tables without foreign keys
DELETE FROM Product;
DELETE FROM Size;
DELETE FROM MetalType;
DELETE FROM Cover;
DELETE FROM SubCategory;
DELETE FROM Category;
DELETE FROM Diamond;
DELETE FROM ShippingMethod;

-- Finally, delete data from the User table
DELETE FROM [User];

-- Re-enable foreign key constraints
EXEC sp_MSforeachtable "ALTER TABLE ? CHECK CONSTRAINT all";