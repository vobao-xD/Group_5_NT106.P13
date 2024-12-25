/*
	DROP PROCEDURE prod_get_seat_booked
	select * from [User]
	EXEC prod_get_seat_booked @busid = 2, @isbook = 1;
*/

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