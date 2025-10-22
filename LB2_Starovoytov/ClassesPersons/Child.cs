using System;
using System.Text;

namespace ClassesPersons
{
    /// <summary>
    /// Класс, описывающий ребёнка.
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Создаёт ребёнка.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="age">Возраст (меньше 18).</param>
        /// <param name="language">Предпочитаемый язык.</param>
        /// <param name="guardianFullName">ФИО дополнительного родителя.</param>
        public Child(string firstName, string lastName, Gender gender, int age,
            Language language, string guardianFullName)
            : base(firstName, lastName, gender, BuildBirthDateFromAge(age))
        {
            if (age >= AdultAge)
            {
                throw new ArgumentOutOfRangeException(nameof(age),
                    "Возраст ребёнка должен быть меньше 18 лет.");
            }

            Language = language;
            GuardianFullName = NormalizeGuardian(guardianFullName);
        }

        /// <summary>
        /// Предпочитаемый язык общения.
        /// </summary>
        public Language Language { get; }

        /// <summary>
        /// ФИО дополнительного родителя.
        /// </summary>
        public string GuardianFullName { get; }

        /// <inheritdoc />
        public override string PersonType => Gender == Gender.Male
            ? "Мальчик"
            : "Девочка";

        /// <inheritdoc />
        public override string GetInformation()
        {
            var builder = new StringBuilder();
            builder.AppendLine(BuildBaseInformation());
            builder.AppendLine("Язык: " + Language);
            builder.Append("Дополнительный родитель: " + GuardianFullName);
            return builder.ToString();
        }

        private static string NormalizeGuardian(string guardianFullName)
        {
            return NormalizeName(guardianFullName, nameof(guardianFullName));
        }
    }
}
