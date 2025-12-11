using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;

namespace FinalProject.Services
{
    public class ServiceEmployee
    {
        private readonly RepositoryEmployee _repositoryEmployee;

        public ServiceEmployee(string connectionString)
        {
            _repositoryEmployee = new RepositoryEmployee();
        }
    }
}
