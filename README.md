# CompList – Hệ thống Quản Lý Checklist Công Việc

CompList là phần mềm desktop được phát triển bằng C# nhằm hỗ trợ doanh nghiệp tạo, quản lý và theo dõi checklist công việc. Hệ thống tích hợp Google Forms/Sheets để thu thập phản hồi từ nhân viên thông qua QR Code, đồng thời hỗ trợ xuất báo cáo và theo dõi KPI.

---

## 🚀 Tính năng chính

### ✔️ Quản lý Checklist
- Tạo, chỉnh sửa và lưu trữ checklist
- Tùy chỉnh tiêu đề, mô tả, danh sách công việc
- Gán nhân viên phụ trách từng hạng mục
- Quản lý checklist theo bộ phận, dự án và thời gian

### ✔️ Tạo & Quản lý QR Code
- Tự động tạo mã QR cho từng checklist
- Lưu trữ và phân loại QR theo checklist định kỳ hoặc theo nhu cầu
- Xuất QR để dán tại khu vực thực hiện công việc

### ✔️ Thu thập phản hồi từ nhân viên
- Nhân viên quét QR → mở Google Form
- Dữ liệu đồng bộ về Google Sheets
- Phần mềm tự động tải về và cập nhật trạng thái checklist

### ✔️ Quản lý nhân sự & Phân quyền
- **Giám đốc**: truy cập toàn bộ dữ liệu, xem báo cáo tổng
- **Trưởng phòng**: tạo checklist, phân công nhân viên, phê duyệt báo cáo
- **Nhân viên**: thực hiện checklist và gửi phản hồi
- **Nhà thầu**: quyền truy cập hạn chế theo nhu cầu

### ✔️ Xuất báo cáo PDF/Excel
- Xuất báo cáo đầy đủ thông tin checklist
- Tự động đánh số trang, ghi tên bộ phận, mô tả và ngày
- Lọc báo cáo theo bộ phận, trạng thái hoặc thời gian

### ✔️ Nhắc nhở KPI
- Gửi email nhắc nhở khi checklist gần đến hạn
- Báo cáo KPI theo phòng ban, theo tháng

---

## 🛠 Công nghệ sử dụng
- C# / .NET WinForms
- Google Forms API
- Google Sheets API
- QRCoder để tạo mã QR
- PDFSharp hoặc iTextSharp để xuất báo cáo PDF

---

## 🧩 Kiến trúc tổng quan
Dự án được chia theo mô hình nhiều lớp:

- **UI Layer** – giao diện người dùng
- **BLL (Business Logic Layer)** – xử lý nghiệp vụ
- **DAL (Data Access Layer)** – kết nối Google Sheets, file và dữ liệu liên quan

---

## 📥 Cài đặt & chạy

### 1. Clone project
```bash
git clone https://github.com/quocduy1234231/CompList.git
