
--EXEC prod_get_all_trip
--DROP PROCEDURE prod_get_all_trip

CREATE PROCEDURE prod_get_all_trip
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
END;

UPDATE Trip

SET TripStatusId = 1

insert into TripStatus (TripStatusName)
values ('Depart')