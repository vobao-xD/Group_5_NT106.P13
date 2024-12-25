/*
	DROP PROCEDURE prod_get_all_customer
	select * from [User]
	EXEC prod_get_all_customer @userroleid = 3;
*/

CREATE PROCEDURE prod_get_all_customer
	@userroleid INT
AS
BEGIN
	SELECT UserId, UserName, UserFullName, Mail, UserRoleId FROM [User] WHERE UserRoleId = @userroleid
END;

INSERT INTO [User] (UserName, Password, UserFullName, Mail, UserRoleId)
values ('VIP5','1','VIPFULL5', 'vip5@gmail.com', 4)