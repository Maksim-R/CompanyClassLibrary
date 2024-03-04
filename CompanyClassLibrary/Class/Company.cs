using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

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

        // Метод GetTotalEmployeesCount отображает общего количества сотрудников во всех отделах компании
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

        // Метод AddDepartments добавляет отделы в список принимает на вход массив строк с именами отделов. company.Departments.Add(массив с именами департаментов)
        public void AddDepartments(string[] departmentNames) // объявление метода AddDepartments, в классе Company. Метод принимает один значение типа string[], массив строк с названиями отделов.
        {
            foreach (string departmentName in departmentNames) //  цикл foreach, перебирает каждый элемент в массиве departmentNames. Для каждого элемента цикл присваивает значение переменной departmentName.
            {
                Departments.Add(new Department(departmentName)); // Внутри цикла foreach создается новый объект класса Department с именем departmentName. Затем этот новый объект добавляется в список Departments компании с помощью метода Add.
            }
        }

        // Метод AddEmployeeToDepartment добавляет сотрудника в нужный отдел. 
        public void AddEmployeeToDepartment(Employee employee) // Принимает на вход список сотрудников employee и названия департаментов
        {
            // Параметр берем у созданного сотрудника обращаясь к полю объекта empliyee
            string departmentName = employee.DepartmentName;
            // Находим отдел по имени
            Department department = Departments.FirstOrDefault(dep => dep.DepartmentName == departmentName);

            // Если отдел найден, добавляем сотрудника
            if (department != null)
            {
                department.Employees.Add(employee);
                Console.WriteLine($"Сотрудник {employee.FirstName} {employee.LastName} добавлен в отдел {departmentName}");
            }
            else
            {
                Console.WriteLine($"Отдел {departmentName} не найден");
            }
        }

        // Метод RemoveEmployeeFromDepartment удаляет объект сотрудника
        public void RemoveEmployeeFromDepartment(Employee employee)
        {
            int tab = employee.TabNumber;
            string departmentName = employee.DepartmentName;

            Department department = Departments.FirstOrDefault(dep => dep.DepartmentName == departmentName); 
            if (department != null) 
            {
                department.Employees.Remove(employee);
                Console.WriteLine($"Сотрудник: {employee.FirstName}, Удален из отдела: {departmentName} ");
            }
        }

        // Метод GetEmployee поиск объекта сотрудника по табельному номеру
        public Employee GetEmployee(int tabNumber)
        {
            Employee result = null;

            foreach(Department dep in Departments) 
            {
                result = dep.Employees.FirstOrDefault(e => e.TabNumber == tabNumber);
                if (result != null)
                {
                    break;
                }                
            }
            return result;
        }

        // Метод перемещения объекта Employye в списке Departments
        /**
        * Описание работы метода
        * На вход принимается объект Employye с полями: int tabNumber, новым именем поля EmployeePosition
        * Цикл foreach перебирает в объекте класса Department список Departments и сравнивает с данными принятыми на вход.
        * Когда объект найден по табельномоу номеру применяем метод списка Remove для удаления объекта из этого списка
        * Далее применяем к объекту метод списка Add для добавления в новый отдел.
        * 
        */
        // public void  MovingEmployeeDepartent(Employee employee, string newEmployeePosition)
        // {
        //     int tab = employee.TabNumber;
        //     string departmentName = employee.DepartmentName;            
            
        //     foreach(Department dep in Departments)
        //     {
        //         result = dep.Employees.Remove(e => e.TabNumber==tabNumber);
        //     }
        // }
    }
}
