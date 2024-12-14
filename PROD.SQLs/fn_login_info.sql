/*
	EXEC prod_check_login @username = 's', @password = 's';
*/
CREATE PROCEDURE prod_check_login
    @username NVARCHAR(100),
    @password NVARCHAR(100)
AS
BEGIN
    SELECT UserId, UserFullName
    FROM [User]
    WHERE UserName = @username AND [Password] = @password;
END;