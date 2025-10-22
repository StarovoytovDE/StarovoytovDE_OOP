using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClassesPersons
{
    /// <summary>
    /// Коллекция людей.
    /// </summary>
    public class PersonList : IEnumerable<PersonBase>
    {
        private readonly List<PersonBase> _people = new List<PersonBase>();

        /// <summary>
        /// Количество элементов в списке.
        /// </summary>
        public int Count => _people.Count;

        /// <summary>
        /// Возвращает элемент по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        public PersonBase this[int index] => _people[index];

        /// <summary>
        /// Добавляет человека в список.
        /// </summary>
        /// <param name="person">Объект для добавления.</param>
        public void Add(PersonBase person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            _people.Add(person);
        }

        /// <summary>
        /// Удаляет человека из списка.
        /// </summary>
        /// <param name="person">Объект для удаления.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public bool Remove(PersonBase person)
        {
            if (person == null)
            {
                return false;
            }

            return _people.Remove(person);
        }

        /// <summary>
        /// Удаляет человека по индексу.
        /// </summary>
        /// <param name="index">Индекс.</param>
        public void RemoveAt(int index)
        {
            _people.RemoveAt(index);
        }

        /// <summary>
        /// Возвращает неизменяемое представление списка.
        /// </summary>
        public IReadOnlyList<PersonBase> AsReadOnly()
        {
            return _people.AsReadOnly();
        }

        /// <summary>
        /// Очищает список.
        /// </summary>
        public void Clear()
        {
            _people.Clear();
        }

        /// <summary>
        /// Находит человека по предикату.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Первый найденный человек или null.</returns>
        public PersonBase Find(Func<PersonBase, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return _people.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Реализация перечисления.
        /// </summary>
        public IEnumerator<PersonBase> GetEnumerator()
        {
            return _people.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
