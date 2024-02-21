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

Department legal = new Department("Юридический");
company.Departments.Add(legal);

Department accounting = new Department("Бухгалтерия");
company.Departments.Add(accounting);

Department oi = new Department("Охрана труда");
company.Departments.Add(oi);

Employee e1 = new Employee();
e1.FirstName = "Ivan";
e1.Email = "qwe@qwe.ru";
company.Departments[0].Employees?.Add(e1);

company.PrintDepartmentsInfo();