using System;
using static LB1_Starovoytov.Classes;

namespace LB1_Starovoytov
{
    internal class Program
    {
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

            //TODO: duplication
            Console.WriteLine("\nВторой список:");
            foreach (var people in firstList.people)
            {
                Console.WriteLine(people.FirstName + " " + people.LastName + " " + people.Age + " " + people.Sex);
            }

            //TODO: duplication
            Console.WriteLine("\nВторой список:");
            foreach (var people in secondList.people)
            {
                Console.WriteLine(people.FirstName + " " + people.LastName + " " + people.Age + " " + people.Sex);
            }

            Console.ReadKey(); // Ожидание нажатия клавиши

            // c. Добавляем нового человека в первый список
            firstList.AddPerson(new Person("Анна", "Владимирована", 20, Gender.Female));
            //TODO: duplication
            Console.WriteLine("\nПосле добавления Анны в первый список:");
            foreach (var person in firstList.people)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Age + " " + person.Sex);
            }

            Console.ReadKey(); // Ожидание нажатия клавиши

            // d. Копируем второго человека из первого списка во второй
            secondList.AddPerson(firstList.people[1]); // Копируем Мария
            Console.WriteLine("\nПосле копирования Марии во второй список:");
            //TODO: duplication
            Console.WriteLine("Первый список:");
            foreach (var person in firstList.people)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Age + " " + person.Sex);
            }
            //TODO: duplication
            Console.WriteLine("\nВторой список:");
            foreach (var person in secondList.people)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Age + " " + person.Sex);
            }

            Console.ReadKey(); // Ожидание нажатия клавиши

            // e. Удаляем второго человека из первого списка
            firstList.RemovePersonByIndex(1); // Удаляем Мария
            Console.WriteLine("\nПосле удаления Марии из первого списка:");
            //TODO: duplication
            Console.WriteLine("Первый список:");
            foreach (var person in firstList.people)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Age + " " + person.Sex);
            }
            //TODO: duplication
            Console.WriteLine("\nВторой список:");
            foreach (var person in secondList.people)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Age + " " + person.Sex);
            }

            Console.ReadKey(); // Ожидание нажатия клавиши

            // f. Очищаем второй список
            secondList.ClearList();
            Console.WriteLine("\nПосле очистки второго списка:");
            //TODO: duplication
            Console.WriteLine("Первый список:");
            foreach (var person in firstList.people)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Age + " " + person.Sex);
            }

            Console.WriteLine("\nВторой список очищен.");
            Console.ReadKey(); // Ожидание нажатия клавиши

            // Задание 4: Ввод данных с консоли
            Console.WriteLine("Добавьте нового человека во второй список из консоли:");
            try
            {
                var consolePerson = Classes.Person.ReadPersonFromConsole();
                secondList.AddPerson(consolePerson);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка ввода данных: " + e.Message);
            }

            // Вывод содержимого второго списка после добавления пользователя
            Console.WriteLine("\nВторой список после добавления из консоли:");
            foreach (var person in secondList.people)
            {
                Console.WriteLine(person.DisplayInfo());
            }

            // Задание 5: Добавление случайного человека

            Console.WriteLine("\nДобавляем случайного человека во второй список:");
            secondList.AddPerson(Classes.Person.GetRandomPerson());

            // Вывод содержимого второго списка после добавления случайного человека
            Console.WriteLine("\nВторой список после добавления случайного человека:");
            foreach (var person in secondList.people)
            {
                Console.WriteLine(person.DisplayInfo());
            }

            Console.WriteLine("\nДля выхода нажмите любую клавишу...");
            Console.ReadKey();

        }
    }
}
