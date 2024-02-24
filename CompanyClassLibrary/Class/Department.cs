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

        public Department() { } // Пустой конструктор (без параметров)

        public Department(string departmentName) // Конструктор создает новый объект класса. конструктор инициализирует новый объект Department, устанавливая название отдела и создавая пустой список для хранения сотрудников. 
        {
            Employees = new List<Employee>(); // Создается новый список Employees типа List<Employee>(), который будет хранить информацию о сотрудниках в данном отделе. 
            DepartmentName = departmentName; // Значение параметра departmentName присваивается свойству DepartmentName объекта класса Department.
        }

        public int GetEmployeesCount() // Количество сотрудников
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

        public void PrintEmployessCount()
        {
            Console.WriteLine($"Количестово сотрудников в отделе: {GetEmployeesCount()}");
        }

        public void PrintDepartmentInfo()
        {
            Console.WriteLine($"Название отдела: {DepartmentName}");
            PrintEmployessCount();
        }

        public void PrintEmployeesInfo() // Вывод информации о каждом сотруднике, который работает в данном отделе.
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
               
    }
}
