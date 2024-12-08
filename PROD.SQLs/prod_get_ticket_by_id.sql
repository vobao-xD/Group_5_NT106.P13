/*
	EXEC prod_get_ticket_by_id @customerid = 1
*/
CREATE PROCEDURE prod_get_ticket_by_id
    @customerid INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Ticket WHERE CustomerId = @customerid)
    BEGIN
        SELECT  * 
        FROM Ticket
        WHERE CustomerId = @customerid
    END
    ELSE
    BEGIN
        SELECT 1 AS UserId, 'Ticker not found' AS Message;
    END
END;


INSERT INTO Ticket (TicketId, NumberOfTicket, TimeTicketAvailabel, TypeOfTicket, SeasonId, IsActive, CustomerId)
values (1,1,'',1,1,1,1)