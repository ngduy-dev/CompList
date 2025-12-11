-- DROP và CREATE DATABASE
USE MASTER;
DROP DATABASE IF EXISTS CHECKLIST;
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
('DP001', 'Engineering'),
('DP002', 'Security'),
('DP003', 'Sanitation'),
('DP004', 'Landscaping'),
('DP005', 'Accounting'),
('DP006', 'Human Resources'),
('DP007', 'Resident Services'),
('DP008', 'Construction'),
('DP009', 'Driving'),
('DP010', 'Kitchen'),
('DP011', 'Warehouse'),
('DP012', 'Executive Management'),
('DP013', 'Contractor Services');
GO


-- Tạo bảng [User]
CREATE TABLE [User] (
  [UserID] CHAR(10) PRIMARY KEY, 
  [Username] VARCHAR(255) NOT NULL,
  [Password] VARCHAR(255) NOT NULL,
  [FullName] VARCHAR(255) NOT NULL,
  [Email] VARCHAR(255),
  [PhoneNumber] VARCHAR(20),
  [LastLogin] DATETIME,
  [IsActive] BIT,
  [DepartmentID] CHAR(10)
  FOREIGN KEY ([DepartmentID]) REFERENCES [Department]([DepartmentID])
);
GO

INSERT INTO [User] (UserID, Username, Password, FullName, Email, PhoneNumber, LastLogin, IsActive, DepartmentID) VALUES
('DIR001', 'director_lethanhha', 'pass123', 'Le Thanh Ha', 'lethanhha@companyname.com', '123456789', '2024-10-24 09:30', 1, 'DP012'), -- Giám đốc
('ENG001', 'engineer_tranvanan', 'pass123', 'Tran Van An', 'tranvanan@companyname.com', '987654321', '2024-10-25 08:00', 1, 'DP001'), -- Kỹ thuật
('SEC001', 'security_nguyenhongson', 'pass123', 'Nguyen Hong Son', 'nguyenhongson@companyname.com', '876543210', '2024-10-26 07:45', 1, 'DP002'), -- An ninh
('CLN001', 'cleaner_phamminhtam', 'pass123', 'Pham Minh Tam', 'phamminhtam@companyname.com', '765432109', '2024-10-27 06:00', 1, 'DP003'), -- Vệ sinh
('LAN001', 'landscaping_phamthihoa', 'pass123', 'Pham Thi Hoa', 'phamthihoa@companyname.com', '654321098', '2024-10-28 07:00', 1, 'DP004'), -- Cây cảnh
('ACC001', 'accountant_hoangthiyen', 'pass123', 'Hoang Thi Yen', 'hoangthiyen@companyname.com', '543210987', '2024-10-29 09:00', 1, 'DP005'), -- Kế toán
('HRM001', 'hr_maidangthao', 'pass123', 'Mai Dang Thao', 'maidangthao@companyname.com', '432109876', '2024-10-30 10:15', 1, 'DP006'), -- Hành chính nhân sự
('RES001', 'residentservice_vothithao', 'pass123', 'Vo Thi Thao', 'vothithao@companyname.com', '321098765', '2024-10-31 08:30', 1, 'DP007'), -- Dịch vụ cư dân
('CON001', 'construction_hoangkimlong', 'pass123', 'Hoang Kim Long', 'hoangkimlong@companyname.com', '210987654', '2024-11-01 08:00', 1, 'DP008'), -- Xây dựng
('DRV001', 'driver_dangthanhhoa', 'pass123', 'Dang Thanh Hoa', 'dangthanhhoa@companyname.com', '109876543', '2024-11-02 07:00', 1, 'DP009'), -- Lái xe
('CKN001', 'cook_nguyenthivan', 'pass123', 'Nguyen Thi Van', 'nguyenthivan@companyname.com', '098765432', '2024-11-03 06:45', 1, 'DP010'), -- Bếp
('WHM001', 'warehouse_letuanhung', 'pass123', 'Le Tuan Hung', 'letuanhung@companyname.com', '987654321', '2024-11-04 08:15', 1, 'DP011'), -- Kho
('CTR001', 'contractor_phamquanghuy', 'pass123', 'Pham Quang Huy', 'phamquanghuy@companyname.com', '876543210', '2024-11-05 09:30', 1, 'DP013'); -- Đơn vị nhà thầu thi công - tư vấn thuê ngoài
GO


-- Tạo bảng [Employee]
CREATE TABLE [Employee] (
  [EmployeeID] CHAR(10) PRIMARY KEY,
  [Name] VARCHAR(255) NOT NULL,
  [NumberPhone] VARCHAR(20),
  [DepartmentID] CHAR(10),
  [Email] VARCHAR(255),
  [IsActive] BIT NOT NULL DEFAULT 1, -- Thêm trạng thái làm việc
  FOREIGN KEY ([DepartmentID]) REFERENCES [Department]([DepartmentID])
);
GO

