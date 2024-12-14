-- Table: User

CREATE DATABASE Bus_server_prod
GO
USE Bus_server_prod
GO
SET DATEFORMAT dmy

CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(100) NOT NULL,
	[Password] VARCHAR(65) NOT NULL,
    UserFullName NVARCHAR(200) NOT NULL,
    Mail NVARCHAR(255) NOT NULL UNIQUE,
    UserRoleId INT NOT NULL,
    FOREIGN KEY (UserRoleId) REFERENCES UserRole(UserRoleId)
);

-- Table: UserRole
CREATE TABLE UserRole (
    UserRoleId INT PRIMARY KEY IDENTITY(1,1),
    UserRoleName NVARCHAR(100) NOT NULL UNIQUE
);

-- Table: Ticket
CREATE TABLE Ticket (
    TicketId INT PRIMARY KEY IDENTITY(1,1),
    NumOfSeat INT NOT NULL,
    TripId INT NOT NULL,
    UserId INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    TicketDetailId INT NULL,
    FOREIGN KEY (TripId) REFERENCES Trip(TripId),
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
);

-- Table: TicketDetail
CREATE TABLE TicketDetail (
    TicketDetailId INT PRIMARY KEY IDENTITY(1,1),
    TicketId INT NOT NULL,
    SeatId INT NOT NULL,
    FOREIGN KEY (TicketId) REFERENCES Ticket(TicketId)
);

CREATE TABLE TripStatus (
    TripStatusId INT PRIMARY KEY IDENTITY(1,1),
    TripStatusName NVARCHAR(50) NOT NULL
);

-- Table: Trip
CREATE TABLE Trip (
    TripId INT PRIMARY KEY IDENTITY(1,1),
    Plate NVARCHAR(50) NOT NULL,
    DepartLocation NVARCHAR(255) NOT NULL,
    ArriveLocation NVARCHAR(255) NOT NULL,
    DepartTime DATETIME NOT NULL,
	TripStatusId INT,
    FOREIGN KEY (Plate) REFERENCES Bus(LicensePlate),
	FOREIGN KEY (TripStatusId) REFERENCES TripStatus(TripStatusId)
);

-- Table: Bus
CREATE TABLE Bus (
    BusId INT PRIMARY KEY IDENTITY(1,1),
    LicensePlate NVARCHAR(50) NOT NULL UNIQUE,
    SeatNum INT NOT NULL CHECK (SeatNum > 0),
	BusStatusId INT,
	FOREIGN KEY (BusStatusId) REFERENCES BusStatus(BusStatusId)
);

-- Table: Seat
CREATE TABLE Seat (
    LicensePlate NVARCHAR(50) NOT NULL,
    SeatId INT NOT NULL,
    SeatName NVARCHAR(50) NOT NULL,
    IsBook BIT NOT NULL DEFAULT 0,
    PRIMARY KEY (LicensePlate, SeatId),
    FOREIGN KEY (LicensePlate) REFERENCES Bus(LicensePlate)
);

CREATE TABLE BusStatus (
    BusStatusId INT PRIMARY KEY IDENTITY(1,1),
    BusStatusName NVARCHAR(50) NOT NULL
);

INSERT INTO UserRole (UserRoleName) values ('Admin'), ('Staff'), ('Regular Customer'), ('VIP Customer')
INSERT INTO BusStatus (BusStatusName) values ('Available'),('Unavailable')
INSERT INTO TripStatus (TripStatusName) values ('Available'),('Unavailable')


﻿/*
	DROP PROCEDURE  prod_create_user
	EXEC prod_create_user 'testuser', 'sss', '111', 's', 1;
	SELECT * FROM Users
*/
CREATE PROCEDURE prod_create_user 
(
    @userName VARCHAR(100),
    @passWord VARCHAR(100),
    @fullname VARCHAR(100),
	@email VARCHAR(100),
	@userroleid INT
)
AS
BEGIN
    SET NOCOUNT ON; -- Thêm dòng này để loại bỏ các thông báo số hàng bị ảnh hưởng.

    DECLARE @Result TABLE 
    (
        Id INT,
        Message NVARCHAR(100)
    );

    BEGIN TRY
        INSERT INTO Users (UserName, UserPassword, UserFullName , UserEmail, UserRoleId, IsActive)
        VALUES (@userName, @passWord, @fullname, @email, @userroleid, 1);

        INSERT INTO @Result (Id, Message)
        VALUES (1, 'User created successfully');
    END TRY
    BEGIN CATCH
        INSERT INTO @Result (Id, Message)
        VALUES (-1, ERROR_MESSAGE());
    END CATCH;

    SELECT Id, Message FROM @Result; -- Kết quả trả về từ bảng tạm.
END;

