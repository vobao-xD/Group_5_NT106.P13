/*
	EXEC prod_check_login @username = 's', @password = '12345678a';
*/
CREATE PROCEDURE prod_check_login
    @username NVARCHAR(100),
    @password NVARCHAR(100)
AS
BEGIN
    SELECT UserId, UserFullName
    FROM Users
    WHERE UserName = @username AND UserPassword = @password;
END;