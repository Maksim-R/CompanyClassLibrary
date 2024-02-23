using CompanyClassLibrary;
using CompanyClassLibrary.Class;
using System;

//Person p1 = new Person();
//p1.FirstName = "Test";
//p1.LastName = "Test2";
//p1.EmployeeBirthData("2022/10/24");
//p1.Gender = "Мужской";
//p1.Email = "Test@test.com";
//p1.Phone = "1234567890";
//p1.Print();
//Console.WriteLine("---------------------------------------------");
//Employee p2 = new Employee();
//p2.FirstName = "Test2";
//p2.LastName = "Василий";
//p2.Email = "";
//p2.EmployeePosition = "Координатор";
//p2.Print();
//Console.WriteLine("---------------------------------------------");

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

Employee admin1 = new Employee();
admin1.FirstName = "Иван";
admin1.LastName = "Фролов";
admin1.Gender = "Мужской";
admin1.BirthDate = DateOnly.Parse("11 11.1999");
admin1.Email = "qwe@test.ru";
admin1.Phone = "79511234567";
company.Departments[0].Employees?.Add(admin1);

Employee it1 = new Employee();
it1.FirstName = "Ирина";
it1.LastName = "Фурьева";
it1.Gender = "Женский";
it1.BirthDate = DateOnly.Parse("11 11.1983");
it1.Email = "IF@test.ru";
it1.Phone = "79511234567";
company.Departments[1].Employees?.Add(it1);

Employee leg1 = new Employee();
leg1.FirstName = "Ирина";
leg1.LastName = "Фурьева";
leg1.Gender = "Женский";
leg1.BirthDate = DateOnly.Parse("11 11.1983");
leg1.Email = "IF@test.ru";
leg1.Phone = "79511234567";
company.Departments[2].Employees?.Add(leg1);

Employee acc1 = new Employee();
acc1.FirstName = "Светлана";
acc1.LastName = "Антипова";
acc1.Gender = "Женский";
acc1.BirthDate = DateOnly.Parse("11 11.1969");
acc1.Email = "SA@test.ru";
acc1.Phone = "79511234567";
company.Departments[3].Employees?.Add(acc1);

Employee oi1 = new Employee();
oi1.FirstName = "Лариса";
oi1.LastName = "Лобода";
oi1.Gender = "Женский";
oi1.BirthDate = DateOnly.Parse("11 11.1965");
oi1.Email = "LA@test.ru";
oi1.Phone = "79511234567";
company.Departments[4].Employees?.Add(oi1);


company.PrintDepartmentsInfo();