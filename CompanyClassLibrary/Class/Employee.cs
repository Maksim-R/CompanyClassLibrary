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

        public string? DepartmentName { get; set; } // Название отдела, к которому принадлежит сотрудник


        // Конструктор со всеми параметрами
        public Employee(string departmentName, string firstName, string lastName, string birthDate, string gender, string email, string phone, string employeePosition)
        {
            DateOnly temp;

            DateOnly.TryParse(birthDate, out temp);

            DepartmentName = departmentName;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = temp;
            Gender = gender;
            Email = email;
            Phone = phone;
            EmployeePosition = employeePosition;
        }

        public override void Print()
        {
            base.Print();
            if (EmployeePosition != null && EmployeePosition != "") Console.WriteLine($"Должность: {EmployeePosition}");
        }
    }
}