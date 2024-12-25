CREATE PROCEDURE prod_get_trip_return
	@depart nvarchar(50),
	@arrive nvarchar(50),
	@departtime datetime,
	@returntime datetime
AS
BEGIN
	SELECT T.TripId, B.BusId, T.DepartLocation, T.ArriveLocation, T.DepartTime, B.LicensePlate FROM Trip T, Bus B 
	WHERE T.Plate = B.LicensePlate 
	AND DepartLocation = @depart 
	AND ArriveLocation = @arrive 
	AND DepartTime = @departtime 
	AND B.BusStatusId = 1

	UNION

	SELECT T.TripId, B.BusId, T.DepartLocation, T.ArriveLocation, T.DepartTime, B.LicensePlate FROM Trip T, Bus B 
	WHERE T.Plate = B.LicensePlate 
	AND DepartLocation = @arrive 
	AND ArriveLocation = @depart 
	AND DepartTime = @returntime 
	AND B.BusStatusId = 1
END;