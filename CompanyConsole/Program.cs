using CompanyClassLibrary;
using CompanyClassLibrary.Class;
using System;

Person p1 = new Person();
p1.FirstName = "Test";
p1.LastName = "Test2";
p1.EmployeeBirthData("2022/12/24");
p1.Gender = "Мужской";
p1.Email = "Test@test.com";
p1.Phone = "1234567890";
p1.Print();
Console.WriteLine("---------------------------------------------");
Employee p2 = new Employee();
p2.FirstName = "Test2";
p2.LastName = "Василий";
p2.Email = "";
p2.EmployeePosition = "Координатор";
p2.Print();