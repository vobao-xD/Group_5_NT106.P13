create database bus_server_prod
GO

use bus_server_prod
GO
------------------------------------------------
-- table user
create table _User_
(
	UserId INT NOT NULL PRIMARY KEY,
	UserName varchar(100),
	Phone varchar(100),
	IsActive BIT
)
---------------------------------------------
-- UserRole
create table UserRole
(
	UserId INT NOT NULL PRIMARY KEY,
	UserTitleId INT NOT NULL
)
---------------------------------------------
-- UserTitle
create table UserTitle
(
	UserTitleId INT NOT NULL PRIMARY KEY,
	UserTitleName VARCHAR(100)
)

---------------------------------------------
-- Customer
create table Customer
(
	CustomerId int not null primary key,
	CustomerName varchar(100),
	CustomerTypeId int,
	Phone varchar(100),
	IsActive bit,
	IsDeleted bit
)

---------------------------------------------
-- CustomerType
create table CustomerType
(
	CustomerTypeId int not null primary key,
	CustomerTypeName varchar(100),
	IsActive bit
)

---------------------------------------------
-- Driver
create table Driver
(
	DriverId int not null primary key,
	DriverName varchar(100),
	Phone varchar(100),
	IsActive bit,
	IsDeleted bit
)

---------------------------------------------
-- Staff
create table Staff
(
	StaffId int not null primary key,
	StaffName varchar(100),
	Phone varchar(100),
	IsActive bit,
	IsDeleted bit
)

---------------------------------------------
-- Car
create table Car
(
	CarId int not null primary key,
	PlateNumber varchar(100), -- bien so xe
	NumberOfSeat int,
	DriverId int,
	IsActive bit
)

---------------------------------------------
-- Trip -- hanh trinh cua chuyen xe
create table Trip
(
	TripId int not null primary key,
	TripName varchar(100), 
	DepartLocation varchar(100),
	ArriveLocation varchar(100),
	Route_ varchar(100), -- route co the la mang JSON mang diem dau va diem cuoi
	TripStatusId int,
	CarId int
)

---------------------------------------------
-- TripStatus -- hoan thanh hay chua hoan thanh chuyen
create table TripStatus
(
	TripStatusId int not null primary key,
	TripStatusName varchar(100)
)

---------------------------------------------
-- Ticket -- mỗi một người sẽ mua một lượt vé (có thể mua nhiều) thì sẽ thêm 1 bộ ở bảng này
		  -- NumberOfTicket thể hiện số lượng vé mà người đó mua 
create table Ticket
(
	TicketId int not null primary key,
	NumberOfTicket int,
	TimeTicketAvailabel varchar(100), -- thoi gian ma ve co the thay doi (24h,48h,...)
	TypeOfTicket int, -- loai ve (first class, business, economic,...)
	SeasonId int,
	IsActive bit,
	CustomerId int
)

---------------------------------------------
-- TicketType
create table TicketType
(
	TicketTypeId int not null primary key,
	TicketTypeName varchar(100), -- firstclass, business, economic
	StandardTicketPrice money
)

---------------------------------------------
-- Season
create table Season
(
	SeasonId int not null primary key,
	SeasonName varchar(100), -- firstclass, business, economic
	BaseTicketPrice money
)

---------------------------------------------
-- Feedback
create table Feedback
(
	FeedbackId int not null primary key,
	CustomerId int,
	Description_ varchar(100)
)