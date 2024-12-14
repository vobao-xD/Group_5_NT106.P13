/*
	DROP PROCEDURE prod_get_user_by_pass
	select * from [User]
	EXEC prod_get_user_by_pass @username = 'a', @password = 'a';
*/

CREATE PROCEDURE prod_get_user_by_pass
    @username VARCHAR(100),
	@password VARCHAR(64)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [User] WHERE UserName = @username AND [Password] = @password)
    BEGIN
        SELECT TOP 1 UserId, UserName, Mail 
        FROM [User]
        WHERE UserName = @username AND [Password] = @password;
    END
    ELSE
    BEGIN
        SELECT -1 AS UserId, 'User not found' AS Message;
    END
END;