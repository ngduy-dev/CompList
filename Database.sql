-- DROP và CREATE DATABASE
USE master;
ALTER DATABASE CHECKLIST SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

-- Sau đó, xóa cơ sở dữ liệu TEMP
DROP DATABASE CHECKLIST;
GO

CREATE DATABASE CHECKLIST;
GO
USE CHECKLIST;
GO


-- Tạo bảng [Department]
CREATE TABLE [Department] (
  [DepartmentID] CHAR(10) PRIMARY KEY,
  [DepartmentName] VARCHAR(255) NOT NULL
);

GO
INSERT INTO [Department] (DepartmentID, DepartmentName) VALUES
('ENGI', 'Engineering'),
('SECU', 'Security'),
('SANI', 'Sanitation'),
('LAND', 'Landscaping'),
('ACCO', 'Accounting'),
('HUMA', 'Human Resources'),
('RESI', 'Resident Services'),
('CONS', 'Construction'),
('DRIV', 'Driving'),
('KITC', 'Kitchen'),
('WARE', 'Warehouse'),
('EXEC', 'Executive Management'),
('CONT', 'Contractor Services');
GO



--- Tạo bảng [User]
CREATE TABLE [User] (
  [UserID] CHAR(10) PRIMARY KEY, 
  [Username] VARCHAR(255),
  [Password] VARCHAR(255) NOT NULL,
  [FullName] VARCHAR(255) NOT NULL,
  [Email] VARCHAR(255),
  [PhoneNumber] VARCHAR(20),
  [LastLogin] DATETIME,
  [IsActive] BIT,
  [Gender] NVARCHAR(10), -- Thêm trường Giới tính (Male/Female/Other)
  [DateOfBirth] DATE,    -- Thêm trường Ngày sinh
  [DepartmentID] CHAR(10),
  FOREIGN KEY ([DepartmentID]) REFERENCES [Department]([DepartmentID])
);

GO
-- Thêm dữ liệu vào bảng [User] với Password là 'Pass1234'
INSERT INTO [User] (UserID, Username, Password, FullName, Email, PhoneNumber, LastLogin, IsActive, Gender, DateOfBirth, DepartmentID) VALUES
('DIRE001', 'director_lethanhha', 'Pass1234', 'Le Thanh Ha', 'lethanhha@companyname.com', '123456789', '2024-10-24 09:30', 1, 'Male', '1975-05-12', 'EXEC'), -- Giám đốc
('ENGI001', 'engineer_tranvanan', 'Pass1234', 'Tran Van An', 'tranvanan@companyname.com', '987654321', '2024-10-25 08:00', 1, 'Male', '1988-03-22', 'ENGI'), -- Kỹ thuật
('SECU001', 'security_nguyenhongson', 'Pass1234', 'Nguyen Hong Son', 'nguyenhongson@companyname.com', '876543210', '2024-10-26 07:45', 1, 'Male', '1980-07-15', 'SECU'), -- An ninh
('SANI001', 'cleaner_phamminhtam', 'Pass1234', 'Pham Minh Tam', 'phamminhtam@companyname.com', '765432109', '2024-10-27 06:00', 1, 'Female', '1992-12-11', 'SANI'), -- Vệ sinh
('LAND001', 'landscaping_phamthihoa', 'Pass1234', 'Pham Thi Hoa', 'phamthihoa@companyname.com', '654321098', '2024-10-28 07:00', 1, 'Female', '1985-06-18', 'LAND'), -- Cây cảnh
('ACCO001', 'accountant_hoangthiyen', 'Pass1234', 'Hoang Thi Yen', 'hoangthiyen@companyname.com', '543210987', '2024-10-29 09:00', 1, 'Female', '1990-09-25', 'ACCO'), -- Kế toán
('HUMA001', 'hr_maidangthao', 'Pass1234', 'Mai Dang Thao', 'maidangthao@companyname.com', '432109876', '2024-10-30 10:15', 1, 'Female', '1995-03-10', 'HUMA'), -- Hành chính nhân sự
('RESI001', 'residentservice_vothithao', 'Pass1234', 'Vo Thi Thao', 'vothithao@companyname.com', '321098765', '2024-10-31 08:30', 1, 'Female', '1993-11-02', 'RESI'), -- Dịch vụ cư dân
('CONS001', 'construction_hoangkimlong', 'Pass1234', 'Hoang Kim Long', 'hoangkimlong@companyname.com', '210987654', '2024-11-01 08:00', 1, 'Male', '1984-08-21', 'CONS'), -- Xây dựng
('DRIV001', 'driver_dangthanhhoa', 'Pass1234', 'Dang Thanh Hoa', 'dangthanhhoa@companyname.com', '109876543', '2024-11-02 07:00', 1, 'Male', '1978-02-17', 'DRIV'), -- Lái xe
('KITC001', 'cook_nguyenthivan', 'Pass1234', 'Nguyen Thi Van', 'nguyenthivan@companyname.com', '098765432', '2024-11-03 06:45', 1, 'Female', '1990-05-30', 'KITC'), -- Bếp
('WARE001', 'warehouse_letuanhung', 'Pass1234', 'Le Tuan Hung', 'letuanhung@companyname.com', '987654321', '2024-11-04 08:15', 1, 'Male', '1986-08-19', 'WARE'), -- Kho
('CONT001', 'contractor_phamquanghuy', 'Pass1234', 'Pham Quang Huy', 'phamquanghuy@companyname.com', '876543210', '2024-11-05 09:30', 1, 'Male', '1991-12-05', 'CONT'); -- Đơn vị nhà thầu thi công - tư vấn thuê ngoài
GO



