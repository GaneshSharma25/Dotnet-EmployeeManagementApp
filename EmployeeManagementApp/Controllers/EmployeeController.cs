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
                ViewBag.ResultEmployee = matchedEmployee;
                return View();
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

        public IActionResult DeleteEmployee(int EmpId)
        {
            HrManager manager =new HrManager();
            bool check = manager.DeleteEmployee(EmpId);
            if(check)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Register");
        }
        public IActionResult Welcome()
        {
         
            return View();
        }

        public IActionResult UpdateEmployee(int empId)
        {
            HrManager manager = new HrManager();
            Console.WriteLine(empId);
            List<BOL.Employee> empList = manager.GetAllEmployees();
            Employee matched = null;
            empList.ForEach(delegate (Employee e)
            {
                if(e.EmpId == empId)
                {
                    matched = e;
                    return;
                }
            });
            if(matched != null)
            {
                return View("UpdateEmployee",matched);
            }

            // Employee emp1 = emp;
            return View("UpdateEmployee","emp");
        }
        [HttpPost]
        public IActionResult UpdateEmployee(int empid, string name, string email, string password, string location, string joindate, double salary)
        {
            Console.WriteLine("EmpId: "+empid +"Name: " + name +email +password);
            Console.WriteLine("joindate: " + joindate);

            Employee emp = new Employee(empid, name, email, password, location, DateOnly.Parse(joindate), salary);
            HrManager manager = new HrManager();
            bool check = manager.UpdateEmployee(emp);
            if (check)
            {
               ViewBag.ResultEmployee = emp;
                return View("Welcome");
            }
            return View("Login");
        }
    }
}
