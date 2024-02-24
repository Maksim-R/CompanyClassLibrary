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

        // Метод для подсчета общего количества сотрудников во всех отделах компании
        public int GetTotalEmployeesCount()
        {
            int totalEmployeesCount = 0; // Инициализируем переменную для хранения общего количества сотрудников
            foreach (var department in Departments) // Для каждого отдела в списке отделов компании
            {
                if (department.Employees != null) // Проверяем, что список сотрудников отдела не равен null
                {
                    totalEmployeesCount += department.Employees.Count; // Увеличиваем общее количество сотрудников на количество сотрудников в текущем отделе
                }
            }
            return totalEmployeesCount; // Возвращаем общее количество сотрудников
        }

    }
}
