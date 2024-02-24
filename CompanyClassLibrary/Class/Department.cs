using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyClassLibrary.Class
{
    public class Department
    {
        protected Guid Id = Guid.NewGuid();
        public string? DepartmentName { get; set; } = string.Empty;
        public List<Employee>? Employees { get; set; }

        public Department() { }

        public Department(string departmentName)
        {
            Employees = new List<Employee>();
            DepartmentName = departmentName;
        }

        public int GetEmployeesCount()
        {
            return Employees.Count;
        }

        public void PrintEmployessCount() 
        {
            Console.WriteLine($"Количестово сотрудников в отделе: {GetEmployeesCount()}");
        }

        public void PrintDepartmentInfo()
        {
            Console.WriteLine($"Название отдела: {DepartmentName}");
            PrintEmployessCount();
        }

        public void PrintEmployeesInfo()
        {
            foreach(Employee employee in Employees)
            {
                employee.Print();
                Console.WriteLine("----------------------");
            }
        }

        public void AddEmpoyeeToDepartment(string firstName, string lastName, string gender, string birthDate, string email, string phone, string employeePosition)
        {
            DateOnly temp;
                      
            DateOnly.TryParse(birthDate, out temp);
            
            Employee employee = new Employee();
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Gender = gender;
            employee.BirthDate = temp;
            employee.Email = email;
            employee.Phone = phone;
            employee.EmployeePosition = employeePosition;

            Employees.Add(employee);
        }
    }
}
