/*
	DROP PROCEDURE prod_get_all_bus
	select * from [User]
	EXEC prod_get_all_bus
*/

CREATE PROCEDURE prod_get_all_bus

AS
BEGIN
	SELECT * FROM Bus
END;