USE bus_server_prod
GO

---------------------------------------------
-- UserRole
CREATE TABLE UserRoles
(
    UserRoleId INT NOT NULL PRIMARY KEY,
    UserRoleName VARCHAR(50) NOT NULL
)
GO

------------------------------------------------
-- User
CREATE TABLE Users
(
	UserId INT NOT NULL PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    UserPwd VARCHAR(50) NOT NULL, 
    UserFullName NVARCHAR(100), 
    UserEmail VARCHAR(50), 
    UserRoleId INT NOT NULL DEFAULT 1,
	CONSTRAINT FK_UserRoleId FOREIGN KEY (UserRoleId) REFERENCES UserRoles(UserRoleId)
)
GO

---------------------------------------------
-- BusStatus
CREATE TABLE BusStatus
(
    BusStatusId INT NOT NULL PRIMARY KEY,
    BusStatusName NVARCHAR(50) NOT NULL
)
GO

---------------------------------------------
-- Bus
CREATE TABLE Buses
(
	LicensePlate VARCHAR(20) NOT NULL PRIMARY KEY,
	NumberOfSeat INT NOT NULL DEFAULT 30 CHECK (NumberOfSeat > 0),
	NumberOfSeatLeft INT NOT NULL,
	DriverId INT,
	BusStatusId INT NOT NULL DEFAULT 1,
	CONSTRAINT FK_DriverId FOREIGN KEY (DriverId) REFERENCES Users(UserId),
    CONSTRAINT FK_BusStatusId FOREIGN KEY (BusStatusId) REFERENCES BusStatus(BusStatusId),
	CONSTRAINT CK_NumberOfSeatLeft CHECK (NumberOfSeatLeft >= 0 AND NumberOfSeatLeft <= NumberOfSeat)
)
GO

-- Trigger cho driver: driver chỉ có thể là user có role driver (3)
CREATE TRIGGER TRG_CheckDriverRole
ON Buses
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Inserted AS I
        JOIN Users AS U ON I.DriverId = U.UserId
        WHERE U.UserRoleId <> 3
    )
    BEGIN
        RAISERROR ('DriverId must be an ID of a Driver', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO

---------------------------------------------
-- TripStatus
create table TripStatus
(
	TripStatusId INT NOT NULL PRIMARY KEY,
	TripStatusName NVARCHAR(50) NOT NULL
)

---------------------------------------------
-- Trip
CREATE TABLE Trips
(
    TripId INT NOT NULL PRIMARY KEY,
    TripName VARCHAR(100) NOT NULL,
    DepartLocation VARCHAR(100) NOT NULL,
    ArriveLocation VARCHAR(100) NOT NULL,
    DepartTime DATETIME NOT NULL CHECK (DepartTime > GETDATE()),
    TripStatusId INT NOT NULL DEFAULT 1,
    BusLicensePlate VARCHAR(20) NOT NULL,
    CONSTRAINT FK_TripStatus FOREIGN KEY (TripStatusId) REFERENCES TripStatus(TripStatusId),
    CONSTRAINT FK_BusLicensePlate FOREIGN KEY (BusLicensePlate) REFERENCES Buses(LicensePlate),
	CONSTRAINT CK_ArriveLocation CHECK (DepartLocation <> ArriveLocation)
)





INSERT INTO UserRoles (UserRoleID, UserRoleName)
VALUES 
    (1, 'Customer'),
    (2, 'VipCustomer'),
    (3, 'Driver'),
    (4, 'Admin');

------------------------------------------------
-- User
-------------
-- Insert Customer Info
DECLARE @Customer INT = 1;
WHILE (@Customer < 101)
BEGIN
    INSERT INTO Users (UserId, UserName, UserPwd, UserFullName, UserEmail, UserRoleId)
    VALUES (
        @Customer,
        CONCAT('CustomerUsr', @Customer),
        CONCAT('CustomerPwd', @Customer),
        CONCAT('CustomerName', @Customer),
        CONCAT('CustomerGmail', @Customer, '@gmail.com'),
		1
    );
    SET @Customer += 1;
END;

-- Insert VIP Customer Info
DECLARE @VipCustomer INT = 101;
WHILE (@VipCustomer < 111)
BEGIN
    INSERT INTO Users (UserId, UserName, UserPwd, UserFullName, UserEmail, UserRoleId)
    VALUES (
        @VipCustomer,
        CONCAT('VipUsr', @VipCustomer),
        CONCAT('VipPwd', @VipCustomer),
        CONCAT('VipName', @VipCustomer),
        CONCAT('VipGmail', @VipCustomer, '@gmail.com'),
		2
    );
    SET @VipCustomer += 1;
END

-- Insert Driver Info
DECLARE @Driver INT = 121;
WHILE (@Driver < 151)
BEGIN
    INSERT INTO Users (UserId, UserName, UserPwd, UserFullName, UserEmail, UserRoleId)
    VALUES (
        @Driver,
        CONCAT('DriverUsr', @Driver),
        CONCAT('DriverPwd', @Driver),
        CONCAT('DriverName', @Driver),
        CONCAT('DriverGmail', @Driver, '@gmail.com'),
		3
    );
    SET @Driver += 1;
END

-- Insert Admin Info
INSERT INTO Users VALUEs (99999,'AdminUsr','AdminPwd', 'King of server', 'AdminGmail@gmail.com', 4)