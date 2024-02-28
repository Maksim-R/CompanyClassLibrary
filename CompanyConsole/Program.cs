using CompanyClassLibrary;
using CompanyClassLibrary.Class;
using System;

Company company = new Company("My Company", "Делаем все");
company.Print();

string[] departmentNames = new string[] { "Administration", "IT", "Legal", "Accounting", "OI" };
company.AddDepartments(departmentNames);


company.AddEmployeeToDepartment(new Employee(1, "Administration", "Иван", "Фролов", "12/12/2000", "Мужской", "qwe@test.ru", "79511234567", "Руководитель"));

//company.Departments[0].Employees?.Add(new Employee("Administration", "Диана", "Шелестова", "11.11.1999", "Женский", "asd@test.ru", "79511234567", "Заместитель руководителя по общественным вопросам"));
//company.Departments[1].Employees?.Add(new Employee("IT", "Ирина", "Фурьева", "Женский", "11.11.1990", "IF@test.ru", "79511234567", "Разработчик"));
//company.Departments[2].Employees?.Add(new Employee("Legal", "Анна", "Самойлова", "Женский", "11.11.1983", "IF@test.ru", "79511234567", "Старший юрист"));
//company.Departments[3].Employees?.Add(new Employee("Accounting", "Светлана", "Антипова", "Женский", "11.11.1969", "SA@test.ru", "79511234567", "Главный бухгалтер"));
//company.Departments[4].Employees?.Add(new Employee("OI", "Лариса", "Лобода", "Женский", "11.11.1900", "LA@test.ru", "79511234567", "Старший специалист"));

company.PrintDepartmentsInfo();
company.RemoveEmployeeFromDepartment(company.GetEmployee(1));
company.PrintDepartmentsInfo();

int totalEmployees = company.GetTotalEmployeesCount();
Console.WriteLine($"Общее количество сотрудников в компании: {totalEmployees}");

Department department;
if (company != null)
{
    var temp = company.Departments.FirstOrDefault(department => department.DepartmentName == "IT");
    if (temp != null) department = temp;
}
else { department = new Department(); }


