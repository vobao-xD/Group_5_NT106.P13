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