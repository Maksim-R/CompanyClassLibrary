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
        string? DepadtmentName { get; set; } = string.Empty;
        public List<Employee>? Employees { get; set; }

        public Department() { }

        public Department(string depadtmentName)
        {
            Employees = new List<Employee>();
            DepadtmentName = depadtmentName;
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
            Console.WriteLine($"Название отдела: {DepadtmentName}");
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
    }
}
