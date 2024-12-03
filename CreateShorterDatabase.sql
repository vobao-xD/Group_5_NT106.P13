create database bus_server_prod
GO

use bus_server_prod
GO

-- table user
CREATE TABLE Users
(
	UserId INT NOT NULL PRIMARY KEY,
	UserName VARCHAR(100),
	UserPwd VARCHAR(100),
	UserFullName nVARCHAR(100),
	UserPhone VARCHAR(20),
	UserEmail VARCHAR(50)	
)

-- Driver
CREATE TABLE Drivers
(
	DriverId INT not null PRIMARY KEY,
	DriverFullName NVARCHAR(100),
	DriverPhone VARCHAR(20)
)

-- Staff
CREATE TABLE Staffs --> For administrative purposes only.
(
	StaffId INT not null PRIMARY KEY,
	StaffUserName VARCHAR(100),
	StaffPwd VARCHAR(100),
	StaffFullName NVARCHAR(100),
	StaffPhone VARCHAR(20),
	StaffEmail VARCHAR(50)	
)

-- Vehicle
CREATE TABLE Cars
(
	CarId INT not null PRIMARY KEY,
	PlateNumber VARCHAR(20),
	NumberOfSeat INT,
	DriverId INT
)

--Location
CREATE TABLE Locations
(
	LocationId INT not null PRIMARY KEY,
	LocationName VARCHAR(100)
)

-- Trip -- hanh trinh cua chuyen xe
CREATE TABLE Trips
(
	TripId INT not null PRIMARY KEY,
	TripName NVARCHAR(100), 
	DepartLocation INT, --> Foreign Key Locations.LocationId
	ArriveLocation INT, --> Foreign Key Locations.LocationId
	DepartTime smalldatetime,
	Route_ VARCHAR(100), -- route co the la JSON mang cac diem dung, diem tra khach doc duong...
	TripStatusId INT,
	CarId INT
)


-- TripStatus -- hoan thanh hay chua hoan thanh chuyen
CREATE TABLE TripStatus
(
	TripStatusId BIT not null PRIMARY KEY,
	TripStatusName NVARCHAR(100) --> Completed/Not completed
)

---------------------------------------------
-- Ticket -- mỗi một người sẽ mua một lượt vé (có thể mua nhiều) thì sẽ thêm 1 bộ ở bảng này
		  -- NumberOfTicket thể hiện số lượng vé mà người đó mua (nah ko can dau)
CREATE TABLE Tickets
(
	TicketId INT not null,
	TicketTypeId INT not null,
	UserID INT not null,
	TripId INT not null,
	SeatNumber VARCHAR(3),
	TypeOfTicket INT,
	TotalPrice MONEY
	
	PRIMARY KEY (TicketId, UserID, TripId)
)

---------------------------------------------
-- TicketType
CREATE TABLE TicketType
(
	TicketTypeId INT not null PRIMARY KEY,
	TicketTypeName NVARCHAR(30), -- 3 = firstclass, 2 = business, 1 = economic
	Price MONEY
)

-- Feedback
CREATE TABLE UserFeedback
(
	FeedbackId INT not null PRIMARY KEY,
	UserId INT,
	Description_ NVARCHAR(1000)
)