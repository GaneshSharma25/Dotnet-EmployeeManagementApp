using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using Org.BouncyCastle.Asn1.Mozilla;
using Repositories.Interfaces;

namespace EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Employee>> getAllEmployees()
        {
            return await _repo.GetAll();
        }
    }
}
