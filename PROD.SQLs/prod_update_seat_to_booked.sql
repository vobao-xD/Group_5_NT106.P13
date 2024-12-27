/*
	DROP PROCEDURE prod_update_seat_to_booked
	select * from Seat
	EXEC prod_update_seat_to_booked @seatid = 1000;
*/

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