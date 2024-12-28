/*
EXEC prod_get_trip_by_location_and_status 
    @DepartLocation = 'Hanoi', 
    @ArriveLocation = 'Ho Chi Minh City';

*/

CREATE PROCEDURE prod_get_trip_by_location_and_status
    @DepartLocation NVARCHAR(255),
    @ArriveLocation NVARCHAR(255)
AS
BEGIN
    SELECT 
        t.TripId,
        t.Plate,
        t.DepartLocation,
        t.ArriveLocation,
        t.DepartTime,
        t.TripStatusId,
        ts.TripStatusName
    FROM 
        Trip t
    LEFT JOIN 
        TripStatus ts ON t.TripStatusId = ts.TripStatusId
    WHERE 
        t.DepartLocation = @DepartLocation
        AND t.ArriveLocation = @ArriveLocation
        AND t.TripStatusId = 1
END;
