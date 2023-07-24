using BOL;
using DAL;
namespace BLL;

    public class HrManager
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            list = DBManager.GetAllEmployee();
            return list;
        }

    public bool InsertEmployee(Employee emp)
    {
       return DBManager.InsertEmployee(emp);
    }

    public bool DeleteEmployee(int empId)
    {
        return DBManager.DeleteEmployee(empId);
    }
    public bool UpdateEmployee(Employee emp)
    {
        return DBManager.UpdateEmployee(emp);
    }

    }
