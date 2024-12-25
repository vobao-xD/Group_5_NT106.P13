/*
-- Create a new trip with a bus
EXEC prod_create_trip 
    @plate = '51A-67890', 
    @seatNum = 45, 
    @busStatusId = 1, 
    @departLocation = N'TP.HCM', 
    @arriveLocation = N'Hà Nội', 
    @departTime = '2024-12-27 06:30:00', 
    @tripStatusId = 1;


	DELETE FROM Trip;
    DELETE FROM Bus;
	select * from Bus
	select * from Trip
*/

CREATE PROCEDURE prod_create_trip
(
    @plate NVARCHAR(50),
    @seatNum INT, -- Number of seats for the bus
    @busStatusId INT, -- Status of the bus
    @departLocation NVARCHAR(255),
    @arriveLocation NVARCHAR(255),
    @departTime DATETIME,
    @tripStatusId INT
)
AS
BEGIN
    SET NOCOUNT ON; -- Suppress row count messages

    DECLARE @Result TABLE 
    (
        Id INT,
        Message NVARCHAR(255)
    );

    BEGIN TRY
        -- Check if the bus already exists
        IF NOT EXISTS (SELECT 1 FROM Bus WHERE LicensePlate = @plate)
        BEGIN
            -- Insert the bus if it doesn't exist
            INSERT INTO Bus (LicensePlate, SeatNum, BusStatusId)
            VALUES (@plate, @seatNum, @busStatusId);
        END

        -- Insert the trip
        INSERT INTO Trip (Plate, DepartLocation, ArriveLocation, DepartTime, TripStatusId)
        VALUES (@plate, @departLocation, @arriveLocation, @departTime, @tripStatusId);

        -- Add success message to the result table
        INSERT INTO @Result (Id, Message)
        VALUES (1, 'Trip and bus created successfully');
    END TRY
    BEGIN CATCH
        -- Handle any errors and insert the error message into the result table
        INSERT INTO @Result (Id, Message)
        VALUES (-1, ERROR_MESSAGE());
    END CATCH;

    -- Return the result
    SELECT Id, Message FROM @Result;
END;