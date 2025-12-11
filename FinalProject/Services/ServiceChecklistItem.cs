using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;

namespace FinalProject.Services
{
    public class ServiceChecklistItem
    {
        private readonly RepositoryChecklistItem _repositoryChecklistItem;

        public ServiceChecklistItem(string connectionString)
        {
            _repositoryChecklistItem = new RepositoryChecklistItem(connectionString);
        }

        // Phương thức thêm mới ChecklistItem
        public bool CreateChecklistItem(ClassChecklistItem checklistItem)
        {
            // Logic kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(checklistItem.ItemID) || string.IsNullOrWhiteSpace(checklistItem.ChecklistID))
            {
                Console.WriteLine("Error: ItemID hoặc ChecklistID không được để trống.");
                return false;
            }

            // Nếu hợp lệ, gọi repository để thêm mới
            return _repositoryChecklistItem.CreateChecklistItem(checklistItem);
        }


        // Phương thức xóa ChecklistItem
        public bool DeleteChecklistItem(string itemID)
        {
            // Logic kiểm tra ID hợp lệ
            if (string.IsNullOrWhiteSpace(itemID))
            {
                Console.WriteLine("Error: ItemID không hợp lệ.");
                return false;
            }

            // Gọi repository để xóa
            return _repositoryChecklistItem.DeleteChecklistItem(itemID);
        }


        // Phương thức lấy thông tin ChecklistItem theo ItemID
        public ClassChecklistItem GetChecklistItemByID(string itemID)
        {
            // Logic kiểm tra ItemID hợp lệ
            if (string.IsNullOrWhiteSpace(itemID))
            {
                Console.WriteLine("Error: ItemID không hợp lệ.");
                return null;
            }

            // Gọi repository để lấy thông tin
            return _repositoryChecklistItem.GetChecklistItemByID(itemID);
        }
    }
}
