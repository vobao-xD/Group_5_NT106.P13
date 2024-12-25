/*
	DROP PROCEDURE  prod_create_user
	EXEC prod_create_user 'user2', '6cf615d5bcaac778352a8f1f3360d23f02f34ec182e259897fd6ce485d7870d4', 'Chien', 'minhkhoitanhung@gmail.com', 1;

	
ALTER TABLE dbo.[User]
DROP CONSTRAINT IF EXISTS UQ__User__2724B2D1B76D48CE;

SELECT * FROM UserRole

INSERT INTO UserRole (UserRoleName) VALUES ('VIP Customer')

ALTER TABLE dbo.[User]
ADD CONSTRAINT UQ_UserName UNIQUE (UserName);

	SELECT * FROM [User]
*/
CREATE PROCEDURE prod_create_user 
(
    @userName VARCHAR(100),
    @passWord VARCHAR(100),
    @fullname VARCHAR(100),
	@email VARCHAR(100),
	@userroleid INT
)
AS
BEGIN
    SET NOCOUNT ON; -- Thêm dòng này để loại bỏ các thông báo số hàng bị ảnh hưởng.

    DECLARE @Result TABLE 
    (
        Id INT,
        Message NVARCHAR(255)
    );

    BEGIN TRY
        INSERT INTO [User] (UserName, [Password], UserFullName , Mail, UserRoleId)
        VALUES (@userName, @passWord, @fullname, @email, @userroleid);

        INSERT INTO @Result (Id, Message)
        VALUES (1, 'User Created successfully');
    END TRY
    BEGIN CATCH
        INSERT INTO @Result (Id, Message)
        VALUES (-1, ERROR_MESSAGE());
    END CATCH;

    SELECT Id, Message FROM @Result; -- Kết quả trả về từ bảng tạm.
END;