-- Tạo bảng [Employee] với trường Gender và DateOfBirth
CREATE TABLE [Employee] (
  [EmployeeID] CHAR(10) PRIMARY KEY,
  [Name] VARCHAR(255) NOT NULL,
  [NumberPhone] VARCHAR(20),
  [DepartmentID] CHAR(10),
  [Email] VARCHAR(255),
  [Gender] CHAR(10), 
  [DateOfBirth] DATE, -- Thêm trường ngày sinh
  [IsActive] BIT NOT NULL DEFAULT 1, -- Trạng thái làm việc
  FOREIGN KEY ([DepartmentID]) REFERENCES [Department]([DepartmentID])
);
GO

-- Thêm dữ liệu vào bảng [Employee] với trường Gender và DateOfBirth, sử dụng mã phòng mới
INSERT INTO [Employee] (EmployeeID, Name, NumberPhone, DepartmentID, Email, Gender, DateOfBirth, IsActive) VALUES
('EMP011', 'CR7', '0912345678', 'ENGI', 'CR7@companyname.com', 'Male', '1985-02-05', 1),
('EMP012', 'Messi', '0898765432', 'SECU', 'Messi@companyname.com', 'Male', '1987-06-24', 1),
('EMP013', 'Suarez', '0901122334', 'SANI', 'suarez@companyname.com', 'Male', '1987-01-24', 0),
('EMP001', 'John Smith', '0912345679', 'LAND', 'john.smith@companyname.com', 'Male', '1990-03-12', 1),
('EMP002', 'Alice Johnson', '0898765433', 'ACCO', 'alice.johnson@companyname.com', 'Female', '1992-08-10', 0),
('EMP003', 'Robert Brown', '0901122335', 'HUMA', 'robert.brown@companyname.com', 'Male', '1989-11-05', 1),
('EMP004', 'Linda Davis', '0912345671', 'RESI', 'linda.davis@companyname.com', 'Female', '1988-07-19', 0),
('EMP005', 'Michael Wilson', '0898765434', 'CONS', 'michael.wilson@companyname.com', 'Male', '1991-09-23', 1),
('EMP006', 'Emily Garcia', '0901122336', 'DRIV', 'emily.garcia@companyname.com', 'Female', '1994-04-02', 1),
('EMP007', 'David Martinez', '0912345672', 'KITC', 'david.martinez@companyname.com', 'Male', '1986-12-15', 1),
('EMP008', 'Sophia Rodriguez', '0898765435', 'WARE', 'sophia.rodriguez@companyname.com', 'Female', '1990-06-30', 0),
('EMP009', 'James Lee', '0901122337', 'EXEC', 'james.lee@companyname.com', 'Male', '1987-01-14', 1),
('EMP010', 'Emma Thompson', '0912345673', 'CONT', 'emma.thompson@companyname.com', 'Female', '1995-05-08', 1),
('EMP014', 'Neymar', '0898765436', 'ENGI', 'neymar@companyname.com', 'Male', '1992-02-05', 1),
('EMP015', 'Pogba', '0901122338', 'SECU', 'pogba@companyname.com', 'Male', '1993-03-15', 0),
('EMP016', 'Mbappe', '0912345674', 'SANI', 'mbappe@companyname.com', 'Male', '1998-12-20', 1),
('EMP017', 'Kante', '0898765437', 'LAND', 'kante@companyname.com', 'Male', '1991-03-29', 0),
('EMP018', 'Salah', '0901122339', 'ACCO', 'salah@companyname.com', 'Male', '1992-06-15', 1),
('EMP019', 'Sterling', '0912345675', 'HUMA', 'sterling@companyname.com', 'Male', '1994-12-08', 1),
('EMP020', 'De Bruyne', '0898765438', 'RESI', 'debruyne@companyname.com', 'Male', '1991-06-28', 1),
('EMP021', 'Rashford', '0901122340', 'CONS', 'rashford@companyname.com', 'Male', '1997-10-31', 1),
('EMP022', 'Benzema', '0912345676', 'DRIV', 'benzema@companyname.com', 'Male', '1987-12-19', 1),
('EMP023', 'Lewandowski', '0898765439', 'KITC', 'lewandowski@companyname.com', 'Male', '1988-08-21', 1),
('EMP024', 'Vidal', '0901122341', 'WARE', 'vidal@companyname.com', 'Male', '1987-05-22', 0),
('EMP025', 'Kimmich', '0912345677', 'EXEC', 'kimmich@companyname.com', 'Male', '1995-02-08', 1),
('EMP026', 'Modric', '0898765440', 'CONT', 'modric@companyname.com', 'Male', '1985-09-09', 1),
('EMP027', 'Haaland', '0901122342', 'ENGI', 'haaland@companyname.com', 'Male', '2000-07-21', 1),
('EMP028', 'Son', '0912345678', 'SECU', 'son@companyname.com', 'Male', '1992-07-08', 1),
('EMP029', 'Khuu Trung Duong', '0383387623', 'ENGI', 'khuutrungduongwork@gmail.com', 'Male', '2004-01-01', 1),
('EMP030', 'Khuu Tieu Long', '0941501507', 'ACCO', 'khuutrungduong0383@gmail.com', 'Male', '2003-12-12', 1),
('EMP031', 'Nguyen Quang Trung', '0914652363', 'SECU', 'nqt123456123@gmail.com', 'Male', '2004-02-02', 1),
('EMP032', 'Nguyen Quoc Duy', '0914652363', 'LAND', 'quocduy1234321@gmail.com', 'Male', '2004-03-03', 1);
GO

