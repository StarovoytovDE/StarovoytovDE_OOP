using System;
using System.Text.RegularExpressions;

namespace LB1_Starovoytov
{
    //TODO: rename file
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

        //TODO: RSDN
        /// <summary>
        /// Минимальный допустимый возраст.
        /// </summary>
        private const int minAge = 0;

        //TODO: RSDN
        /// <summary>
        /// Максимальный допустимый возраст.
        /// </summary>
        private const int maxAge = 125;

        //TODO: remove?
        /// <summary>
        /// Количество попыток для ввода данных.
        /// </summary>
        private const int haveAttempts = 5;

        /// <summary>
        /// Конструктор для создания объекта Person.
        /// </summary>
        /// <param name="firstName">Имя человека.</param>
        /// <param name="lastName">Фамилия человека.</param>
        /// <param name="age">Возраст человека.</param>
        /// <param name="sex">Пол человека.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если имя, фамилия или возраст не соответствуют требованиям.</exception>
        public Person(string firstName, string lastName, int age, Gender sex)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Имя и фамилия не могут быть пустыми!");
            }           

            // Проверка ввода имен и фамилий (русские или английские буквы + двойные имена/фамилии)
            if (!IsValidName(firstName) || !IsValidName(lastName))
            {
                //TODO: RSDN
                throw new ArgumentException("Имя и фамилия должны содержать только русские или английские буквы, пробелы и дефисы!");
            }

            // Автоматическая обработка регистра (первая буква большая, остальные строчные)
            FirstName = CapitalizeName(firstName);
            LastName = CapitalizeName(lastName);

            // Проверка правильности возраста (не отрицательный)
            if ((age < minAge) || (age > maxAge))
            {
                //TODO: RSDN
                throw new ArgumentException($"Возраст не должен быть отрицательным числом и не превышать {maxAge} лет!");
            }

            Age = age;
            Sex = sex;
        }

        /// <summary>
        /// Метод для проверки соответствия имени или фамилии допустимым символам.
        /// </summary>
        /// <param name="name">Имя или фамилия для проверки.</param>
        /// <returns>True, если имя или фамилия соответствуют требованиям, иначе False.</returns>
        private static bool IsValidName(string name)
        {
            // Регулярное выражение: поддерживает буквы русского и латинского алфавита, пробелы и дефисы
            return System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Zа-яА-ЯёЁ\s-]+$");
        }

        /// <summary>
        /// Приводит имя или фамилию к правильному регистру (первая буква заглавная, остальные строчные).
        /// Сохраняет дефисы между словами.
        /// </summary>
        /// <param name="name">Имя или фамилия для обработки.</param>
        /// <returns>Имя или фамилия в правильном регистре.</returns>
        private string CapitalizeName(string name)
        {
            // Регулярное выражение для поиска слов, разделённых пробелами или дефисами
            return Regex.Replace(name.ToLower(), @"\b(\w)", m => m.Value.ToUpper());
        }

        //TODO: extract
        /// <summary>
        /// Вложенный класс, содержащий методы для валидации данных.
        /// </summary>
        public static class Validator
        {
            /// <summary>
            /// Проверяет имя или фамилию на соответствие требованиям.
            /// </summary>
            /// <param name="input">Входная строка для проверки.</param>
            /// <param name="fieldName">Название поля (например, "Имя" или "Фамилия").</param>
            /// <returns>Сообщение об ошибке, если проверка не пройдена, иначе null.</returns>
            public static string ValidateName(string input, string fieldName)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return $"{fieldName} не может быть пустым!";
                }
                if (!IsValidName(input))
                {
                    return $"{fieldName} должна содержать только русские или английские буквы, пробелы и дефисы!";
                }
                return null;
            }

            /// <summary>
            /// Проверяет возраст на соответствие допустимому диапазону.
            /// </summary>
            /// <param name="input">Входная строка для проверки.</param>
            /// <param name="minAge">Минимальный допустимый возраст.</param>
            /// <param name="maxAge">Максимальный допустимый возраст.</param>
            /// <returns>Сообщение об ошибке, если проверка не пройдена, иначе null.</returns>
            public static string ValidateAge(string input, int minAge, int maxAge)
            {
                if (!int.TryParse(input, out int age) || age < minAge || age > maxAge)
                {
                    return $"Возраст должен быть числом от {minAge} до {maxAge} лет!";
                }
                return null;
            }

            /// <summary>
            /// Проверяет, соответствует ли введенное значение допустимым значениям пола.
            /// </summary>
            /// <param name="input">Входная строка для проверки.</param>
            /// <returns>Сообщение об ошибке, если проверка не пройдена, иначе null.</returns>
            public static string ValidateGender(string input)
            {
                if (!Enum.TryParse(input, true, out Gender _))
                {
                    return "Пол должен быть 'Male' или 'Female'!";
                }
                return null;
            }
        }

        /// <summary>
        /// Создает объект Person, запрашивая данные у пользователя через консоль.
        /// </summary>
        /// <returns>Объект Person, созданный на основе введенных данных.</returns>
        public static Person ReadPersonFromConsole()
        {
            string firstName = ReadWithValidation("Введите имя: ", haveAttempts, input =>
                Validator.ValidateName(input, "Имя"));

            string lastName = ReadWithValidation("Введите фамилию: ", haveAttempts, input =>
                Validator.ValidateName(input, "Фамилия"));

            string ageInput = ReadWithValidation("Введите возраст: ", haveAttempts, input =>
                Validator.ValidateAge(input, minAge, maxAge));

            int age = int.Parse(ageInput);

            string genderInput = ReadWithValidation("Введите пол (Male/Female): ", haveAttempts, input =>
                Validator.ValidateGender(input));

            Gender sex = (Gender)Enum.Parse(typeof(Gender), genderInput, true);

            return new Person(firstName, lastName, age, sex);
        }

        /// <summary>
        /// Обобщённый метод для чтения данных с консоли с повторными попытками и валидацией.
        /// </summary>
        /// <param name="prompt">Сообщение, которое отображается пользователю.</param>
        /// <param name="maxAttempts">Максимальное количество попыток ввода.</param>
        /// <param name="validate">Функция для валидации введенных данных.</param>
        /// <returns>Введенные данные, прошедшие валидацию.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если исчерпаны все попытки ввода.</exception>
        private static string ReadWithValidation(string prompt, int maxAttempts, Func<string, string> validate)
        {
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                string errorMessage = validate(input);
                if (errorMessage == null)
                {
                    return input;
                }

                Console.WriteLine($"Ошибка: {errorMessage}");
                attempts++;
                Console.WriteLine($"Осталось попыток: {maxAttempts - attempts}\n");
            }
            throw new ArgumentException("Исчерпаны все попытки ввода.");
        }

        /// <summary>
        /// Создание случайного человека.
        /// </summary>
        /// <returns>Объект Person со случайными данными.</returns>
        public static Person GetRandomPerson()
        {
            string[] randomFirstNames = { "Иван", "Мария", "Петр", "Андрей", "Ольга", "Светлана" };
            string[] randomLastNames = { "Иванов", "Сергеев", "Стрельцов", "Алексеев", "Андреева", "Игорева" };
            Random random = new Random();

            string firstName = randomFirstNames[random.Next(randomFirstNames.Length)];
            string lastName = randomLastNames[random.Next(randomLastNames.Length)];
            // Возраст случайно от minAge до maxAge
            int age = random.Next(minAge, maxAge);
            // Пол случайно Male или Female
            Gender sex = (Gender)random.Next(0, 2); 

            return new Person(firstName, lastName, age, sex);
        }

        /// <summary>
        /// Возвращает строку с информацией о человеке.
        /// </summary>
        /// <returns>Строка, содержащая имя, фамилию, возраст и пол человека.</returns>
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
