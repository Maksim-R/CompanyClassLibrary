using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyClassLibrary.Class
{
    public class Employee : Person
    {
        public string? EmployeePosition { get; set; }

        public string? NewEmployeeDepartment { get; set; } // Новое название отдела куда переместить сотрудника

        public string? DepartmentName { get; set; } // Название отдела, к которому принадлежит сотрудник

        public int TabNumber { get; set; }

        // Вызов пустого конструктора. GUID - создается автоматически при создании объекта.
        public Employee() { }

        // Конструктор со всеми параметрами объекта сотрудика
        public Employee(int tabNumber, string departmentName, string firstName, string lastName, string birthDate, string gender, string email, string phone, string employeePosition)
        {
            DateOnly temp;

            DateOnly.TryParse(birthDate, out temp);

            TabNumber = tabNumber;
            DepartmentName = departmentName;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = temp;
            Gender = gender;
            Email = email;
            Phone = phone;
            EmployeePosition = employeePosition;            
        }

        // Конструктор параметрами объекта сотрудика для перемещения в новый отдел
        public Employee(int tabNumber, string newEmployeeDepartment)
        {
            TabNumber = tabNumber;
            NewEmployeeDepartment = newEmployeeDepartment;
        }

        /// <summary>
        /// Выводит информацию о сотруднике, включая его базовую информацию (ID, имя, фамилия, дата рождения, пол, электронная почта, телефон), а также его должность и табельный номер.
        /// </summary>
        /// <remarks>
        /// Метод вызывает базовый метод Print() для вывода базовой информации о сотруднике, затем добавляет информацию о должности и табельном номере.
        /// </remarks>
        public override void Print()
        {
            base.Print();
            if (EmployeePosition != null && EmployeePosition != "") Console.WriteLine($"Табельный номер {TabNumber}, Должность: {EmployeePosition}");
        }
    }
}