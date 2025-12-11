using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;

namespace FinalProject.Services
{
    public class ServiceUser
    {
        private readonly RepositoryUser _repositoryUser;

        public ServiceUser(string connectionString)
        {
            _repositoryUser = new RepositoryUser();
        }


        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            string hashedInput = HashPassword(inputPassword);
            return hashedPassword == hashedInput;
        }
    }
}
