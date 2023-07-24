using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<Employee>> getAllEmployees();
    }
}
