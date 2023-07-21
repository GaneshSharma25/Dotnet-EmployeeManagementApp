using System.Globalization;
using BOL;
using MySql.Data.MySqlClient;

namespace DAL;

    public class DBManager
    {

    public static string conString = @"server=127.0.0.1;uid=root;pwd=ganesh123;database=dotnet";

    public static List<Employee> GetAllEmployee()
    {
        List<Employee> list = new List<Employee>();
        MySqlConnection con = new MySqlConnection(conString);
        string query = "select * from employees";
        try
        {
            MySqlCommand cmd = new MySqlCommand();
           cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            MySqlDataReader reader = cmd.ExecuteReader();
            // empId | name    | email | password    | location    | joinDate   | salary |
            while (reader.Read())
            {
                int id = int.Parse(reader["empId"].ToString());
                string name = reader["name"].ToString();
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string location = reader["location"].ToString();
                Console.WriteLine(name + " " + location);
                  DateOnly joinDate = DateOnly.FromDateTime(DateTime.Parse(reader["joinDate"].ToString()));
              //  DateOnly joinDate = DateOnly.Parse(reader["joinDate"].ToString());
                double salary = Convert.ToDouble(reader["salary"].ToString());
                Employee emp = new Employee(id,name,email,password, location, joinDate, salary); 
                list.Add(emp); 
                Console.WriteLine(emp);
            }
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return list;
    }

    public static bool InsertEmployee(Employee emp)
    {
        bool status = false;
        string query = $"insert into employees values({emp.EmpId},'{emp.Name}','{emp.Email}','{emp.Password}','{emp.Location}','{emp.JoinDate:yyyy-MM-dd}',{emp.Salary})";
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    }
