using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;

namespace FinalProject.Services
{
    public class ServiceChecklist
    {
        private readonly RepositoryChecklist _repositoryChecklist;

        public ServiceChecklist(string connectionString)
        {
            _repositoryChecklist = new RepositoryChecklist(connectionString);
        }

        // Phương thức thêm mới Checklist
        public bool CreateChecklist(ClassChecklist checklist)
        {
            // Logic nghiệp vụ: kiểm tra dữ liệu đầu vào trước khi thêm
            if (string.IsNullOrWhiteSpace(checklist.ChecklistID) || string.IsNullOrWhiteSpace(checklist.Title))
            {
                Console.WriteLine("Error: ChecklistID hoặc Title không được để trống.");
                return false;
            }

            // Nếu không có lỗi, gọi Repository để thực hiện lưu trữ
            return _repositoryChecklist.CreateChecklist(checklist);
        }

        // Phương thức cập nhật Checklist
        public bool UpdateChecklist(ClassChecklist checklist)
        {
            // Logic nghiệp vụ: kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(checklist.ChecklistID))
            {
                Console.WriteLine("Error: ChecklistID không được để trống.");
                return false;
            }

            // Kiểm tra trạng thái hợp lệ (nếu có yêu cầu nghiệp vụ cụ thể)
            var validStatuses = new List<string> { "Pending", "Completed", "In Progress" };
            if (!validStatuses.Contains(checklist.Status))
            {
                Console.WriteLine("Error: Trạng thái không hợp lệ.");
                return false;
            }

            // Gọi repository để cập nhật
            return _repositoryChecklist.UpdateChecklist(checklist);
        }

        // Phương thức xóa Checklist
        public bool DeleteChecklist(string checklistID)
        {
            // Logic nghiệp vụ: kiểm tra ID không được để trống
            if (string.IsNullOrWhiteSpace(checklistID))
            {
                Console.WriteLine("Error: ChecklistID không được để trống.");
                return false;
            }

            // Gọi repository để xóa
            return _repositoryChecklist.DeleteChecklist(checklistID);
        }

        // Phương thức lấy thông tin Checklist theo ID
        public ClassChecklist GetChecklistByID(string checklistID)
        {
            // Logic nghiệp vụ: kiểm tra ID hợp lệ
            if (string.IsNullOrWhiteSpace(checklistID))
            {
                Console.WriteLine("Error: ChecklistID không hợp lệ.");
                return null;
            }

            // Gọi repository để lấy dữ liệu
            return _repositoryChecklist.GetChecklistByID(checklistID);
        }

        // Phương thức tạo QRCode cho Checklist
        public string GenerateQRCodeForChecklist(string checklistID)
        {
            // Logic nghiệp vụ: kiểm tra ID hợp lệ
            if (string.IsNullOrWhiteSpace(checklistID))
            {
                Console.WriteLine("Error: ChecklistID không hợp lệ.");
                return null;
            }

            // Gọi repository để tạo QRCode
            return _repositoryChecklist.GenerateQRCode(checklistID);
        }
    }
}
