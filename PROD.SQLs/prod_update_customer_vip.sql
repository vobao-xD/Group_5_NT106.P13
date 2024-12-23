/*
	DROP PROCEDURE prod_update_customer_vip
	select * from [User]
	EXEC prod_update_customer_vip @userid = 99;
*/

CREATE PROCEDURE prod_update_customer_vip
	@userid INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [User] WHERE UserId = @userid)
    BEGIN
		UPDATE [User]
		SET UserRoleId = 4
		WHERE UserId = @userid
		SELECT 1 as Id, 'Update Successfully' as Message;
    END
END;