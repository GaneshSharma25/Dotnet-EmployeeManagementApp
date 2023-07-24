using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        
    }
}