-- Tạo bảng [Checklist]
CREATE TABLE [Checklist] (
  [ChecklistID] CHAR(20) PRIMARY KEY,
  [Title] VARCHAR(255) NOT NULL,
  [Description] TEXT,
  [CreatedByID] CHAR(10),
  [CreatedDate] DATETIME NOT NULL,
  [CompleteDate ] DATETIME,
  [DueDate] DATETIME,
  [Status] VARCHAR(50),
  [DepartmentID] CHAR(10),
  FOREIGN KEY ([CreatedByID]) REFERENCES [User]([UserID]),
  FOREIGN KEY ([DepartmentID]) REFERENCES [Department]([DepartmentID])
);
GO

-- Phong Ky Thuat
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('ENGI-CHK101', 'Kiem tra thiet bi hang thang', 'Kiem tra dinh ky cac may moc va thiet bi.', 'ENGI001', '2024-06-01', '2024-09-01', 'Open', 'ENGI'),
('ENGI-CHK102', 'Bao tri he thong dien', 'Dam bao he thong dien hoat dong on dinh.', 'ENGI001', '2024-07-15', '2024-08-19', 'In Progress', 'ENGI');

-- Phong An Ninh
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('SECU-CHK103', 'Kiem tra camera giam sat', 'Dam bao cac camera hoat dong binh thuong.', 'SECU001', '2024-07-20', '2024-08-20', 'Open', 'SECU'),
('SECU-CHK104', 'Bao cao vi pham an ninh', 'Ghi nhan va xu ly cac vi pham an ninh.', 'SECU001', '2024-08-10', '2024-09-10', 'In Progress', 'SECU');

