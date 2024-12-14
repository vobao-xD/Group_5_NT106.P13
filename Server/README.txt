1. Server được triển khai theo mô hình gần giống MVC
- Controller: nơi viết logic chương trình, định nghĩa các hàm cần gọi trong main.py
- Models for database: nơi viết các class chứa dữ liệu để truy vấn với database
- Models for server: nơi viết các class chứa dữ liệu để làm việc với client
- ConnectDB: quản lý kết nối với database

2. Khi mới tạo project, gõ lệnh: "pip3 install -r requirements.txt" để tải các thư viện cần thiết