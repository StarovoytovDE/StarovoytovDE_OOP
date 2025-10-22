using System;
using ClassesPersons;

namespace Lab2
{
    internal static class Program
    {
        private static void Main()
        {
            var personList = new PersonList();

            var accountant = new Adult(
                firstName: "Ирина",
                lastName: "Кузнецова",
                gender: Gender.Female,
                age: 32,
                workPlace: "ООО \"Финансы и учёт\"",
                position: "Главный бухгалтер",
                phoneNumber: "+7 921 555-33-22");

            var engineer = new Adult(
                firstName: "Андрей",
                lastName: "Морозов",
                gender: Gender.Male,
                age: 45,
                workPlace: "АО \"ПромСтрой\"",
                position: "Инженер-конструктор",
                phoneNumber: "+7-495-123-45-67");

            var pupil = new Child(
                firstName: "Олег",
                lastName: "Морозов",
                gender: Gender.Male,
                age: 12,
                language: Language.Russian,
                guardianFullName: "Мария Морозова");

            var dancer = new Child(
                firstName: "София",
                lastName: "Кузнецова",
                gender: Gender.Female,
                age: 7,
                language: Language.English,
                guardianFullName: "Иван Кузнецов");

            personList.Add(accountant);
            personList.Add(engineer);
            personList.Add(pupil);
            personList.Add(dancer);

            Console.WriteLine("Список людей в базе данных:\n");
            PrintPeople(personList);

            Console.WriteLine();
            Console.WriteLine("Поиск совершеннолетних сотрудников:");
            foreach (var person in personList)
            {
                if (person is Adult)
                {
                    Console.WriteLine(person.GetShortDescription());
                }
            }
        }

        private static void PrintPeople(PersonList personList)
        {
            foreach (var person in personList)
            {
                Console.WriteLine(person.GetInformation());
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
