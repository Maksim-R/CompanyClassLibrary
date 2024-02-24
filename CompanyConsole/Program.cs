using CompanyClassLibrary;
using CompanyClassLibrary.Class;
using System;

Company company = new Company("My Company", "Делаем все");
company.Print();

Department administration = new Department("Administration");
company.Departments.Add(administration);

Department it = new Department("IT");
company.Departments.Add(it);

Department legal = new Department("Legal");
company.Departments.Add(legal);

Department accounting = new Department("Accounting");
company.Departments.Add(accounting);

Department oi = new Department("OI");
company.Departments.Add(oi);

company.Departments[0].Employees?.Add(new Employee("Иван", "Фролов", "12/12/2000", "Мужской", "qwe@test.ru", "79511234567", "Руководитель"));
company.Departments[0].Employees?.Add(new Employee("Диана", "Шелестова", "11.11.1999", "Женский", "asd@test.ru", "79511234567", "Заместитель руководителя по общественным вопросам"));
company.Departments[1].Employees?.Add(new Employee("Ирина", "Фурьева", "Женский", "11.11.1990", "IF@test.ru", "79511234567", "Разработчик"));
company.Departments[2].Employees?.Add(new Employee("Ирина", "Фурьева", "Женский", "11.11.1983", "IF@test.ru", "79511234567", "Старший юрист"));
company.Departments[3].Employees?.Add(new Employee("Светлана", "Антипова", "Женский", "11.11.1969", "SA@test.ru", "79511234567", "Главный бухгалтер"));
company.Departments[4].Employees?.Add(new Employee("Лариса", "Лобода", "Женский", "11.11.1900", "LA@test.ru", "79511234567", "Старший специалист"));

company.PrintDepartmentsInfo();

int totalEmployees = company.GetTotalEmployeesCount();
Console.WriteLine($"Общее количество сотрудников в компании: {totalEmployees}");