-- Phong Ve Sinh
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('SANI-CHK105', 'Don dep hanh lang', 'Lam sach va ve sinh khu vuc hanh lang.', 'SANI001', '2024-10-10', '2024-11-10', 'Completed', 'SANI'),
('SANI-CHK106', 'Kiem tra ve sinh phong hop', 'Dam bao ve sinh khu vuc phong hop.', 'SANI001', '2024-06-06', '2024-07-06', 'In Progress', 'SANI');

-- Phong Cay Canh
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('LAND-CHK107', 'Tuoi cay trong khuon vien', 'Tuoi nuoc cho cay canh trong khuon vien.', 'LAND001', '2024-09-05', '2024-10-05', 'Completed', 'LAND'),
('LAND-CHK108', 'Cat tia cay xanh', 'Cat tia cay xanh dinh ky.', 'LAND001', '2024-11-15', '2024-12-15', 'In Progress', 'LAND');

-- Phong Ke Toan
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('ACCO-CHK109', 'Kiem tra bao cao tai chinh', 'Xem xet va kiem tra bao cao tai chinh thang.', 'ACCO001', '2024-11-20', '2025-05-20', 'Open', 'ACCO'),
('ACCO-CHK110', 'Lap bao cao tai chinh quy', 'Lap bao cao tai chinh cho quy moi.', 'ACCO001', '2025-03-05', '2025-05-05', 'In Progress', 'ACCO');

-- Phong Hanh Chinh Nhan Su
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('HUMA-CHK111', 'Cap nhat ho so nhan vien', 'Kiem tra va cap nhat ho so nhan vien dinh ky.', 'HUMA001', '2024-03-01', '2024-06-01', 'Open', 'HUMA'),
('HUMA-CHK112', 'Danh gia hieu qua nhan vien', 'Thuc hien danh gia hieu qua lam viec nhan vien.', 'HUMA001', '2024-01-15', '2024-04-15', 'In Progress', 'HUMA');

-- Phong Dich Vu Cu Dan
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('RESI-CHK113', 'Phan hoi y kien cu dan', 'Tong hop va xu ly phan hoi cua cu dan.', 'RESI001', '2024-01-25', '2024-03-25', 'Completed', 'RESI'),
('RESI-CHK114', 'Kiem tra dich vu cu dan', 'Danh gia chat luong cac dich vu cu dan.', 'RESI001', '2024-02-10', '2024-05-10', 'In Progress', 'RESI');

-- Phong Xay Dung
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('CONS-CHK115', 'Kiem tra an toan lao dong', 'Dam bao an toan tren cong truong xay dung.', 'CONS001', '2024-01-20', '2024-04-20', 'Open', 'CONS'),
('CONS-CHK116', 'Bao cao tien do xay dung', 'Theo doi va bao cao tien do xay dung.', 'CONS001', '2024-02-05', '2024-05-05', 'In Progress', 'CONS');

-- Phong Lai Xe
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('DRIV-CHK117', 'Kiem tra an toan xe', 'Kiem tra tinh trang xe dinh ky.', 'DRIV001', '2024-01-15', '2024-04-15', 'Completed', 'DRIV'),
('DRIV-CHK118', 'Cap nhat nhat ky lai xe', 'Cap nhat day du nhat ky lai xe.', 'DRIV001', '2024-03-01', '2024-06-01', 'In Progress', 'DRIV');

-- Phong Bep
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('KITC-CHK119', 'Kiem tra thuc pham trong kho', 'Kiem tra chat luong va han su dung thuc pham.', 'KITC001', '2024-01-05', '2024-03-05', 'Completed', 'KITC'),
('KITC-CHK120', 'Dam bao an toan thuc pham', 'Kiem tra quy trinh an toan thuc pham.', 'KITC001', '2024-02-20', '2025-05-20', 'In Progress', 'KITC');

-- Phong Kho
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('WARE-CHK121', 'Kiem ke hang ton kho', 'Thuc hien kiem ke hang ton kho.', 'WARE001', '2024-01-25', '2024-03-25', 'Open', 'WARE'),
('WARE-CHK122', 'Kiem tra bao quan hang', 'Kiem tra tinh trang bao quan hang hoa.', 'WARE001', '2024-03-01', '2025-06-01', 'In Progress', 'WARE');

