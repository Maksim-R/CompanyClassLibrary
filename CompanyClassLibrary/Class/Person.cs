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

        /// <summary>
        /// Метод для вывода информации о сотруднике
        /// </summary>
        /// <remarks>
        /// Выводит информацию о сотруднике в консоль.
        /// </remarks>
        public virtual void Print()
        {
            //Console.WriteLine($"ID: {Id}");

            if (FirstName != null && FirstName != "") Console.Write($"| {FirstName} | ");
            if (LastName != null && LastName != "") Console.Write($"{LastName} | ");
            if (BirthDate != DateOnly.Parse("01.01.0001")) Console.Write($"   {BirthDate} | ");
            if (Gender != null && Gender != "") Console.Write($"{Gender} | ");
            if (Email != null && Email != "") Console.Write($"{Email} | ");
            if (Phone != null && Phone != "") Console.Write($"{Phone} | ");
        }

        /// <summary>
        /// Устанавливает дату рождения сотрудника на основе переданной строки с датой.
        /// </summary>
        /// <param name="dateString">Строка, содержащая дату рождения в формате, который может быть преобразован методом DateOnly.Parse.</param>
        /// <param name="departmentName">Название отдела, к которому относится сотрудник, для отображения в сообщении об ошибке.</param>
        /// <remarks>
        /// Метод преобразует строку с датой рождения в объект типа DateOnly и устанавливает ее как дату рождения сотрудника.
        /// В случае возникновения исключения при преобразовании строки в дату, выводит сообщение об ошибке с указанием названия отдела и данных о сотруднике.
        /// </remarks>                      
        public void SetEmployeeBirthDate(string dateString, string departmentName)
        {
            try 
            {
                BirthDate = DateOnly.Parse(dateString);
            }
            catch
            {
                Console.WriteLine($"Ошибка! Отдел {departmentName}, Имя сотрудника {FirstName}, Фамилия сотрудника {LastName}");
                Console.ReadKey();
            }
        }
    }
}
