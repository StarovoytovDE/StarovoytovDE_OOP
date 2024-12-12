using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1_Starovoytov
{
    internal class Classes
    {
        public enum Gender
        {
            Male,
            Female
        }

        public class Person
        {
            // Свойства класса
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public Gender Sex { get; set; }

            // Конструктор класса
            public Person(string firstName, string lastName, int age, Gender sex)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                Sex = sex;
            }

            // Метод для отображения информации о человеке
            public void DisplayInfo()
            {
                Console.WriteLine($"Имя: {FirstName}");
                Console.WriteLine($"Фамилия: {LastName}");
                Console.WriteLine($"Возраст: {Age}");
                Console.WriteLine($"Пол: {Sex}");
            }
        }

        public class PersonList
        {
            public List<Person> people;

            public PersonList()
            {
                people = new List<Person>();
            }

            // Метод для добавления элемента
            public void AddPerson(Person person)
            {
                people.Add(person);

            }

            // Метод для удаления элемента по объекту
            public void RemovePerson(Person person)
            {
                people.Remove(person);
            }

            // Метод для удаления элемента по индексу
            public void RemovePersonByIndex(int index)
            {
                if (index >= 0 && index < people.Count)
                {
                    people.RemoveAt(index);
                }
            }

            // Метод для поиска элемента по индексу
            public Person GetPersonByIndex(int index)
            {
                if (index >= 0 && index < people.Count)
                {
                    return people[index];
                }
                return null;
            }

            // Метод для получения индекса элемента
            public int GetIndexOfPerson(Person person)
            {
                return people.IndexOf(person);
            }

            // Метод для очистки списка
            public void ClearList()
            {
                people.Clear();
            }

            // Метод для получения количества элементов в списке
            public int GetCount()
            {
                return people.Count;
            }
        }
    }
}
