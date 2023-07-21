using BLL;
using BOL;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            HrManager manager = new HrManager();
            List<BOL.Employee> empList = manager.GetAllEmployees();
            this.ViewData["employees"] = empList;
            return View();
        }
        public IActionResult Login()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult Welcome(string email, string password)
        {
            HrManager manager = new HrManager();
            List<BOL.Employee> empList = manager.GetAllEmployees();
            bool flag = false;
            Employee matchedEmployee = null;
            foreach (Employee emp in empList)
            {
                if (emp.Email == email && emp.Password == password)
                {
                    flag = true;
                    matchedEmployee = emp;
                    break;
                }
            }

            if (flag&& matchedEmployee != null)
            {
                //return RedirectToAction("Welcome",matchedEmployee);
                return View("Welcome", matchedEmployee);
            }
            else
            {
                Console.WriteLine("Invalid Details");
                return RedirectToAction("Login");
                //return View();
            }  
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(int empid, string name, string email, string password, string location, string joindate,double salary) {
            
               Employee emp = new Employee(empid, name, email, password, location, DateOnly.Parse(joindate), salary);
            Console.WriteLine(emp);
            HrManager manager = new HrManager();
            bool check = manager.InsertEmployee(emp);
            if(check)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Welcome()
        {
            return View();
        }
    }
}
