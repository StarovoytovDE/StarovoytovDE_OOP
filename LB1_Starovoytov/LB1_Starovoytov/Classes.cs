using System;

namespace LB1_Starovoytov
{
    //TODO: XML
    internal partial class Classes
    {
        //TODO: XML
        public class Person
        {
            // Свойства класса
            public string FirstName { get; }
            public string LastName { get; }
            public int Age { get; }
            public Gender Sex { get; }

            //TODO: const
            private static readonly int minAge = 0;
            private static readonly int maxAge = 125;

            // Конструктор класса
            public Person(string firstName, string lastName, int age, Gender sex)
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    throw new ArgumentException("Имя и фамилия не могут быть пустыми!");
                }

                // Проверка правильности возраста (не отрицательный)
                if ((age < minAge) || (age > maxAge))
                {
                    throw new ArgumentException($"Возраст не должен быть отрицательным числом и не превышать {maxAge} лет!");
                }

                // Проверка ввода имен и фамилий (русские или английские буквы + двойные имена/фамилии)
                if (!IsValidName(firstName) || !IsValidName(lastName))
                {
                    throw new ArgumentException("Имя и фамилия должны содержать только русские или английские буквы, пробелы и дефисы!");
                }

                // Автоматическая обработка регистра (первая буква большая, остальные строчные)
                FirstName = CapitalizeName(firstName);
                LastName = CapitalizeName(lastName);

                Age = age;
                Sex = sex;
            }

            // Метод для проверки имени или фамилии
            private static bool IsValidName(string name)
            {
                // Регулярное выражение: поддерживает буквы русского и латинского алфавита, пробелы и дефисы
                return System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Zа-яА-ЯёЁ\s-]+$");
            }

            // Метод для приведения имени/фамилии в нужный регистр
            private string CapitalizeName(string name)
            {
                // Разделяем по пробелам/дефисам и обрабатываем каждую часть
                var parts = name.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();
                }
                return string.Join(" ", parts); // Собираем имя обратно
            }

            private static readonly int HaveAttempts = 5;

            //TODO: extract
            // Метод для создания объекта `Person` с проверками и повторными попытками
            public static Person ReadPersonFromConsole()
            {
                string firstName = ReadWithValidation("Введите имя: ", HaveAttempts, input =>
                {
                    if (string.IsNullOrWhiteSpace(input))
                    { 
                        return "Имя не может быть пустым!";
                    }
                    if (!IsValidName(input))
                    {
                        return "Имя должно содержать только русские или английские буквы, пробелы и дефисы!";
                    }
                    return null;
                });

                string lastName = ReadWithValidation("Введите фамилию: ", HaveAttempts, input =>
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        return "Фамилия не может быть пустой!";
                    }
                    if (!IsValidName(input))
                    {
                        return "Фамилия должна содержать только русские или английские буквы, пробелы и дефисы!";
                    }
                     return null;
                });

                string ageInput = ReadWithValidation("Введите возраст: ", HaveAttempts, input =>
                {
                    if (!int.TryParse(input, out int ageI) || (ageI < minAge) || (ageI > maxAge)) 
                    {
                        return $"Возраст не должен быть отрицательным числом и не превышать {maxAge} лет!";
                    }
                    return null;
                });

                int age = int.Parse(ageInput);

                string genderInput = ReadWithValidation("Введите пол (Male/Female): ", HaveAttempts, input =>
                {
                    if (!Enum.TryParse(input, true, out Gender _))
                    {
                        return "Пол должен быть 'Male' или 'Female'!";
                    }
                     return null;
                });

                Gender sex = (Gender)Enum.Parse(typeof(Gender), genderInput, true);

                return new Person(firstName, lastName, age, sex);
            }

            // Обобщённый метод для чтения данных с повторными попытками
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

            //Метод для создание случайного человека
            public static Person GetRandomPerson()
            {
                string[] randomFirstNames = { "Иван", "Мария", "Петр", "Андрей", "Ольга", "Светлана" };
                string[] randomLastNames = { "Иванов", "Сергеев", "Стрельцов", "Алексеев", "Андреева", "Игорева" };
                Random random = new Random();

                string firstName = randomFirstNames[random.Next(randomFirstNames.Length)];
                string lastName = randomLastNames[random.Next(randomLastNames.Length)];
                int age = random.Next(minAge, maxAge); // Возраст случайно от minAge до maxAge
                Gender sex = (Gender)random.Next(0, 2); // Пол случайно Male или Female

                return new Person(firstName, lastName, age, sex);
            }

            //TODO: rename +
            // Метод для отображения информации о человеке
            public string GetInfo()
            {
                return $"{FirstName} {LastName}, Возраст: {Age}, Пол: {Sex}";
            }
        }
    }
}