-- Thêm dữ liệu vào bảng [Employee] với trạng thái làm việc được chỉ định
INSERT INTO [Employee] (EmployeeID, Name, NumberPhone, DepartmentID, Email, IsActive) VALUES
('EMP011', 'CR7', '753159864', 'DP011', 'CR7@companyname.com', 1),
('EMP012', 'Messi', '753159864', 'DP012', 'Messi@companyname.com', 1),
('EMP013', 'Suarez', '753159864', 'DP013', 'suarez@companyname.com', 0),
('EMP001', 'John Smith', '123456789', 'DP001', 'john.smith@companyname.com', 1),
('EMP002', 'Alice Johnson', '987654321', 'DP002', 'alice.johnson@companyname.com', 0),
('EMP003', 'Robert Brown', '456123789', 'DP003', 'robert.brown@companyname.com', 1),
('EMP004', 'Linda Davis', '321654987', 'DP004', 'linda.davis@companyname.com', 0),
('EMP005', 'Michael Wilson', '654321789', 'DP005', 'michael.wilson@companyname.com', 1),
('EMP006', 'Emily Garcia', '789654123', 'DP006', 'emily.garcia@companyname.com', 1),
('EMP007', 'David Martinez', '159753486', 'DP007', 'david.martinez@companyname.com', 1),
('EMP008', 'Sophia Rodriguez', '753159864', 'DP008', 'sophia.rodriguez@companyname.com', 0),
('EMP009', 'James Lee', '258147369', 'DP009', 'james.lee@companyname.com', 1),
('EMP010', 'Emma Thompson', '369258147', 'DP010', 'emma.thompson@companyname.com', 1),
('EMP014', 'Neymar', '753159865', 'DP012', 'neymar@companyname.com', 1),
('EMP015', 'Pogba', '753159866', 'DP009', 'pogba@companyname.com', 0),
('EMP016', 'Mbappe', '753159867', 'DP011', 'mbappe@companyname.com', 1),
('EMP017', 'Kante', '753159868', 'DP013', 'kante@companyname.com', 0),
('EMP018', 'Salah', '753159869', 'DP001', 'salah@companyname.com', 1),
('EMP019', 'Sterling', '753159870', 'DP002', 'sterling@companyname.com', 1),
('EMP020', 'De Bruyne', '753159871', 'DP005', 'debruyne@companyname.com', 1),
('EMP021', 'Rashford', '753159872', 'DP006', 'rashford@companyname.com', 1),
('EMP022', 'Benzema', '753159873', 'DP012', 'benzema@companyname.com', 1),
('EMP023', 'Lewandowski', '753159874', 'DP007', 'lewandowski@companyname.com', 1),
('EMP024', 'Vidal', '753159875', 'DP006', 'vidal@companyname.com', 0),
('EMP025', 'Kimmich', '753159876', 'DP003', 'kimmich@companyname.com', 1),
('EMP026', 'Modric', '753159877', 'DP002', 'modric@companyname.com', 1),
('EMP027', 'Haaland', '753159878', 'DP004', 'haaland@companyname.com', 1),
('EMP028', 'Son', '753159879', 'DP005', 'son@companyname.com', 1);
GO

-- Tạo bảng [Checklist]
CREATE TABLE [Checklist] (
  [ChecklistID] CHAR(10) PRIMARY KEY,
  [Title] VARCHAR(255) NOT NULL,
  [Description] TEXT,
  [CreatedByID] CHAR(10),
  [CreatedDate] DATETIME NOT NULL,
  [DueDate] DATETIME,
  [Status] VARCHAR(50),
  [DepartmentID] CHAR(10),
  FOREIGN KEY ([CreatedByID]) REFERENCES [User]([UserID]),
  FOREIGN KEY ([DepartmentID]) REFERENCES [Department]([DepartmentID])
);
GO

INSERT INTO [Checklist] (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) VALUES
('CHK001', 'Daily Maintenance Checklist', 'A checklist for daily maintenance tasks.', 'ACC001', '2024-11-01', '2024-11-02', 'Open', 'DP001'),
('CHK002', 'Security Audit Checklist', 'Checklist for security audits and inspections.', 'SEC001', '2024-11-01', '2024-11-05', 'In Progress', 'DP002'),
('CHK003', 'Sanitation Inspection Checklist', 'Checklist for sanitation inspections.', 'CLN001', '2024-11-01', '2024-11-03', 'Complete', 'DP003'),
('CHK004', 'Equipment Maintenance Checklist', 'A checklist for regular equipment maintenance tasks.', 'ENG001', '2024-11-01', '2024-11-04', 'Open', 'DP004'),
('CHK005', 'Security Protocol Review Checklist', 'Checklist for reviewing security protocols.', 'SEC001', '2024-11-01', '2024-11-06', 'In Progress', 'DP005'),
('CHK006', 'Waste Disposal Checklist', 'Checklist for proper waste disposal procedures.', 'CLN001', '2024-11-01', '2024-11-03', 'Complete', 'DP006'),
('CHK007', 'Landscaping Project Checklist', 'Checklist for planning and executing landscaping projects.', 'LAN001', '2024-11-01', '2024-11-07', 'Open', 'DP007'),
('CHK008', 'Monthly Financial Review Checklist', 'Checklist for monthly financial review and reporting.', 'ACC001', '2024-11-01', '2024-11-08', 'In Progress', 'DP008'),
('CHK009', 'HR Policy Update Checklist', 'Checklist for updating HR policies and procedures.', 'HRM001', '2024-11-01', '2024-11-05', 'Complete', 'DP009'),
('CHK010', 'Resident Feedback Checklist', 'Checklist for collecting resident feedback and suggestions.', 'RES001', '2024-11-01', '2024-11-06', 'Open', 'DP010'),
('CHK011', 'Construction Safety Checklist', 'Checklist for ensuring safety on construction sites.', 'CON001', '2024-11-01', '2024-11-09', 'In Progress', 'DP011'),
('CHK012', 'Driver Safety Protocol Checklist', 'Checklist for ensuring safety protocols are followed by drivers.', 'DRV001', '2024-11-01', '2024-11-05', 'Complete', 'DP012'),
('CHK013', 'Weekly Maintenance Checklist', 'Checklist for weekly maintenance tasks.', 'ACC001', '2024-11-06', '2024-11-13', 'Open', 'DP001'),
('CHK014', 'Monthly Audit Checklist', 'Checklist for monthly audit tasks.', 'SEC001', '2024-11-06', '2024-11-30', 'In Progress', 'DP002');
GO