-- Ban Giam Doc !!!!!
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('EXEC-CHK123', 'Danh gia hoat dong phong ban', 'Danh gia ket qua hoat dong cua cac phong ban.', 'DIRE001', '2024-07-10', '2025-03-10', 'Completed', 'EXEC'),
('EXEC-CHK124', 'Bao cao chien luoc kinh doanh', 'Thuc hien bao cao chien luoc kinh doanh.', 'DIRE001', '2024-02-05', '2025-05-05', 'In Progress', 'EXEC');

-- Thau
INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('CONT-CHK125', 'Kiem tra hop dong doi tac', 'Kiem tra tinh trang cac hop dong doi tac.', 'CONT001', '2024-07-15', '2024-09-15', 'Open', 'CONT'),
('CONT-CHK126', 'Bao cao tinh trang hop dong', 'Theo doi va bao cao tinh trang hop dong.', 'CONT001', '2024-06-01', '2025-06-01', 'In Progress', 'CONT');
GO

-- Tạo bảng [ChecklistItem] với cột CreateDate
CREATE TABLE [ChecklistItem] (
  [ItemID] CHAR(20) PRIMARY KEY,
  [ChecklistID] CHAR(20),
  [TaskDescription] TEXT,
  [IsCompleted] BIT,
  [CreateDate] DATETIME,
  [CompletionDate] DATETIME,
  [DueDate] DATETIME,
  [EmployeeID] CHAR(10),
  FOREIGN KEY ([ChecklistID]) REFERENCES [Checklist]([ChecklistID]),
  FOREIGN KEY ([EmployeeID]) REFERENCES [Employee]([EmployeeID])
);
GO

/*
-- Trigger cho [ChecklistItem] để cập nhật ItemID
CREATE TRIGGER trg_Update_ChecklistItemID
ON [ChecklistItem]
AFTER INSERT
AS
BEGIN
  -- Cập nhật ItemID thành DepartmentID-ItemID
  UPDATE CI
  SET CI.ItemID = CONCAT(RTRIM(C.DepartmentID), '-', RTRIM(CI.ItemID))
  FROM [ChecklistItem] CI
  INNER JOIN inserted I ON CI.ItemID = I.ItemID
  INNER JOIN [Checklist] C ON CI.ChecklistID = C.ChecklistID;
END;
GO
*/

/*-- Chèn dữ liệu vào bảng [ChecklistItem] với giá trị CreateDate - KHÔNG XÀI TỚI CHỈ XÀI TRÊN GGSHEET
 INSERT INTO [ChecklistItem] (ItemID, ChecklistID, TaskDescription, IsCompleted, DueDate, EmployeeID, CreateDate) VALUES
('ITEM001', 'CHK001', 'Inspect equipment', 1, '2024-11-02', 'EMP001', '2024-11-01'),
('ITEM002', 'CHK001', 'Replace air filters', 0, NULL, 'EMP002', '2024-11-01'),
('ITEM003', 'CHK002', 'Verify camera footage', 1, '2024-11-04', 'EMP003', '2024-11-02'),
('ITEM004', 'CHK002', 'Check security alarms', 0, NULL, 'EMP004', '2024-11-02'),
('ITEM005', 'CHK003', 'Inspect kitchen sanitation', 1, '2024-11-03', 'EMP005', '2024-11-03'),
('ITEM006', 'CHK003', 'Check restroom cleanliness', 1, '2024-11-03', 'EMP006', '2024-11-03'),
('ITEM007', 'CHK004', 'Lubricate machinery', 0, NULL, 'EMP007', '2024-11-04'),
('ITEM008', 'CHK004', 'Inspect electrical connections', 1, '2024-11-04', 'EMP008', '2024-11-04'),
('ITEM009', 'CHK005', 'Update access control list', 0, NULL, 'EMP009', '2024-11-05'),
('ITEM010', 'CHK005', 'Test fire alarm system', 1, '2024-11-06', 'EMP010', '2024-11-06'),
('ITEM011', 'CHK006', 'Remove hazardous waste', 1, '2024-11-03', 'EMP001', '2024-11-03'),
('ITEM012', 'CHK006', 'Check waste disposal logs', 0, NULL, 'EMP002', '2024-11-03'),
('ITEM013', 'CHK007', 'Plan new flower beds', 0, NULL, 'EMP003', '2024-11-07'),
('ITEM014', 'CHK007', 'Trim hedges', 1, '2024-11-07', 'EMP004', '2024-11-07'),
('ITEM015', 'CHK008', 'Verify financial reports', 1, '2024-11-08', 'EMP005', '2024-11-08'),
('ITEM016', 'CHK008', 'Prepare monthly budget', 0, NULL, 'EMP006', '2024-11-08'),
('ITEM017', 'CHK009', 'Review policy changes', 1, '2024-11-05', 'EMP007', '2024-11-05'),
('ITEM018', 'CHK009', 'Update employee handbook', 0, NULL, 'EMP008', '2024-11-05'),
('ITEM019', 'CHK010', 'Conduct resident interviews', 0, NULL, 'EMP009', '2024-11-06'),
('ITEM020', 'CHK010', 'Collect feedback forms', 1, '2024-11-06', 'EMP010', '2024-11-06'),
('ITEM021', 'CHK013', 'Inspect equipment', 1, '2024-11-07', 'EMP001', '2024-11-07'),
('ITEM022', 'CHK013', 'Check lighting systems', 0, NULL, 'EMP002', '2024-11-07'),
('ITEM023', 'CHK013', 'Lubricate machinery', 1, '2024-11-08', 'EMP003', '2024-11-08'),
('ITEM024', 'CHK013', 'Replace filters', 0, NULL, 'EMP004', '2024-11-08'),
('ITEM025', 'CHK013', 'Clean ventilation system', 1, '2024-11-09', 'EMP005', '2024-11-09');
GO
*/

