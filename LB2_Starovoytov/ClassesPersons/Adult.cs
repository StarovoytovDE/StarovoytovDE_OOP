using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassesPersons
{
    /// <summary>
    /// Класс, описывающий совершеннолетнего человека.
    /// </summary>
    public class Adult : PersonBase
    {
        private static readonly Regex PhoneRegex = new Regex(
            @"^\+(?:\d[ \-]?){10,15}$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        /// Создаёт взрослого человека.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="age">Возраст (не менее 18).</param>
        /// <param name="workPlace">Место работы.</param>
        /// <param name="position">Должность.</param>
        /// <param name="phoneNumber">Номер телефона с кодом страны.</param>
        public Adult(string firstName, string lastName, Gender gender, int age,
            string workPlace, string position, string phoneNumber)
            : base(firstName, lastName, gender, BuildBirthDateFromAge(age))
        {
            if (age < AdultAge)
            {
                throw new ArgumentOutOfRangeException(nameof(age),
                    "Возраст совершеннолетнего должен быть не меньше 18 лет.");
            }

            WorkPlace = NormalizeOrganizationField(workPlace,
                nameof(workPlace));
            Position = NormalizeOrganizationField(position, nameof(position));
            PhoneNumber = NormalizePhone(phoneNumber);
        }

        /// <summary>
        /// Место работы.
        /// </summary>
        public string WorkPlace { get; }

        /// <summary>
        /// Должность.
        /// </summary>
        public string Position { get; }

        /// <summary>
        /// Контактный телефон.
        /// </summary>
        public string PhoneNumber { get; }

        /// <inheritdoc />
        public override string PersonType => Gender == Gender.Male
            ? "Взрослый"
            : "Взрослая";

        /// <inheritdoc />
        public override string GetInformation()
        {
            var builder = new StringBuilder();
            builder.AppendLine(BuildBaseInformation());
            builder.AppendLine("Место работы: " + WorkPlace);
            builder.AppendLine("Должность: " + Position);
            builder.Append("Телефон: " + PhoneNumber);
            return builder.ToString();
        }

        private static string NormalizeOrganizationField(string value,
            string argumentName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Значение не должно быть пустым.", argumentName);
            }

            return value.Trim();
        }

        private static string NormalizePhone(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException(
                    "Номер телефона обязателен.", nameof(phoneNumber));
            }

            string trimmed = phoneNumber.Trim();
            if (!PhoneRegex.IsMatch(trimmed))
            {
                throw new ArgumentException(
                    "Номер телефона должен содержать код страны и состоять " +
                    "из цифр, пробелов или дефисов.", nameof(phoneNumber));
            }

            return trimmed;
        }
    }
}
