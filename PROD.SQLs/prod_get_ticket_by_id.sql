/*
	EXEC prod_get_ticket_by_id @UserId = 4
	DROP PROCEDURE prod_get_ticket_by_id
	INSERT INTO Bus(LicensePlate,SeatNum) values ('1111',18)
	INSert into Trip (Plate,DepartLocation,ArriveLocation,DepartTime) values ('1111','SG','HN','12/14/2024')
	Select * from Trip
	select * from [User]
	Insert into Car(CarId,PlateNumber) values (1,'62A-11111');
	insert into Ticket(NumOfSeat,TripId,UserId,Price,TicketDetailId) values (1,3,4,10000,1)
*/
CREATE PROCEDURE prod_get_ticket_by_id
    @UserId int
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
			FROM Ticket T, Trip TR
			WHERE T.TripId = TR.TripId AND T.UserId = @UserId
        )
    )
    BEGIN
        -- Đặt @HasValidRow là 1 nếu tồn tại dòng hợp lệ
        SET @HasValidRow = 1;
    END

    -- Kiểm tra kết quả và trả về
    IF @HasValidRow = 1
    BEGIN
        SELECT TR.TripId, Plate, DepartLocation, ArriveLocation, DepartTime
		FROM Ticket T, Trip TR
		WHERE T.TripId = TR.TripId AND T.UserId = @UserId
    END
    ELSE
    BEGIN
        SELECT -1 AS Status, 'Cannot find the trip of this ticket' AS Message;
    END
END;