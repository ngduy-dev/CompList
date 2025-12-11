using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;

namespace FinalProject.Services
{
    public class ServiceDepartment
    {
        private readonly RepositoryDepartment _repositoryDepartment;

        // Phương thức tạo mới phòng ban
        public bool CreateDepartment(ClassDepartment department)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(department.DepartmentID) || string.IsNullOrWhiteSpace(department.DepartmentName))
            {
                Console.WriteLine("Error: DepartmentID hoặc DepartmentName không được để trống.");
                return false;
            }

            // Thực hiện gọi Repository để thêm mới
            return _repositoryDepartment.CreateDepartment(department);
        }

        // Phương thức cập nhật thông tin phòng ban
        public bool UpdateDepartment(ClassDepartment department)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(department.DepartmentID))
            {
                Console.WriteLine("Error: DepartmentID không được để trống.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(department.DepartmentName))
            {
                Console.WriteLine("Error: DepartmentName không được để trống.");
                return false;
            }

            // Gọi Repository để cập nhật
            return _repositoryDepartment.UpdateDepartment(department);
        }

        // Phương thức xóa phòng ban
        public bool DeleteDepartment(string departmentID)
        {
            // Kiểm tra DepartmentID hợp lệ
            if (string.IsNullOrWhiteSpace(departmentID))
            {
                Console.WriteLine("Error: DepartmentID không hợp lệ.");
                return false;
            }

            // Gọi Repository để thực hiện xóa
            return _repositoryDepartment.DeleteDepartment(departmentID);
        }
    }
}
