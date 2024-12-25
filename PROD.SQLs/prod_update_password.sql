/*
    DROP PROCEDURE prod_update_password
    select * from [User]
    EXEC prod_update_password @username = 'K', @password = '1';
*/

CREATE PROCEDURE prod_update_password
	@username varchar(255),
	@password varchar(255)
AS
BEGIN
    SET NOCOUNT ON; -- Thêm dòng này để loại bỏ các thông báo số hàng bị ảnh hưởng.

    DECLARE @Result TABLE 
    (
        Id INT,
        Message NVARCHAR(255)
    );

    BEGIN TRY
        IF EXISTS (SELECT 1 FROM [User] WHERE UserName = @username)
        BEGIN
            UPDATE [User]
            SET Password = @password
            WHERE UserName = @username;

            INSERT INTO @Result (Id, Message)
            VALUES (1, 'Update Password successfully');
        END
        ELSE
        BEGIN
            INSERT INTO @Result (Id, Message)
            VALUES (-1, 'Username not found');
        END
    END TRY
    BEGIN CATCH
        INSERT INTO @Result (Id, Message)
        VALUES (-1, ERROR_MESSAGE());
    END CATCH;

    SELECT Id, Message FROM @Result; -- Kết quả trả về từ bảng tạm.
END;
