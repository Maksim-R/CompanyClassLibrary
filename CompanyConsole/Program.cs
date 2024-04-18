using CompanyClassLibrary;
using CompanyClassLibrary.Class;
using System;
using System.Runtime.Versioning;
using System.Threading.Channels;

Company company = new Company("My Company", "Делаем все");

string[] departmentName = new string[] { "Administration", "IT", "Legal", "Accounting", "OI" };
company.AddDepartments(departmentName);

const string path = @"C:\Users\Maksi\source\repos\Persons_Project\CompanyConsole\DB\Employees.txt";
FileInfo fileInfo = new FileInfo(path);
if (fileInfo.Exists)
{
    List<string> result = File.ReadAllLines(path).ToList();
    foreach (string line in result)
    {
        string[] temp = line.Split(',');
        for (int i = 0; i < temp.Length; i++) temp[i] = temp[i].Trim();
        company.AddEmployeeToDepartment(new Employee(Convert.ToInt32(temp[0]), temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7], temp[8]));
    }
}
else
{
    Console.WriteLine("Путь к файлу не найден!");
    Console.WriteLine("Для выхода нажмите любую клавишу...");
    Console.ReadKey();
}


    //company.AddEmployeeToDepartment(new Employee(company.GetMaxTabNumber() + 1, "Administration", "Иван", "Фролов", "12/12/2000", "Мужской", "qwe@test.ru", "79511234567", "Руководитель"));
    //company.AddEmployeeToDepartment(new Employee(company.GetMaxTabNumber() + 1, "Administration", "Диана", "Шелестова", "11.11.1999", "Женский", "asd@test.ru", "79511234567", "Заместитель руководителя по общественным вопросам"));
    //company.AddEmployeeToDepartment(new Employee(company.GetMaxTabNumber() + 1, "IT", "Ирина", "Фурьева", "Женский", "11.11.1990", "IF@test.ru", "79511234567", "Разработчик"));
    //company.AddEmployeeToDepartment(new Employee(company.GetMaxTabNumber() + 1, "Legal", "Анна", "Самойлова", "Женский", "11.11.1983", "IF@test.ru", "79511234567", "Старший юрист"));
    //company.AddEmployeeToDepartment(new Employee(company.GetMaxTabNumber() + 1, "Accounting", "Светлана", "Антипова", "Женский", "11.11.1969", "SA@test.ru", "79511234567", "Главный бухгалтер"));
    //company.AddEmployeeToDepartment(new Employee(company.GetMaxTabNumber() + 1, "OI", "Лариса", "Лобода", "Женский", "11.11.1900", "LA@test.ru", "79511234567", "Старший специалист"));

    //int totalEmployees = company.GetTotalEmployeesCount();
    //Console.WriteLine($"Общее количество сотрудников в компании: {totalEmployees}");

    //Employee tempEmployee = company.GetEmployee(9);

    //company.PrintContainsEmployee(tempEmployee);

    //Console.ReadKey();


    //string hello = "Добро пожаловать в пиложение компании ";
    //Console.WriteLine(hello);
    //Console.WriteLine("Ввести число с клавиатуры: ");


    string? s;
do
{
    Console.Clear();
    Console.WriteLine("Меню:");
    Console.WriteLine("1 - Добавить сотрудника");
    Console.WriteLine("2 - Переместить сотрудника в другой отдел");
    Console.WriteLine("3 - Удалить сотрудника");
    Console.WriteLine("4 - Отобразить инфомацию о компании");
    Console.WriteLine("5 - Отобразить максимальный табельный номер ");
    Console.WriteLine("6 - Справочник отделов");
    Console.WriteLine("'q' - ВЫХОД из программы");
    Console.WriteLine("---------------------------");
    Console.WriteLine("Введите число: ");
    
    s = Console.ReadLine();
    Console.WriteLine($"Вы ввели: {s}");
    int tabNumberInt = 0;


    switch (s)
    {
        /// Добавление пользователя в режиме диалога
        case "1":

            Console.WriteLine("Введите данные о сотруднике:");            
            Console.Write("Отдел: ");
            string departmentNameStr = Console.ReadLine();
            Console.Write("Имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Фамилия: ");
            string lastName = Console.ReadLine();
            Console.Write("Дата рождения (ДД.ММ.ГГГГ): ");
            string birthDateStr = Console.ReadLine();
            DateOnly birthDate = DateOnly.Parse(birthDateStr);
            Console.Write("Пол: ");
            string gender = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Телефон: ");
            string phone = Console.ReadLine();
            Console.Write("Должность: ");
            string position = Console.ReadLine();

            Employee newEmployee = new Employee(company.GetMaxTabNumber() + 1, departmentNameStr, firstName, lastName, birthDateStr, gender, email, phone, position);
            company.AddEmployeeToDepartment(newEmployee, path);
            Console.WriteLine("Сотрудник успешно добавлен.");
            Console.ReadKey();
            break;

        case "2":            
            Console.WriteLine("Введите табельный номер сотрудника: ");
            tabNumberInt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите имя нового отдела: ");
            string newDepartmentNameStr = Console.ReadLine();
            company.MovingEmployeeDepartent(tabNumberInt, newDepartmentNameStr);
            Console.ReadKey();            
            break;                  
        
        case "3":            
            int tabNumber;
            Console.WriteLine("Введите табельный номер сотрудника: ");
            tabNumber = Convert.ToInt32(Console.ReadLine());
            company.RemoveEmployeeByTabNumber(tabNumber);
            Console.ReadKey();
            break;

        case "4":
            company.PrintDepartmentsInfo();
            Console.WriteLine("***************************");
            
            
            Console.WriteLine("Для продолжения нажмите любую клавишу: ");
            Console.ReadKey();
            break;

        case "5":
            Console.WriteLine($"Максимальный табельный номер: {company.GetMaxTabNumber()}");
            Console.ReadKey();
            break;
        
        case "6":
            Console.WriteLine("Справочник отделов: ");
            Console.WriteLine("-----------------------");
            int i = 0;            
            foreach(Department department in company.Departments)
            {
                Console.WriteLine($"| {++i, -1} | {department.DepartmentName, -15} | ");                
            }
           
            Console.ReadKey();
            break;


    }
}
while (s != "q");

//string temp = Convert.ToInt32(Console.ReadLine());


//string hello;


//switch (hello)
//{
//    case "Q":
//        Console.WriteLine("Завершение программы."); 
//        break;
    //case значение2:
    //    код,выполняемый если выражение имеет значение2
    //    break;
    ////.............
    //case значениеN:
    //    код, выполняемый если выражение имеет значениеN
    //    break;
    //default:
    //    код, выполняемый если выражение не имеет ни одно из выше указанных значений
    //    break;
//}
