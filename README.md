# Đồ án Môn học ASP.NET - Trang web Diễn Đàn Sức Khỏe

Đây là đồ án môn học ASP.NET được thực hiện bởi sinh viên:

- **Họ và tên:** HOÀNG HÙNG
- **Lớp:** VS23TTK10
- **MSSV:** 470123056

---

## Mô tả Đồ án

## Mô tả Đồ án

Trang web được xây dựng nhằm mục đích cung cấp thông tin, bài viết về các chủ đề sức khỏe. Ứng dụng được phát triển bằng ngôn ngữ C# trên nền tảng ASP.NET MVC 5 (.NET Framework) và sử dụng Entity Framework Code First để quản lý cơ sở dữ liệu.

Các chức năng chính bao gồm:
- Hiển thị danh sách bài viết.
- Tìm kiếm bài viết theo tiêu đề.
- Xem chi tiết bài viết.
- Hệ thống đăng ký, đăng nhập cho người dùng.
- Phân quyền theo vai trò (Admin, Editor).
- Quản lý bài viết (Tạo, Sửa, Xóa) cho các tài khoản có quyền.
- Quản lý người dùng và gán vai trò cho Admin.
- Tích hợp trình soạn thảo văn bản TinyMCE.

---

## Hướng dẫn Chạy Dự án

1. Clone repository này về máy.
2. Mở file `.sln` bằng Visual Studio 2022 (đã cài đặt Workload ASP.NET).
3. Mở **Package Manager Console** và chạy lệnh `Update-Database` để tạo cơ sở dữ liệu.
4. Nhấn `F5` để chạy dự án.

---

## Tài khoản Quản trị (Admin) Mặc định

Để truy cập các chức năng quản trị, vui lòng sử dụng tài khoản sau:

- **Email / Tên đăng nhập:** `admin@suckhoe.com`
- **Mật khẩu:** `Password123!`
