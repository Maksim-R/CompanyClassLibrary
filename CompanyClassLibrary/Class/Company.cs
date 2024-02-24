using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyClassLibrary.Class
{
    public class Company
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        public Company() { }
        public Company(string? name, string? description) 
        {  
            Name = name; 
            Description = description; 
        }

        public void Print()
        {
            Console.WriteLine($"Название Kомпании: {Name}");
            Console.WriteLine($"Описание Kомпании: {Description}");
            Console.WriteLine("*******************************");
        }

        public int GetDepartmentsCount() 
        { 
            return Departments.Count; 
        }

        public void PrintDepartmentsCount() 
        {
            Console.WriteLine($"Количество отделов: {GetDepartmentsCount()}");
        }

        public void PrintDepartmentsInfo() // Выводит в консоль количество отделов и сотрудников
        {
            PrintDepartmentsCount();
            foreach (Department department in Departments)
            {
                department.PrintDepartmentInfo();
                Console.WriteLine("---------------------");
                department.PrintEmployeesInfo();
            }
        }

    }
}