-- Tạo bảng [ChecklistItem]
CREATE TABLE [ChecklistItem] (
  [ItemID] CHAR(10) PRIMARY KEY,
  [ChecklistID] CHAR(10),
  [TaskDescription] TEXT,
  [IsCompleted] BIT,
  [DueDate] DATETIME,
  [EmployeeID] CHAR(10),
  FOREIGN KEY ([ChecklistID]) REFERENCES [Checklist]([ChecklistID]),
  FOREIGN KEY ([EmployeeID]) REFERENCES [Employee]([EmployeeID])
);
GO

-- Chèn dữ liệu vào bảng [ChecklistItem]
INSERT INTO [ChecklistItem] (ItemID, ChecklistID, TaskDescription, IsCompleted, DueDate, EmployeeID) VALUES
('ITEM001', 'CHK001', 'Inspect equipment', 1, '2024-11-02', 'EMP001'),
('ITEM002', 'CHK001', 'Replace air filters', 0, NULL, 'EMP002'),
('ITEM003', 'CHK002', 'Verify camera footage', 1, '2024-11-04', 'EMP003'),
('ITEM004', 'CHK002', 'Check security alarms', 0, NULL, 'EMP004'),
('ITEM005', 'CHK003', 'Inspect kitchen sanitation', 1, '2024-11-03', 'EMP005'),
('ITEM006', 'CHK003', 'Check restroom cleanliness', 1, '2024-11-03', 'EMP006'),
('ITEM007', 'CHK004', 'Lubricate machinery', 0, NULL, 'EMP007'),
('ITEM008', 'CHK004', 'Inspect electrical connections', 1, '2024-11-04', 'EMP008'),
('ITEM009', 'CHK005', 'Update access control list', 0, NULL, 'EMP009'),
('ITEM010', 'CHK005', 'Test fire alarm system', 1, '2024-11-06', 'EMP010'),
('ITEM011', 'CHK006', 'Remove hazardous waste', 1, '2024-11-03', 'EMP001'),
('ITEM012', 'CHK006', 'Check waste disposal logs', 0, NULL, 'EMP002'),
('ITEM013', 'CHK007', 'Plan new flower beds', 0, NULL, 'EMP003'),
('ITEM014', 'CHK007', 'Trim hedges', 1, '2024-11-07', 'EMP004'),
('ITEM015', 'CHK008', 'Verify financial reports', 1, '2024-11-08', 'EMP005'),
('ITEM016', 'CHK008', 'Prepare monthly budget', 0, NULL, 'EMP006'),
('ITEM017', 'CHK009', 'Review policy changes', 1, '2024-11-05', 'EMP007'),
('ITEM018', 'CHK009', 'Update employee handbook', 0, NULL, 'EMP008'),
('ITEM019', 'CHK010', 'Conduct resident interviews', 0, NULL, 'EMP009'),
('ITEM020', 'CHK010', 'Collect feedback forms', 1, '2024-11-06', 'EMP010'),
('ITEM021', 'CHK013', 'Inspect equipment', 1, '2024-11-07', 'EMP001'),
('ITEM022', 'CHK013', 'Check lighting systems', 0, NULL, 'EMP002'),
('ITEM023', 'CHK013', 'Lubricate machinery', 1, '2024-11-08', 'EMP003'),
('ITEM024', 'CHK013', 'Replace filters', 0, NULL, 'EMP004'),
('ITEM025', 'CHK013', 'Clean ventilation system', 1, '2024-11-09', 'EMP005');
GO 

-- Tạo bảng [QRCode]
CREATE TABLE [QRCode] (
  [QRCodeID] INT PRIMARY KEY,
  [ChecklistID] CHAR(10),
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


