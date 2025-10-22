using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassesPersons
{
    /// <summary>
    /// Базовый класс, описывающий общие данные о человеке.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Минимально допустимый возраст.
        /// </summary>
        public const int MinAge = 0;

        /// <summary>
        /// Максимально допустимый возраст.
        /// </summary>
        public const int MaxAge = 125;

        /// <summary>
        /// Возраст, с которого человек считается совершеннолетним.
        /// </summary>
        public const int AdultAge = 18;

        private static readonly Regex NameRegex = new Regex(
            @"^[a-zA-Zа-яА-ЯёЁ\s-]+$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private static readonly Regex SpaceRegex = new Regex(@"\s+",
            RegexOptions.Compiled);

        /// <summary>
        /// Создаёт экземпляр базового класса человека.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="dateOfBirth">Дата рождения.</param>
        protected PersonBase(string firstName, string lastName, Gender gender,
            DateTime dateOfBirth)
        {
            FirstName = NormalizeName(firstName, nameof(firstName));
            LastName = NormalizeName(lastName, nameof(lastName));
            Gender = gender;
            DateOfBirth = ValidateBirthDate(dateOfBirth);
            ValidateAgeRange(Age);
        }

        /// <summary>
        /// Имя человека.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Фамилия человека.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Пол человека.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime DateOfBirth { get; protected set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName => FirstName + " " + LastName;

        /// <summary>
        /// Возраст, рассчитанный на основе даты рождения.
        /// </summary>
        public int Age => CalculateAge(DateTime.Today, DateOfBirth);

        /// <summary>
        /// Отображаемое название типа человека.
        /// </summary>
        public abstract string PersonType { get; }

        /// <summary>
        /// Возвращает подробную информацию об объекте.
        /// </summary>
        public abstract string GetInformation();

        /// <summary>
        /// Возвращает краткое текстовое представление объекта.
        /// </summary>
        /// <returns>Строка с базовой информацией.</returns>
        public virtual string GetShortDescription()
        {
            return PersonType + ": " + FullName + ", возраст: " + Age +
                ", пол: " + Gender + ".";
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return GetShortDescription();
        }

        /// <summary>
        /// Возвращает строку с основной информацией о человеке.
        /// </summary>
        /// <returns>Строка для повторного использования в потомках.</returns>
        protected string BuildBaseInformation()
        {
            var builder = new StringBuilder();
            builder.AppendLine(PersonType + ": " + FullName);
            builder.AppendLine("Пол: " + Gender);
            builder.AppendLine("Возраст: " + Age);
            builder.Append("Дата рождения: " + DateOfBirth.ToString("d"));
            return builder.ToString();
        }

        /// <summary>
        /// Рассчитывает дату рождения на основе возраста.
        /// </summary>
        /// <param name="age">Возраст в годах.</param>
        /// <returns>Дата рождения.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возраст выходит за допустимые пределы.
        /// </exception>
        protected static DateTime BuildBirthDateFromAge(int age)
        {
            ValidateAgeRange(age);
            DateTime today = DateTime.Today;
            DateTime birthDate = today.AddYears(-age);
            if (birthDate > today)
            {
                birthDate = birthDate.AddDays(-1);
            }

            return birthDate;
        }

        /// <summary>
        /// Вычисляет возраст в годах по дате рождения.
        /// </summary>
        /// <param name="today">Текущая дата.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <returns>Возраст.</returns>
        protected static int CalculateAge(DateTime today, DateTime birthDate)
        {
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        protected static string NormalizeName(string value, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Строковое значение не должно быть пустым.", argumentName);
            }

            string trimmed = SpaceRegex.Replace(value.Trim(), " ");
            if (!NameRegex.IsMatch(trimmed))
            {
                throw new ArgumentException(
                    "Имя и фамилия должны содержать только буквы, пробелы или дефисы.",
                    argumentName);
            }

            string lower = trimmed.ToLower(CultureInfo.CurrentCulture);
            return Regex.Replace(lower, @"\b\w",
                match => match.Value.ToUpper(CultureInfo.CurrentCulture));
        }

        private static DateTime ValidateBirthDate(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            if (dateOfBirth.Date > today)
            {
                throw new ArgumentOutOfRangeException(nameof(dateOfBirth),
                    "Дата рождения не может находиться в будущем.");
            }

            return dateOfBirth.Date;
        }

        protected static void ValidateAgeRange(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new ArgumentOutOfRangeException(nameof(age),
                    "Возраст должен быть в пределах от 0 до 125 лет.");
            }
        }
    }
}
