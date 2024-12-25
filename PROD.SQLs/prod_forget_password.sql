/*
    DROP PROCEDURE prod_forget_password
    select * from [User]
	UPDATE [User] SET UserRoleId = 1 where UserId = 38
    EXEC prod_forget_password @email = 'ssssss@gmail.com', @password = 's';
*/

CREATE PROCEDURE prod_forget_password
    @email nvarchar(255),
    @password varchar(64)
AS
BEGIN
    SET NOCOUNT ON; -- Thêm dòng này để loại bỏ các thông báo số hàng bị ảnh hưởng.

    DECLARE @Result TABLE 
    (
        Id INT,
        Message NVARCHAR(255)
    );

    BEGIN TRY
        IF EXISTS (SELECT 1 FROM [User] WHERE Mail = @email)
        BEGIN
            UPDATE [User]
            SET Password = @password
            WHERE Mail = @email;

            INSERT INTO @Result (Id, Message)
            VALUES (1, 'Update Password successfully');
        END
        ELSE
        BEGIN
            INSERT INTO @Result (Id, Message)
            VALUES (-1, 'Email not found');
        END
    END TRY
    BEGIN CATCH
        INSERT INTO @Result (Id, Message)
        VALUES (-1, ERROR_MESSAGE());
    END CATCH;

    SELECT Id, Message FROM @Result; -- Kết quả trả về từ bảng tạm.
END;
