using System;
using System.Text.RegularExpressions;

namespace LB1_Starovoytov
{
    /// <summary>
    /// Класс, представляющий человека (Person).
    /// Содержит информацию о имени, фамилии, возрасте и поле.
    /// </summary>
    public class Person
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
        /// Возраст.
        /// </summary>
        public int Age { get; }

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
        /// Конструктор для создания объекта Person.
        /// </summary>
        /// <param name="firstName">Имя человека.</param>
        /// <param name="lastName">Фамилия человека.</param>
        /// <param name="age">Возраст человека.</param>
        /// <param name="sex">Пол человека.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если имя, 
        /// фамилия или возраст не соответствуют требованиям.</exception>
        public Person(string firstName, string lastName, int age, Gender sex)
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
            if ((age < MinAge) || (age > MaxAge))
            {
                throw new ArgumentException($"Возраст не должен быть " +
                    $"отрицательным числом и не превышать {MaxAge} лет!");
            }

            Age = age;
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
        /// Создание случайного человека.
        /// </summary>
        /// <returns>Объект Person со случайными данными.</returns>
        public static Person GetRandomPerson()
        {
            string[] randomFirstNames = { "Иван", "Мария", "Петр", "Андрей",
                "Ольга", "Светлана" };
            string[] randomLastNames = { "Иванов", "Сергеев", "Стрельцов",
                "Алексеев", "Андреева", "Игорева" };
            Random random = new Random();

            string firstName =
                randomFirstNames[random.Next(randomFirstNames.Length)];
            string lastName =
                randomLastNames[random.Next(randomLastNames.Length)];
            // Возраст случайно от minAge до maxAge
            int age = random.Next(MinAge, MaxAge);
            // Пол случайно Male или Female
            Gender sex = (Gender)random.Next(0, 2);

            return new Person(firstName, lastName, age, sex);
        }

        /// <summary>
        /// Возвращает строку с информацией о человеке.
        /// </summary>
        /// <returns>Строка, содержащая имя, фамилию, возраст и пол 
        /// человека.</returns>
        public string GetInfo()
        {
            return $"{FirstName} {LastName}, Возраст: {Age}, Пол: {Sex}";
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
