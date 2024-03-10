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

        /// <summary>
        /// Выводит информацию о компании в консоль, включая название и описание.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Название Kомпании: {Name}");
            Console.WriteLine($"Описание Kомпании: {Description}");
            Console.WriteLine("*******************************");
        }

        /// <summary>
        /// Возвращает количество отделов в компании.
        /// </summary>
        /// <returns>Количество отделов в компании.</returns>
        public int GetDepartmentsCount() 
        { 
            return Departments.Count; 
        }

        /// <summary>
        /// Выводит количество отделов компании в консоль.
        /// </summary>
        public void PrintDepartmentsCount()
        {
            Console.WriteLine($"Количество отделов: {GetDepartmentsCount()}");
            Console.WriteLine("*******************************");
        }

        /// <summary>
        /// Выводит информацию о каждом отделе компании в консоль, включая количество отделов и сведения о сотрудниках в каждом отделе.
        /// </summary>
        public void PrintDepartmentsInfo()
        {
            PrintDepartmentsCount();
            foreach (Department department in Departments)
            {
                department.PrintDepartmentInfo();
                Console.WriteLine("---------------------");
                department.PrintEmployeesInfo();
            }
        }

        /// <summary>
        /// Возвращает общее количество сотрудников во всех отделах компании.
        /// </summary>
        /// <returns>Общее количество сотрудников во всех отделах компании.</returns>
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

        /// <summary>
        /// Добавляет новые отделы в список отделов компании.
        /// </summary>
        /// <param name="departmentNames">Массив строк с названиями новых отделов.</param>
        public void AddDepartments(string[] departmentNames) 
        {
            foreach (string departmentName in departmentNames) //  цикл foreach, перебирает каждый элемент в массиве departmentNames. Для каждого элемента цикл присваивает значение переменной departmentName.
            {
                Departments.Add(new Department(departmentName)); // Внутри цикла foreach создается новый объект класса Department с именем departmentName. Затем этот новый объект добавляется в список Departments компании с помощью метода Add.
            }
        }

        /// <summary>
        /// Добавляет сотрудника в отдел компании.
        /// </summary>
        /// <param name="employee">Добавляемый сотрудник.</param>
        public void AddEmployeeToDepartment(Employee employee)
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

        /// <summary>
        /// Удаляет сотрудника из его текущего отдела.
        /// </summary>
        /// <param name="employee">Удаляемый сотрудник.</param>
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

        /// <summary>
        /// Поиск сотрудника по табельному номеру в отделах компании.
        /// </summary>
        /// <param name="tabNumber">Табельный номер сотрудника.</param>
        /// <returns>Сотрудник с указанным табельным номером или null, если сотрудник не найден.</returns>
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

        /// <summary>
        /// Перемещает сотрудника из текущего отдела в указанный отдел.
        /// </summary>
        /// <param name="tabNumber">Табельный номер перемещаемого сотрудника.</param>
        /// <param name="newEmployeeDepartment">Название нового отдела.</param>
        public void MovingEmployeeDepartent(int tabNumber, string newEmployeeDepartment)
        {
            Employee resultEmpl = null;

            foreach (Department dep in Departments)
            {
                resultEmpl = dep.Employees.FirstOrDefault(e => e.TabNumber == tabNumber);
                if (resultEmpl != null) break;
                else Console.WriteLine($"Сотрудник: {resultEmpl.FirstName} не найден");
            }

            Department resultDep = null;
            if (resultEmpl != null) 
            {
                resultDep = Departments.FirstOrDefault(emp => emp.DepartmentName == newEmployeeDepartment);

                if (resultDep != null)
                {
                    resultDep.Employees.Add(resultEmpl);
                    RemoveEmployeeFromDepartment(resultEmpl);
                    Console.WriteLine($"Сотрудник: {resultEmpl.FirstName}, Перемещен в отдел: {newEmployeeDepartment}");
                }
            }      
        }

        /// <summary>
        /// Выводит информацию о наличии сотрудника в отделах компании.
        /// </summary>
        /// <param name="tempEmployee">Сотрудник, для которого проверяется наличие в отделах.</param>
        public void PrintContainsEmployee(Employee tempEmployee)
        {
            if (tempEmployee != null)
            {
                Departments.ForEach(emp =>
                {
                    if (emp.ContainsEmployee(tempEmployee))
                    {
                        Console.WriteLine($"Сотрудник {tempEmployee.LastName}, с табельным № {tempEmployee.TabNumber}, находится в отделе {tempEmployee.DepartmentName} ");
                    }
                });
            }
            else Console.WriteLine("Ошибка при поиске сотрудника");
        }
    }
}
