namespace CompanyClassLibrary.Class
{
    public class Person
    {
        // Инициализируем поля класса
        protected Guid Id = Guid.NewGuid();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // Метод для вывода информации о сотруднике
        public virtual void Print()
        {
            Console.WriteLine($"ID: {Id}");
            if (FirstName != null && FirstName != "") Console.WriteLine($"Имя: {FirstName}");
            if (LastName != null && LastName != "") Console.WriteLine($"Фамиля: {LastName}");
            if (BirthDate != DateOnly.Parse("01.01.0001")) Console.WriteLine($"Дата рождения: {BirthDate}");
            if (Gender != null && Gender != "") Console.WriteLine($"Пол: {Gender}");
            if (Email != null && Email != "") Console.WriteLine($"Электронная почта: {Email}");
            if (Phone != null && Phone != "") Console.WriteLine($"Телефон: {Phone}");
        }

        // Создаем метод для преобразования типа DateOnly в тип string.
        public void EmployeeBirthData(string dateString)
        {
            BirthDate = DateOnly.Parse(dateString);
        }
    }
}
