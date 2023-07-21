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
    }