-- Tạo bảng [QRCode]
CREATE TABLE [QRCode] (
  [QRCodeID] INT PRIMARY KEY,
  [ChecklistID] CHAR(20),
  [GeneratedDate] DATETIME NOT NULL,
  [ExpirationDate] DATETIME,
  [IsExpired] BIT,
  FOREIGN KEY ([ChecklistID]) REFERENCES [Checklist]([ChecklistID])
);
GO

-- Tạo bảng [Report]
CREATE TABLE [Report] (
  [ReportID] INT PRIMARY KEY,
  [DepartmentID] CHAR(10),
  [GeneratedDate] DATETIME NOT NULL,
  [ReportType] VARCHAR(50),
  [StatusFilter] TEXT,
  [FooterNotes] TEXT,
  FOREIGN KEY ([DepartmentID]) REFERENCES [Department]([DepartmentID])
);
GO

/*-- Tạo bảng [FormResponse]
CREATE TABLE [FormResponse] (
  [ResponseID] INT PRIMARY KEY,
  [ChecklistID] INT,
  [SubmittedByID] INT,
  [SubmissionDate] DATETIME NOT NULL,
  [ResponseData] TEXT,
  FOREIGN KEY ([ChecklistID]) REFERENCES [Checklist]([ChecklistID]),
  FOREIGN KEY ([SubmittedByID]) REFERENCES [User]([UserID])
);
GO
*/
-- Tạo bảng [Director]
CREATE TABLE [Director] (
  [DirectorID] INT IDENTITY(1,1) PRIMARY KEY,
  [UserID] CHAR(10),
  [DepartmentID] CHAR(10),
  FOREIGN KEY ([UserID]) REFERENCES [User]([UserID]),
  FOREIGN KEY ([DepartmentID]) REFERENCES [Department]([DepartmentID])
);
GO

-- Tạo bảng [DepartmentHead]
CREATE TABLE [DepartmentHead] (
  [DepartmentHeadID] INT IDENTITY(1,1) PRIMARY KEY,
  [UserID] CHAR(10),
  [DepartmentID] CHAR(10),
  FOREIGN KEY ([UserID]) REFERENCES [User]([UserID]),
  FOREIGN KEY ([DepartmentID]) REFERENCES [Department]([DepartmentID])
);
GO

-- Tạo bảng [Contractor]
CREATE TABLE [Contractor] (
  [ContractorID] INT IDENTITY(1,1) PRIMARY KEY,
  [UserID] CHAR(10),
  [CompanyName] VARCHAR(255),
  [ContractDuration] DATETIME,
  FOREIGN KEY ([UserID]) REFERENCES [User]([UserID])
);
GO

