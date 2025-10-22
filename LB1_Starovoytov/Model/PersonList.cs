using System;
using System.Collections.Generic;

namespace LB1_Starovoytov
{
    /// <summary>
    /// Класс, представляющий список людей (Person).
    /// Предоставляет методы для управления списком: добавление, удаление,
    /// поиск и очистка.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Приватное поле для хранения списка людей
        /// </summary>
        private readonly List<PersonBase> _people;

        /// <summary>
        /// Конструктор по умолчанию для инициализации нового списка людей.
        /// </summary>
        public PersonList()
        {
            _people = new List<PersonBase>();
        }

        /// <summary>
        /// Свойство для доступа к списку (только для чтения)
        /// </summary>
        public IReadOnlyList<PersonBase> People => _people.AsReadOnly();

        /// <summary>
        ///  Метод для добавления человека в список.
        /// </summary>
        /// <param name="person">Объект типа Person, который нужно добавить
        /// в список.</param>
        public void AddPerson(PersonBase person)
        {
            _people.Add(person);
        }

        /// <summary>
        /// Метод для удаления человека из списка по объекту.
        /// </summary>
        /// <param name="person">Объект типа Person, который нужно удалить из
        /// списка.</param>
        public void RemovePerson(PersonBase person)
        {
            _people.Remove(person);
        }

        /// <summary>
        /// Метод для удаления человека из списка по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента, который нужно удалить.</param>
        public void RemovePersonByIndex(int index)
        {
            if (index >= 0 && index < People.Count)
            {
                _people.RemoveAt(index);
            }
        }

        /// <summary>
        /// Метод для возврата человека из списка по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента, который нужно вернуть.</param>
        /// <returns>Объект типа Person, если индекс корректен; в противном
        /// случае — null.</returns>
        public PersonBase GetPersonByIndex(int index)
        {
            if (index >= 0 && index < People.Count)
            {
                return _people[index];
            }
            return null;
        }

        /// <summary>
        /// Метод для возврата индекса указанного человека в списке.
        /// </summary>
        /// <param name="person">Объект типа Person, индекс которого нужно
        /// найти.</param>
        /// <returns>Индекс объекта в списке, если он найден; в противном
        /// случае — -1.</returns>
        public int GetIndexOfPerson(PersonBase person)
        {
            return _people.IndexOf(person);
        }

        /// <summary>
        /// Метод для очистки всего списка.
        /// </summary>
        public void ClearList()
        {
            _people.Clear();
        }

        /// <summary>
        /// Метод для получения количества элементов в списке.
        /// </summary>
        public int Count => _people.Count;
    }
}