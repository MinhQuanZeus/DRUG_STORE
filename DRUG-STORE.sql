﻿DROP DATABASE DRUG_STORE
USE master
Create DATABASE DRUG_STORE
GO
USE DRUG_STORE
GO




CREATE TABLE [Staffs] (
	StaffID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(30) NOT NULL,
	Username varchar(30) NOT NULL,
	Password varchar(30) NOT NULL,
	Address varchar(50),
	Phone nchar(15),
	IsManager bit,
	StoreID int NOT NULL,
  CONSTRAINT [PK_STAFFS] PRIMARY KEY CLUSTERED
  (
  [StaffID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ProductTypes] (
	ProductTypeID int IDENTITY(1,1) NOT NULL,
	ProductTypeName nvarchar(50) NOT NULL,
  CONSTRAINT [PK_PRODUCTTYPES] PRIMARY KEY CLUSTERED
  (
  [ProductTypeID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Products] (
	ProductID int IDENTITY(1,1) NOT NULL,
	ProductTypeID int NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(max),
	Guide nvarchar(max),
	StoreID int NOT NULL,
	Unit varchar(30) NOT NULL,
	Quantity int NOT NULL DEFAULT '0',
	Price real NOT NULL,
	SellPrice real NOT NULL,
	Status int NOT NULL DEFAULT '0',
  CONSTRAINT [PK_PRODUCTS] PRIMARY KEY CLUSTERED
  (
  [ProductID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Stores] (
	StoreID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
  CONSTRAINT [PK_STORES] PRIMARY KEY CLUSTERED
  (
  [StoreID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Customers] (
	CustomerID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Address nvarchar(100),
	Phone int,
	StoreID int NOT NULL,
  CONSTRAINT [PK_CUSTOMERS] PRIMARY KEY CLUSTERED
  (
  [CustomerID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Bills] (
	BillID int IDENTITY(1,1) NOT NULL,
	CreateDate date NOT NULL,
	Total real NOT NULL,
	StaffID int NOT NULL,
	CustomerID int NOT NULL,
	isDebt bit NOT NULL DEFAULT '0',
  CONSTRAINT [PK_BILLS] PRIMARY KEY CLUSTERED
  (
  [BillID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [BillDetails] (
	BillDetailID int IDENTITY(1,1) NOT NULL,
	BillID int NOT NULL,
	ProductID int NOT NULL,
	Quantity int NOT NULL,
	Capital real NOT NULL,
	RegisteredNumberDetail varchar(100),
  CONSTRAINT [PK_BILLDETAILS] PRIMARY KEY CLUSTERED
  (
  [BillDetailID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Imports] (
	ImportID int IDENTITY(1,1) NOT NULL,
	ImportDate date NOT NULL,
	Total real NOT NULL,
	StaffID int NOT NULL,
  CONSTRAINT [PK_IMPORTS] PRIMARY KEY CLUSTERED
  (
  [ImportID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ImportDetails] (
	ImportDetailID int IDENTITY(1,1) NOT NULL,
	ImportID int NOT NULL,
	ProductID int NOT NULL,
	Quantity int NOT NULL,
	Price real NOT NULL,
  CONSTRAINT [PK_IMPORTDETAILS] PRIMARY KEY CLUSTERED
  (
  [ImportDetailID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Warehouse] (
	ID int IDENTITY(1,1) NOT NULL,
	ProductID int NOT NULL,
	RegisteredNumber varchar(30) NOT NULL,
	ExpiryDate date NOT NULL,
	Quantity int NOT NULL DEFAULT '0',
	ImportDate date NOT NULL,
  CONSTRAINT [PK_WAREHOUSE] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ProductUnit] (
	UnitID int IDENTITY(1,1) NOT NULL,
	ProductID int NOT NULL,
	UnitName nvarchar(30) NOT NULL,
	ConversionValue int NOT NULL,
	SellPrice real NOT NULL DEFAULT '0',
  CONSTRAINT [PK_PRODUCTUNIT] PRIMARY KEY CLUSTERED
  (
  [UnitID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [Staffs] WITH CHECK ADD CONSTRAINT [Staffs_fk0] FOREIGN KEY ([StoreID]) REFERENCES [Stores]([StoreID])
ON UPDATE CASCADE
GO
ALTER TABLE [Staffs] CHECK CONSTRAINT [Staffs_fk0]
GO


ALTER TABLE [Products] WITH CHECK ADD CONSTRAINT [Products_fk0] FOREIGN KEY ([ProductTypeID]) REFERENCES [ProductTypes]([ProductTypeID])
ON UPDATE CASCADE
GO
ALTER TABLE [Products] CHECK CONSTRAINT [Products_fk0]
GO
ALTER TABLE [Products] WITH CHECK ADD CONSTRAINT [Products_fk1] FOREIGN KEY ([StoreID]) REFERENCES [Stores]([StoreID])
ON UPDATE CASCADE
GO
ALTER TABLE [Products] CHECK CONSTRAINT [Products_fk1]
GO


ALTER TABLE [Customers] WITH CHECK ADD CONSTRAINT [Customers_fk0] FOREIGN KEY ([StoreID]) REFERENCES [Stores]([StoreID])
ON UPDATE CASCADE
GO
ALTER TABLE [Customers] CHECK CONSTRAINT [Customers_fk0]
GO

ALTER TABLE [Bills] WITH CHECK ADD CONSTRAINT [Bills_fk0] FOREIGN KEY ([StaffID]) REFERENCES [Staffs]([StaffID])
ON UPDATE CASCADE
GO
ALTER TABLE [Bills] CHECK CONSTRAINT [Bills_fk0]
GO
ALTER TABLE [Bills] WITH CHECK ADD CONSTRAINT [Bills_fk1] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID])

GO
ALTER TABLE [Bills] CHECK CONSTRAINT [Bills_fk1]
GO

ALTER TABLE [BillDetails] WITH CHECK ADD CONSTRAINT [BillDetails_fk0] FOREIGN KEY ([BillID]) REFERENCES [Bills]([BillID])
ON UPDATE CASCADE
GO
ALTER TABLE [BillDetails] CHECK CONSTRAINT [BillDetails_fk0]
GO
ALTER TABLE [BillDetails] WITH CHECK ADD CONSTRAINT [BillDetails_fk1] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ProductID])

GO
ALTER TABLE [BillDetails] CHECK CONSTRAINT [BillDetails_fk1]
GO

ALTER TABLE [Imports] WITH CHECK ADD CONSTRAINT [Imports_fk0] FOREIGN KEY ([StaffID]) REFERENCES [Staffs]([StaffID])
ON UPDATE CASCADE
GO
ALTER TABLE [Imports] CHECK CONSTRAINT [Imports_fk0]
GO

ALTER TABLE [ImportDetails] WITH CHECK ADD CONSTRAINT [ImportDetails_fk0] FOREIGN KEY ([ImportID]) REFERENCES [Imports]([ImportID])
ON UPDATE CASCADE
GO
ALTER TABLE [ImportDetails] CHECK CONSTRAINT [ImportDetails_fk0]
GO
ALTER TABLE [ImportDetails] WITH CHECK ADD CONSTRAINT [ImportDetails_fk1] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ProductID])

GO
ALTER TABLE [ImportDetails] CHECK CONSTRAINT [ImportDetails_fk1]
GO

ALTER TABLE [Warehouse] WITH CHECK ADD CONSTRAINT [Warehouse_fk0] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ProductID])
ON UPDATE CASCADE
GO
ALTER TABLE [Warehouse] CHECK CONSTRAINT [Warehouse_fk0]
GO

ALTER TABLE [ProductUnit] WITH CHECK ADD CONSTRAINT [ProductUnit_fk0] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ProductID])
ON UPDATE CASCADE
GO
ALTER TABLE [ProductUnit] CHECK CONSTRAINT [ProductUnit_fk0]
GO

select * from Stores
Insert into Stores values(N'Tâm Bình')
Insert Into Staffs values(N'Minh Quân', 'minhquan','123456','Ha Noi','01649658689',0,1)
Insert Into Staffs values(N'Minh Quân', '1','1','Ha Noi','01649658689',0,1)

insert into ProductTypes values(N'Dị Ứng')
insert into ProductTypes values(N'Thần Kinh')

select * from Products