USE [Bus_server_prod]
GO
/****** Object:  StoredProcedure [dbo].[prod_update_seat_to_booked]    Script Date: 12/27/2024 1:28:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[prod_update_seat_to_booked]
	@seatname varchar(3),
	@plate varchar(20)
AS
BEGIN
	UPDATE Seat
	SET IsBook = 1
	WHERE SeatName = @seatname AND LicensePlate = @plate
	SELECT 1 as Id, 'Update Successfully' as Message;
END;
