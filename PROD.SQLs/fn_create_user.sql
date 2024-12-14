/*
	DROP PROCEDURE  prod_create_user
	EXEC prod_create_user 'sssss', 'sssss', 'sssss', 'sssss', 1;
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
        Message NVARCHAR(100)
    );

    BEGIN TRY
        INSERT INTO [User] (UserName, [Password], UserFullName , Mail, UserRoleId)
        VALUES (@userName, @passWord, @fullname, @email, @userroleid);

        INSERT INTO @Result (Id, Message)
        VALUES (1, 'User created successfully');
    END TRY
    BEGIN CATCH
        INSERT INTO @Result (Id, Message)
        VALUES (-1, ERROR_MESSAGE());
    END CATCH;

    SELECT Id, Message FROM @Result; -- Kết quả trả về từ bảng tạm.
END;