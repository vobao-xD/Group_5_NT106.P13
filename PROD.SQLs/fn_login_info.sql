/*
	EXEC prod_check_login @username = 'ssss', @password = 's';
	DROP PROCEDURE prod_check_login
*/
CREATE PROCEDURE prod_check_login
    @username NVARCHAR(100),
    @password NVARCHAR(100)
AS
BEGIN
    SELECT UserId, UserFullName, UserRoleId
    FROM [User]
    WHERE UserName = @username AND [Password] = @password;
END;