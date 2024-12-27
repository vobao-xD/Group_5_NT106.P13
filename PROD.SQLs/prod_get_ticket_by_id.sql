/*
	DROP PROCEDURE prod_get_ticket_by_id
delete from Ticket
delete from TicketDetail
INSERT INTO Ticket (NumOfSeat, TripId, UserId, Price, TicketDetailId)
VALUES
(2, 2, 19, 50.00, NULL),
(3, 3, 25, 75.00, NULL),
(1, 4, 26, 30.00, NULL);
INSERT INTO TicketDetail (TicketId, SeatId)
VALUES
(10, 101),
(10, 102),
(11, 201),
(11, 202),
(11, 203),
(12, 301);
	EXEC prod_get_ticket_by_id @TicketId = 10
*/
select * from [User]
select * from Trip
select * from Ticket
select * from TicketDetail
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

