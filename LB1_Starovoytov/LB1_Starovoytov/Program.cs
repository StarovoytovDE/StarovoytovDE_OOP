using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LB1_Starovoytov
{
    /// <summary>
    /// Главный класс программы, содержащий точку входа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Целевое количество людей, создаваемых в примерах.
        /// </summary>
        private const int PeopleCount = 7;
        
        /// <summary>
        /// Целевое количество людей, создаваемых в примерах.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        private static void Main(string[] args)
        {
            //TODO: где показан полиморфизм?+
            var people = new PersonList();

            CreateRandomPeople(people);

            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadLine();

            PrintPeopleDescriptions(people);

            DemonstrateFourthPersonType(people);

            DemonstratePolymorphicActivities(people);

            Console.WriteLine("\nДля выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        /// <summary>
        /// Создаёт и добавляет в список случайных взрослых и детей.
        /// </summary>
        /// <param name="people">Список, который требуется заполнить.</param>
        private static void CreateRandomPeople(PersonList people)
        {
            var generatedPeople = new List<PersonBase>
            {
                Adult.CreateRandomAdult(),
                Child.CreateRandomChild()
            };

            while (generatedPeople.Count < PeopleCount)
            {
                PersonBase person = Random.Next(2) == 0
                    ? (PersonBase)Adult.CreateRandomAdult()
                    : Child.CreateRandomChild();
                generatedPeople.Add(person);
            }

            foreach (var person in generatedPeople.OrderBy(_ => Random.Next()))
            {
                people.AddPerson(person);
            }

            int adultCount = generatedPeople.Count(person => person is Adult);
            int childCount = generatedPeople.Count - adultCount;

            Console.WriteLine("a. Создан список PersonList с семью людьми.");
            Console.WriteLine($"   В списке взрослых: {adultCount}, детей: {childCount}.");
        }

        /// <summary>
        /// Выводит подробное описание всех людей из списка.
        /// </summary>
        /// <param name="people">Список людей.</param>
        private static void PrintPeopleDescriptions(PersonList people)
        {
            Console.WriteLine("\nb. Подробное описание людей в списке:");

            int index = 1;
            foreach (var person in people.People)
            {
                Console.WriteLine($"\nЧеловек #{index}:");
                Console.WriteLine(person.GetInformation());
                index++;
            }

            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadLine();
        }

        /// <summary>
        /// Определяет тип четвертого человека и вызывает метод, присущий классу.
        /// </summary>
        /// <param name="people">Список людей.</param>
        private static void DemonstrateFourthPersonType(PersonList people)
        {
            Console.WriteLine("\nc. Определение типа четвертого человека:");

            if (people.Count < 4)
            {
                Console.WriteLine("   В списке меньше четырех человек.");
                return;
            }

            PersonBase fourthPerson = people.GetPersonByIndex(3);

            switch (fourthPerson)
            {
                case Adult adult:
                {
                    Console.WriteLine("   Четвертый человек — взрослый.");
                    bool wasMarried = adult.IsMarried;
                    adult.AnnulMarriage();
                    Console.WriteLine(wasMarried
                        ? "   Вызван метод AnnulMarriage(): брак расторгнут."
                        : "   Вызван метод AnnulMarriage(): подтверждено отсутствие брака.");
                    break;
                }
                case Child child:
                {
                    Console.WriteLine("   Четвертый человек — ребенок.");
                    Console.WriteLine("   Вызов метода GetParentSummary():");
                    Console.WriteLine("   " + child.GetParentSummary());
                    break;
                }
                default:
                {
                    Console.WriteLine("   Тип четвертого человека определить не удалось.");
                    break;
                }
            }
        }

        /// <summary>
        /// Демонстрирует полиморфизм: для списка людей вызывается один и тот
        /// же метод базового класса, который по-разному реализован у потомков.
        /// </summary>
        /// <param name="people">Список людей.</param>
        private static void DemonstratePolymorphicActivities(PersonList people)
        {
            Console.WriteLine("\nd. Демонстрация полиморфизма при вызове DescribeDailyActivity():");

            int index = 1;
            foreach (PersonBase person in people.People)
            {
                Console.WriteLine($"   #{index} ({person.PersonType} " +
                    $"{person.FullName}) — {person.DescribeDailyActivity()}");
                index++;
            }

            Console.WriteLine("\nМетод был вызван через ссылки типа PersonBase," +
                " но выполнился по правилам конкретного класса.");
            Console.WriteLine("Полиморфизм продемонстрирован и использован" +
                " в завершении программы.");
        }
    }
}