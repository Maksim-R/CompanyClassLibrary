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
        public List<Employee>? Employees { get; set; } // Список сотрудников

        // Пустой конструктор (без параметров)
        public Department() { }

        // Конструктор создает новый объект класса. конструктор инициализирует новый объект Department, устанавливая название отдела и создавая пустой список для хранения сотрудников.        
        public Department(string departmentName)
        {
            Employees = new List<Employee>(); // Создается новый список Employees типа List<Employee>(), который будет хранить информацию о сотрудниках в данном отделе. 
            DepartmentName = departmentName; // Значение параметра departmentName присваивается свойству DepartmentName объекта класса Department.
        }

        /// <summary>
        /// Получает общее количество сотрудников в отделе.
        /// </summary>
        /// <returns>Общее количество сотрудников.</returns>
        /// <remarks>
        /// Метод проверяет, что список сотрудников не равен null, и возвращает количество сотрудников в списке.
        /// Возвращает 0, если список сотрудников не инициализирован (равен null).
        /// </remarks>
        public int GetEmployeesCount()
        {
            if (Employees != null) // Проверяем, что список сотрудников не равен null
            {
                return Employees.Count; // Возвращае количество сторудников из списка List<Employee>?
            }
            else
            {
                return 0; // Возвращает 0, если список сотрудников не инициализирован (равен null)
            }
        }

        /// <summary>
        /// Выводит информацию об общем количестве сотрудников в отделе.
        /// </summary>
        public void PrintEmployessCount()
        {
            Console.WriteLine($"Количестово сотрудников в отделе: {GetEmployeesCount()}");
        }

        /// <summary>
        /// Выводит информацию о текущем отделе, включая название и количество сотрудников.
        /// </summary>
        public void PrintDepartmentInfo()
        {
            Console.WriteLine($"Название отдела: {DepartmentName}");
            PrintEmployessCount();
        }

        /// <summary>
        /// Выводит информацию о каждом сотруднике, работающем в данном отделе.
        /// </summary>
        public void PrintEmployeesInfo()
        {
            if (Employees != null)
            {
                foreach (Employee employee in Employees) // Цикл перебирает каждого сотрудника (Employee) в списке Employees текущего отдела.
                {
                    employee.Print();
                    Console.WriteLine("----------------------");
                }
            }
        }

        /// <summary>
        /// Добавляет сотрудника в отдел.
        /// </summary>
        /// <param name="employee">Сотрудник для добавления.</param>
        public void AddEmployee(Employee employee)
        {
            if(employee != null) { Employees.Add(employee); }
        }

        /// <summary>
        /// Удаляет сотрудника из отдела.
        /// </summary>
        /// <param name="employee">Сотрудник для удаления.</param>
        public void DeleteEmployee(Employee employee)
        {
            if (employee != null) { Employees.Remove(employee); }
        }

        /// <summary>
        /// Удаляет сотрудника из отдела по табельному номеру.
        /// </summary>
        /// <param name="tabNumber">Табельный номер сотрудника.</param>
        public void DeleteEmployee(int tabNumber)
        {
            Employee employee = Employees.FirstOrDefault(e => e.TabNumber == tabNumber);
                
            if (employee != null) 
            { 
                Employees.Remove(employee); 
            }
        }

        /// <summary>
        /// Проверяет наличие сотрудника в отделе.
        /// </summary>
        /// <param name="employee">Сотрудник для проверки.</param>
        /// <returns>True, если сотрудник найден в отделе, иначе - False.</returns>
        public bool ContainsEmployee(Employee employee)
        {
            bool resultEmp = false;
            if (employee != null)
            {
                resultEmp = Employees.Contains(employee);
            }
            return resultEmp;            
        }

        //// Метод для поиска отдела по параметру
        //public void SearchDepartment(string nameDepartment)
        //{
        //    Department department;
        //    if (nameDepartment != null)
        //    {
        //        var temp = Departments.FirstOrDefault(department => department.DepartmentName == "IT");
        //        if (temp != null) department = temp;
        //    }
        //    else
        //    {
        //        department = new Department();
        //    }
        //}


    }
}
