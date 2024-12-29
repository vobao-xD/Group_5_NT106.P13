Use Bus_server_prod
Go
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_get_all_bus

AS
BEGIN
	SELECT * FROM Bus
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_get_all_customer
	@userroleid INT
AS
BEGIN
	SELECT UserId, UserName, UserFullName, Mail, UserRoleId FROM [User] WHERE UserRoleId = @userroleid
END;

INSERT INTO [User] (UserName, Password, UserFullName, Mail, UserRoleId)
values ('VIP5','1','VIPFULL5', 'vip5@gmail.com', 4)
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_create_user 
(
    @userName VARCHAR(100),
    @passWord VARCHAR(100),
    @fullname NVARCHAR(100),
	@email VARCHAR(100),
	@userroleid INT
)
AS
BEGIN
    SET NOCOUNT ON; -- Thêm dòng này để loại bỏ các thông báo số hàng bị ảnh hưởng.

    DECLARE @Result TABLE 
    (
        Id INT,
        Message NVARCHAR(255)
    );

    BEGIN TRY
        INSERT INTO [User] (UserName, [Password], UserFullName , Mail, UserRoleId)
        VALUES (@userName, @passWord, @fullname, @email, @userroleid);

        INSERT INTO @Result (Id, Message)
        VALUES (1, 'User Created successfully');
    END TRY
    BEGIN CATCH
        INSERT INTO @Result (Id, Message)
        VALUES (-1, ERROR_MESSAGE());
    END CATCH;

    SELECT Id, Message FROM @Result; -- Kết quả trả về từ bảng tạm.
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_check_login
    @username NVARCHAR(100),
    @password NVARCHAR(100)
AS
BEGIN
    SELECT UserId, UserFullName, UserRoleId
    FROM [User]
    WHERE UserName = @username AND [Password] = @password;
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_get_all_customer
	@userroleid INT
AS
BEGIN
	SELECT UserId, UserName, UserFullName, Mail, UserRoleId FROM [User] WHERE UserRoleId = @userroleid
END;

INSERT INTO [User] (UserName, Password, UserFullName, Mail, UserRoleId)
values ('VIP5','1','VIPFULL5', 'vip5@gmail.com', 4)
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_get_seat_booked
	@busid INT,
	@isbook INT
AS
BEGIN
	SELECT B.LicensePlate, SeatName, IsBook, SeatId
	from Bus B, Seat S
	where B.LicensePlate = S.LicensePlate
	and B.BusId = @busid and S.IsBook = @isbook
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_get_ticket_by_id
    @UserEmail NVARCHAR(255),
    @TicketId INT
AS
BEGIN
    -- Xác minh người dùng có quyền truy cập vào vé
    IF EXISTS (
        SELECT 1
        FROM Ticket T
        INNER JOIN [User] U ON T.UserId = U.UserId
        WHERE T.TicketId = @TicketId AND U.Mail = @UserEmail
    )
    BEGIN
        -- Truy vấn thông tin chi tiết của vé nếu quyền hợp lệ
        SELECT 
            T.TicketId,
            TR.TripId,
            TR.Plate AS PlateNumber,
            TR.DepartLocation,
            TR.ArriveLocation,
            TR.DepartTime,
            U.UserFullName,
            S.SeatName
        FROM Ticket T
        INNER JOIN Trip TR ON T.TripId = TR.TripId
        LEFT JOIN TicketDetail TD ON T.TicketId = TD.TicketId
        LEFT JOIN Seat S ON TD.SeatId = S.SeatId
        INNER JOIN [User] U ON T.UserId = U.UserId
        WHERE T.TicketId = @TicketId AND U.Mail = @UserEmail;
    END
    ELSE
    BEGIN
        -- Trả về thông báo lỗi nếu người dùng không có quyền truy cập
        SELECT 
            -1 AS Status, 
            'You do not have permission to view this ticket or the ticket does not exist' AS Message;
    END
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_get_trip_noreturn
	@depart nvarchar(50),
	@arrive nvarchar(50),
	@departtime datetime
