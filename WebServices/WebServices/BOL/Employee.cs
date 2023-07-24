using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL;

public class Employee
{
    private int empId;
    private string name;
    private string email;
    private string password;
    private string location;
    private DateOnly joinDate;
    private double salary;

    public Employee(int empId, string name, string email, string password, string location, DateOnly joinDate, double salary)
    {
        this.empId = empId;
        this.name = name;
        this.email = email;
        this.password = password;
        this.location = location;
        this.joinDate = joinDate;
        this.salary = salary;
    }
    public int EmpId { get { return empId; } set { empId = value; } }
    public string Name { get { return name; } set { name = value; } }
    public string Email { get { return email; } set { email = value; } }
    public string Password { get { return password; } set { password = value; } }
    public string Location { get { return location; } set { location = value; } }
    public DateOnly JoinDate { get { return joinDate; } set { joinDate = value; } }
    public double Salary { get { return salary; } set { salary = value; } }

    public override string? ToString()
    {
        return $"EmpID: {empId}, Name: {name}, Email: {email} Location: {location}, JoinDate: {joinDate}, Salary: {salary}";
    }
}

