/*
	EXEC prod_get_ticket_by_id @TicketId = 's'
	DROP PROCEDURE prod_get_ticket_by_id
	INSert into Trip (TripId, TripName, CarId, TicketIds) values (1,'s',1,'[[{"TicketId": "1OA"}, {"TicketId": "1OB"}, {"TicketId": "1OC"}]]')
	Insert into Car(CarId,PlateNumber) values (1,'62A-11111');
*/
CREATE PROCEDURE prod_get_ticket_by_id
    @TicketId NVARCHAR(100)
AS
BEGIN
    -- Biến tạm để kiểm tra xem có dữ liệu hợp lệ hay không
    DECLARE @HasValidRow BIT = 0;

    -- Kiểm tra xem TicketId có tồn tại hay không
    IF EXISTS (
        SELECT 1 
        FROM Trip
        WHERE EXISTS (
            SELECT 1
            FROM OPENJSON(TicketIds) AS OuterArray
            CROSS APPLY OPENJSON(OuterArray.value) WITH (TicketId NVARCHAR(10) '$.TicketId') AS InnerArray
            WHERE InnerArray.TicketId = @TicketId
        )
    )
    BEGIN
        -- Đặt @HasValidRow là 1 nếu tồn tại dòng hợp lệ
        SET @HasValidRow = 1;
    END

    -- Kiểm tra kết quả và trả về
    IF @HasValidRow = 1
    BEGIN
        SELECT T.TripId, T.TripName, C.PlateNumber
        FROM Trip T, Car C
        WHERE EXISTS (
            SELECT 1
            FROM OPENJSON(TicketIds) AS OuterArray
            CROSS APPLY OPENJSON(OuterArray.value) WITH (TicketId NVARCHAR(10) '$.TicketId') AS InnerArray
            WHERE InnerArray.TicketId = @TicketId
        ) AND C.CarId = T.CarId;
    END
    ELSE
    BEGIN
        SELECT -1 AS Status, 'Cannot find the trip of this ticket' AS Message;
    END
END;