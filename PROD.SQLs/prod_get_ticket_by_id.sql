CREATE PROCEDURE prod_get_ticket_by_id
    @TicketId INT
AS
BEGIN
    DECLARE @HasValidRow BIT = 0;

    IF EXISTS (
        SELECT 1 
        FROM Ticket T
        WHERE T.TicketId = @TicketId
    )
    BEGIN
        SET @HasValidRow = 1;
    END

    IF @HasValidRow = 1
    BEGIN
        SELECT 
			T.TicketId,
            TR.TripId,
            TR.Plate AS PlateNumber,
            TR.DepartLocation,
            TR.ArriveLocation,
            TR.DepartTime,
			U.UserFullName,
            TD.SeatId
        FROM Ticket T
        INNER JOIN Trip TR ON T.TripId = TR.TripId
        LEFT JOIN TicketDetail TD ON T.TicketId = TD.TicketId
        INNER JOIN [User] U ON T.UserId = U.UserId
        WHERE T.TicketId = @TicketId;
    END
    ELSE
    BEGIN
        SELECT 
            -1 AS Status, 
            'Cannot find the trip for this ticket' AS Message;
    END
END;