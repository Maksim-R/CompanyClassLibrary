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

        public override void Print()
        {
            base.Print();
            if (EmployeePosition != null && EmployeePosition != "") Console.WriteLine($"Должность: {EmployeePosition}");
        }
    }
}