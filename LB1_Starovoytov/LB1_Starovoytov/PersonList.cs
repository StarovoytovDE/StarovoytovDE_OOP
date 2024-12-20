using System.Collections.Generic;

namespace LB1_Starovoytov
{
    internal partial class Classes
    {
        //TODO: XML
        public class PersonList
        {
            //TODO: encapsulation

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

            //TODO: to property
            // Метод для получения количества элементов в списке
            public int GetCount()
            {
                return people.Count;
            }
        }
    }
}
