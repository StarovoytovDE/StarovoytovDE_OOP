using System;
using System.Text;
using System.Text.RegularExpressions;

namespace LB1_Starovoytov
{
    /// <summary>
    /// Класс, представляющий человека (Person).
    /// Содержит информацию о имени, фамилии, возрасте и поле.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName => FirstName + " " + LastName;

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime DateOfBirth { get; protected set; }

        /// <summary>
        /// Возраст, рассчитанный на основе даты рождения.
        /// </summary>
        public int Age => CalculateAge(DateTime.Today, DateOfBirth);

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Sex { get; }

        /// <summary>
        /// Минимальный допустимый возраст.
        /// </summary>
        public const int MinAge = 0;

        /// <summary>
        /// Максимальный допустимый возраст.
        /// </summary>
        public const int MaxAge = 125;

        /// <summary>
        /// Возраст, с которого человек считается совершеннолетним.
        /// </summary>
        public const int AdultAge = 18;

        /// <summary>
        /// Отображаемое название типа человека (Он/Она).
        /// </summary>
        public abstract string PersonType { get; }

        /// <summary>
        /// Возвращает подробную информацию об объекте.
        /// </summary>
        public abstract string GetInformation();

        /// <summary>
        /// Конструктор для создания объекта Person.
        /// </summary>
        /// <param name="firstName">Имя человека.</param>
        /// <param name="lastName">Фамилия человека.</param>
        /// <param name="dateOfBirth">Дата рождения человека.</param>
        /// <param name="sex">Пол человека.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если имя, 
        /// фамилия или возраст не соответствуют требованиям.</exception>
        public PersonBase(string firstName, string lastName, DateTime dateOfBirth, Gender sex)
        {
            if (string.IsNullOrWhiteSpace(firstName)
                || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Имя и фамилия не могут " +
                    "быть пустыми!");
            }

            // Проверка ввода имен и фамилий (русские или английские буквы +
            // двойные имена/фамилии)
            if (!IsValidName(firstName) || !IsValidName(lastName))
            {
                throw new ArgumentException("Имя и фамилия должны содержать " +
                    "только русские или английские буквы, пробелы и дефисы!");
            }

            // Автоматическая обработка регистра (первая буква большая,
            // остальные строчные)
            FirstName = CapitalizeName(firstName);
            LastName = CapitalizeName(lastName);

            // Проверка правильности возраста (не отрицательный)
            if ((Age < MinAge) || (Age > MaxAge))
            {
                throw new ArgumentException($"Возраст не должен быть " +
                    $"отрицательным числом и не превышать {MaxAge} лет!");
            }

            DateOfBirth = ValidateBirthDate(dateOfBirth);
            ValidateAgeRange(Age);
            Sex = sex;
        }

        /// <summary>
        /// Метод для проверки соответствия имени или фамилии 
        /// допустимым символам.
        /// </summary>
        /// <param name="name">Имя или фамилия для проверки.</param>
        /// <returns>True, если имя или фамилия соответствуют требованиям, 
        /// иначе False.</returns>
        public static bool IsValidName(string name)
        {
            // Регулярное выражение: поддерживает буквы русского и
            // латинского алфавита, пробелы и дефисы
            return System.Text.RegularExpressions.Regex.IsMatch(name, 
                @"^[a-zA-Zа-яА-ЯёЁ\s-]+$");
        }

        /// <summary>
        /// Приводит имя или фамилию к правильному регистру 
        /// (первая буква заглавная, остальные строчные).
        /// Сохраняет дефисы между словами.
        /// </summary>
        /// <param name="name">Имя или фамилия для обработки.</param>
        /// <returns>Имя или фамилия в правильном регистре.</returns>
        private string CapitalizeName(string name)
        {
            // Регулярное выражение для поиска слов, разделённых пробелами
            // или дефисами
            return Regex.Replace(name.ToLower(), @"\b(\w)",
                m => m.Value.ToUpper());
        }

        /// <summary>
        /// Вычисляет возраст в годах по дате рождения.
        /// </summary>
        /// <param name="today">Текущая дата.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <returns>Возраст.</returns>
        protected static int CalculateAge(DateTime today, DateTime birthDate)
        {
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// Рассчитывает дату рождения на основе возраста.
        /// </summary>
        /// <param name="age">Возраст в годах.</param>
        /// <returns>Дата рождения.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возраст выходит за допустимые пределы.
        /// </exception>
        protected static DateTime BuildBirthDateFromAge(int age)
        {
            ValidateAgeRange(age);
            DateTime today = DateTime.Today;
            DateTime birthDate = today.AddYears(-age);
            if (birthDate > today)
            {
                birthDate = birthDate.AddDays(-1);
            }

            return birthDate;
        }

        /// <summary>
        /// Валидация даты рождения.
        /// </summary>
        /// <param name="dateOfBirth">Дата рождения.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Проверка реальности
        /// даты рождения.</exception>
        private static DateTime ValidateBirthDate(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            if (dateOfBirth.Date > today)
            {
                throw new ArgumentOutOfRangeException(nameof(dateOfBirth),
                    "Дата рождения не может находиться в будущем.");
            }

            return dateOfBirth.Date;
        }

        /// <summary>
        ///Валидация возраста. 
        /// </summary>
        /// <param name="age"></param>
        /// <exception cref="ArgumentOutOfRangeException">Проверка на реалистичность.</exception>
        protected static void ValidateAgeRange(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new ArgumentOutOfRangeException(nameof(age),
                    "Возраст должен быть в пределах от 0 до 125 лет.");
            }
        }

        /// <summary>
        /// Возвращает краткую сводку по человеку.
        /// </summary>
        /// <returns>Строка с базовой информацией.</returns>
        public virtual string GetShortDescription()
        {
            return PersonType + ": " + FullName + ", возраст: " + Age +
                ", пол: " + Sex + ".";
        }

        /// <summary>
        /// Возвращает строку с основной информацией о человеке.
        /// </summary>
        /// <returns>Строка для повторного использования в потомках.</returns>
        protected string BuildBaseInformation()
        {
            var builder = new StringBuilder();
            builder.AppendLine(PersonType + ": " + FullName);
            builder.AppendLine("Пол: " + Sex);
            builder.AppendLine("Возраст: " + Age);
            builder.Append("Дата рождения: " + DateOfBirth.ToString("d"));
            return builder.ToString();
        }

        /// <summary>
        /// Выводит содержимое списка персон на консоль.
        /// </summary>
        /// <param name="personList">Список персон для вывода.</param>
        public static void PrintPersonList(PersonList personList)
        {
            foreach (var person in personList.People)
            {
                Console.WriteLine(person.GetInfo());
            }
        }
    }
}
