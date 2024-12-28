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
