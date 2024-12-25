/*
	DROP PROCEDURE prod_update_customer_regular
	select * from [User]
	EXEC prod_update_customer_regular @userid = 10;
*/

CREATE PROCEDURE prod_update_customer_regular
	@userid INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [User] WHERE UserId = @userid)
    BEGIN
		UPDATE [User]
		SET UserRoleId = 3
		WHERE UserId = @userid
		SELECT 1 as Id, 'Update Successfully' as Message;
    END
END;