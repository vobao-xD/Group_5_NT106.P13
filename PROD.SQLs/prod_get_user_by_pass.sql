/*
	DROP PROCEDURE prod_get_user_by_pass
	EXEC prod_get_user_by_pass @username = 's', @password = 'f969248d621bcded4a3582a1c3b17a71eedfefa9120c36ee3bd1957438cd55b9';
*/

CREATE PROCEDURE prod_get_user_by_pass
    @username VARCHAR(100),
	@password VARCHAR(64)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Users WHERE UserName = @username AND UserPassword = @password)
    BEGIN
        SELECT TOP 1 UserId, UserName, UserEmail 
        FROM Users
        WHERE UserName = @username AND UserPassword = @password;
    END
    ELSE
    BEGIN
        SELECT 1 AS UserId, 'User not found' AS Message;
    END
END;