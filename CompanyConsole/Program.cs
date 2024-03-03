using CompanyClassLibrary;
using CompanyClassLibrary.Class;
using System;
using System.Runtime.Versioning;

Company company = new Company("My Company", "Делаем все");
company.Print();

string[] departmentNames = new string[] { "Administration", "IT", "Legal", "Accounting", "OI" };
company.AddDepartments(departmentNames);


company.AddEmployeeToDepartment(new Employee(1, "Administration", "Иван", "Фролов", "12/12/2000", "Мужской", "qwe@test.ru", "79511234567", "Руководитель"));
company.AddEmployeeToDepartment(new Employee(2, "Administration", "Диана", "Шелестова", "11.11.1999", "Женский", "asd@test.ru", "79511234567", "Заместитель руководителя по общественным вопросам"));
company.AddEmployeeToDepartment(new Employee(3, "IT", "Ирина", "Фурьева", "Женский", "11.11.1990", "IF@test.ru", "79511234567", "Разработчик"));
company.AddEmployeeToDepartment(new Employee(4, "Legal", "Анна", "Самойлова", "Женский", "11.11.1983", "IF@test.ru", "79511234567", "Старший юрист"));
company.AddEmployeeToDepartment(new Employee(5, "Accounting", "Светлана", "Антипова", "Женский", "11.11.1969", "SA@test.ru", "79511234567", "Главный бухгалтер"));
company.AddEmployeeToDepartment(new Employee(6, "OI", "Лариса", "Лобода", "Женский", "11.11.1900", "LA@test.ru", "79511234567", "Старший специалист"));

company.PrintDepartmentsInfo();
// company.RemoveEmployeeFromDepartment(company.GetEmployee(1));
// company.PrintDepartmentsInfo();

int totalEmployees = company.GetTotalEmployeesCount();
Console.WriteLine($"Общее количество сотрудников в компании: {totalEmployees}");

Department department;
if (company != null)
{
    var temp = company.Departments.FirstOrDefault(department => department.DepartmentName == "IT");
    if (temp != null) department = temp;
}
else { department = new Department(); }