AS
BEGIN
	SELECT T.TripId, B.BusId, T.DepartLocation, T.ArriveLocation, T.DepartTime, B.LicensePlate FROM Trip T, Bus B 
	WHERE T.Plate = B.LicensePlate 
	AND DepartLocation = @depart 
	AND ArriveLocation = @arrive 
	AND DepartTime = @departtime 
	AND B.BusStatusId = 1
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_get_user_by_pass
    @username VARCHAR(100),
	@password VARCHAR(64)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [User] WHERE UserName = @username AND [Password] = @password)
    BEGIN
        SELECT TOP 1 UserId, UserName, Mail, UserRoleId 
        FROM [User]
        WHERE UserName = @username AND [Password] = @password;
    END
    ELSE
    BEGIN
        SELECT -1 AS UserId, 'User not found' AS Message;
    END
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_insert_tickets
    @NumOfSeat INT,
    @TripId INT,
    @UserId INT,
    @Price DECIMAL(10,2),
    @LicensePlate NVARCHAR(50),
    @SeatList NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @TicketId INT;
        INSERT INTO Ticket (NumOfSeat, TripId, UserId, Price)
        VALUES (@NumOfSeat, @TripId, @UserId, @Price);
        SET @TicketId = SCOPE_IDENTITY();

        DECLARE @SeatId INT;
        DECLARE @SeatName NVARCHAR(50);
        
        DECLARE seat_cursor CURSOR FOR
        SELECT value
        FROM STRING_SPLIT(@SeatList, ' ');

        OPEN seat_cursor;
        FETCH NEXT FROM seat_cursor INTO @SeatName;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            SELECT @SeatId = SeatId
            FROM Seat
            WHERE LicensePlate = @LicensePlate AND SeatName = @SeatName AND IsBook = 0;

            IF @SeatId IS NULL
            BEGIN
                THROW 50001, 'Invalid Seat or already booked.', 1;
            END

            UPDATE Seat
            SET IsBook = 1
            WHERE SeatId = @SeatId;

            INSERT INTO TicketDetail (TicketId, SeatId)
            VALUES (@TicketId, @SeatId);
            FETCH NEXT FROM seat_cursor INTO @SeatName;
        END

        CLOSE seat_cursor;
        DEALLOCATE seat_cursor;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_update_customer_regular
	@userid INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [User] WHERE UserId = @userid)
    BEGIN
		UPDATE [User]
		SET UserRoleId = 3
		WHERE UserId = @userid
		SELECT 1 as Id, 'Update Successfully' as Message;
    END
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_update_customer_vip
	@userid INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [User] WHERE UserId = @userid)
    BEGIN
		UPDATE [User]
		SET UserRoleId = 4
		WHERE UserId = @userid
		SELECT 1 as Id, 'Update Successfully' as Message;
    END
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_update_seat_to_booked
	@seatname varchar(3),
	@plate varchar(20)
AS
BEGIN
	UPDATE Seat
	SET IsBook = 1
	WHERE SeatName = @seatname AND LicensePlate = @plate
	SELECT 1 as Id, 'Update Successfully' as Message;
END;
GO
---------------------------------------------------------------------------------------------
CREATE PROCEDURE prod_create_trip
(
    @plate NVARCHAR(50),
    @seatNum INT, -- Number of seats for the bus
    @busStatusId INT, -- Status of the bus
    @departLocation NVARCHAR(255),
    @arriveLocation NVARCHAR(255),
    @departTime DATETIME,
    @tripStatusId INT
)
AS
BEGIN
    SET NOCOUNT ON; -- Suppress row count messages

    DECLARE @Result TABLE 
    (
        Id INT,
        Message NVARCHAR(255)
    );

    BEGIN TRY
        -- Check if the bus already exists
        IF NOT EXISTS (SELECT 1 FROM Bus WHERE LicensePlate = @plate)
        BEGIN
            -- Insert the bus if it doesn't exist
            INSERT INTO Bus (LicensePlate, SeatNum, BusStatusId)
            VALUES (@plate, @seatNum, @busStatusId);
        END

        -- Insert the trip
        INSERT INTO Trip (Plate, DepartLocation, ArriveLocation, DepartTime, TripStatusId)
        VALUES (@plate, @departLocation, @arriveLocation, @departTime, @tripStatusId);

        -- Add success message to the result table
        INSERT INTO @Result (Id, Message)
        VALUES (1, 'Trip and bus created successfully');
    END TRY
    BEGIN CATCH
        -- Handle any errors and insert the error message into the result table
        INSERT INTO @Result (Id, Message)
        VALUES (-1, ERROR_MESSAGE());
    END CATCH;

    -- Return the result
    SELECT Id, Message FROM @Result;
END;
GO
---------------------------------------------------------------------------------------------