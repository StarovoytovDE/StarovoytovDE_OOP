using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace LB1_Starovoytov
{
    /// <summary>
    /// Главный класс программы, содержащий точку входа.
    /// </summary>
    internal class Program
    {

        //TODO: extract ?
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
            if (!Person.IsValidName(input))
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

        //TODO: remove? +?
        /// <summary>
        /// Количество попыток для ввода данных.
        /// </summary>
        private const int haveAttempts = 5;

        /// <summary>
        /// Создает объект Person, запрашивая данные у пользователя через консоль.
        /// </summary>
        /// <returns>Объект Person, созданный на основе введенных данных.</returns>
        public static Person ReadPersonFromConsole()
        {
            string firstName = ReadWithValidation("Введите имя: ", haveAttempts, input =>
                ValidateName(input, "Имя"));

            string lastName = ReadWithValidation("Введите фамилию: ", haveAttempts, input =>
                ValidateName(input, "Фамилия"));

            string ageInput = ReadWithValidation("Введите возраст: ", haveAttempts, input =>
                ValidateAge(input, Person.MinAge, Person.MaxAge));

            int age = int.Parse(ageInput);

            string genderInput = ReadWithValidation("Введите пол (Male/Female): ", haveAttempts, input =>
                ValidateGender(input));

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
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        static void Main(string[] args)
        {
            // a. Создаем два списка персон

            Person person1 = new Person("Иванов", "Иванов", 30, Gender.Male);
            Person person2 = new Person("Мария", "Васильева", 25, Gender.Female);
            Person person3 = new Person("Петр", "Стрельцов", 35, Gender.Male);
            Person person4 = new Person("Андрей", "Алексеевич", 50, Gender.Male);
            Person person5 = new Person("Ольга", "Андреевна", 55, Gender.Female);
            Person person6 = new Person("Светлана", "Игоревна", 60, Gender.Female);

            PersonList firstList = new PersonList();

            PersonList secondList = new PersonList();

            firstList.AddPerson(person1);
            firstList.AddPerson(person2);
            firstList.AddPerson(person3);
            secondList.AddPerson(person4);
            secondList.AddPerson(person5);
            secondList.AddPerson(person6);

           // b. Выводим содержимое каждого списка

            Console.WriteLine("\nПервый список:");
            Person.PrintPersonList(firstList);
            
            Console.WriteLine("\nВторой список:");
            Person.PrintPersonList(secondList);

            Console.ReadKey(); // Ожидание нажатия клавиши

            // c. Добавляем нового человека в первый список
            firstList.AddPerson(new Person("Анна", "Владимирована", 20, Gender.Female));

            Console.WriteLine("\nПосле добавления Анны в первый список:");
            Person.PrintPersonList(firstList);

            Console.ReadKey(); // Ожидание нажатия клавиши

            // d. Копируем второго человека из первого списка во второй
            // Копируем Мария
            secondList.AddPerson(firstList.People[1]); 
            Console.WriteLine("\nПосле копирования Марии во второй список:");
            
            Console.WriteLine("Первый список:");
            Person.PrintPersonList(firstList);
            
            Console.WriteLine("\nВторой список:");
            Person.PrintPersonList(secondList);

            Console.ReadKey(); // Ожидание нажатия клавиши

            // e. Удаляем второго человека из первого списка
            // Удаляем Мария
            firstList.RemovePersonByIndex(1); 
            Console.WriteLine("\nПосле удаления Марии из первого списка:");

            Console.WriteLine("Первый список:");
            Person.PrintPersonList(firstList);

            Console.WriteLine("\nВторой список:");
            Person.PrintPersonList(secondList);

            Console.ReadKey(); // Ожидание нажатия клавиши

            // f. Очищаем второй список
            secondList.ClearList();
            Console.WriteLine("\nПосле очистки второго списка:");

            Console.WriteLine("Первый список:");
            Person.PrintPersonList(firstList);

            Console.WriteLine("\nВторой список очищен.");
            Console.ReadKey(); // Ожидание нажатия клавиши

            // Задание 4: Ввод данных с консоли
            Console.WriteLine("Добавьте нового человека во второй список из консоли:");
            try
            {
                var consolePerson = ReadPersonFromConsole();
                secondList.AddPerson(consolePerson);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка ввода данных: " + e.Message);
            }

            // Вывод содержимого второго списка после добавления пользователя
            Console.WriteLine("\nВторой список после добавления из консоли:");
            Person.PrintPersonList(secondList);

            // Задание 5: Добавление случайного человека

            Console.WriteLine("\nДобавляем случайного человека во второй список.");
            secondList.AddPerson(Person.GetRandomPerson());

            // Вывод содержимого второго списка после добавления случайного человека
            Console.WriteLine("\nВторой список после добавления случайного человека:");
            Person.PrintPersonList(secondList);

            Console.WriteLine("\nДля выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