/*
-- Dữ liệu mẫu cho bảng [Director]
INSERT INTO [Director] (UserID, DepartmentID) VALUES
('DIR001', 12); -- Giám đốc

-- Dữ liệu mẫu cho bảng [DepartmentHead]
INSERT INTO [DepartmentHead] (UserID, DepartmentID) VALUES
('ACC001', 5), -- Trưởng phòng Kế toán
('HRM001', 6), -- Trưởng phòng Hành chính nhân sự
('SEC001', 2); -- Trưởng phòng An ninh

-- Dữ liệu mẫu cho bảng [Contractor]
INSERT INTO [Contractor] (UserID, CompanyName, ContractDuration) VALUES
('CTR001', 'Contractor Company A', '2024-11-05'); -- Đơn vị nhà thầu thi công - tư vấn thuê ngoài
*/




/*
-- Trigger: Kiểm tra trước khi thêm checklist
CREATE TRIGGER trg_CheckActiveUserBeforeChecklist
ON Checklist
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @UserID INT, @IsActive BIT;
    SELECT @UserID = i.CreatedByID FROM inserted i;
    
    -- Kiểm tra trạng thái hoạt động của người dùng
    SELECT @IsActive = IsActive FROM [User] WHERE UserID = @UserID;
    
    IF (@IsActive = 1)
    BEGIN
        -- Nếu người dùng hoạt động, cho phép chèn checklist
        INSERT INTO Checklist (Title, Description, CreatedByID, CreatedDate, DueDate, Status, QR_Code, IsApproved, DepartmentID)
        SELECT Title, Description, CreatedByID, CreatedDate, DueDate, Status, QR_Code, IsApproved, DepartmentID
        FROM inserted;
    END
    ELSE
    BEGIN
        -- Nếu người dùng không hoạt động, hủy bỏ thao tác
        RAISERROR('User is not active. Cannot create a checklist.', 16, 1);
    END
END;
GO

-- Trigger: Cập nhật trạng thái hết hạn của mã QR
CREATE TRIGGER trg_UpdateQRCodeExpiration
ON QRCode
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE QRCode
    SET IsExpired = CASE 
        WHEN ExpirationDate <= GETDATE() THEN 1 
        ELSE 0 
    END
    WHERE ExpirationDate IS NOT NULL;
END;
GO

-- Procedure: Tạo checklist mới
CREATE PROCEDURE sp_CreateChecklist
    @Title VARCHAR(255),
    @Description TEXT,
    @CreatedByID INT,
    @DueDate DATETIME,
    @Status VARCHAR(50),
    @QR_Code VARCHAR(255),
    @DepartmentID INT
AS
BEGIN
    INSERT INTO Checklist (Title, Description, CreatedByID, CreatedDate, DueDate, Status, QR_Code, IsApproved, DepartmentID)
    VALUES (@Title, @Description, @CreatedByID, GETDATE(), @DueDate, @Status, @QR_Code, 0, @DepartmentID);
    
    SELECT SCOPE_IDENTITY() AS ChecklistID;  -- Trả về ID của checklist mới tạo
END;
GO

-- Procedure: Tạo báo cáo phòng ban
CREATE PROCEDURE sp_GenerateDepartmentReport
    @DepartmentID INT,
    @StartDate DATETIME,
    @EndDate DATETIME,
    @StatusFilter VARCHAR(50)
AS
BEGIN
    SELECT cl.ChecklistID, cl.Title, cl.Status, cl.CreatedDate, cl.DueDate, u.FullName AS CreatedBy
    FROM Checklist cl
    INNER JOIN [User] u ON cl.CreatedByID = u.UserID
    WHERE cl.DepartmentID = @DepartmentID
      AND cl.CreatedDate BETWEEN @StartDate AND @EndDate
      AND cl.Status = @StatusFilter;
END;
GO

-- Procedure: Khóa tài khoản nhà thầu hết hạn hợp đồng
CREATE PROCEDURE sp_LockExpiredContractors
AS
BEGIN
    UPDATE [User]
    SET IsActive = 0
    WHERE UserID IN (
        SELECT u.UserID
        FROM Contractor c
        INNER JOIN [User] u ON c.UserID = u.UserID
        WHERE c.ContractDuration <= GETDATE()
    );
    
    -- Thông báo tài khoản đã bị khóa
    SELECT u.UserID, u.FullName, c.ContractDuration
    FROM Contractor c
    INNER JOIN [User] u ON c.UserID = u.UserID
    WHERE u.IsActive = 0;
END;
GO
*/


