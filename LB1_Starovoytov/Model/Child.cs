using LB1_Starovoytov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
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
        /// <param name="sex">Пол.</param>
        /// <param name="age">Возраст (меньше 18).</param>
        /// <param name="language">Предпочитаемый язык.</param>
        /// <param name="parents">Родители ребёнка.</param>
        /// <param name="educationalInstitution">Название образовательного учреждения или детского сада.</param>
        public Child(string firstName, string lastName, int age, Gender sex,
            Language language, IEnumerable<Adult> parents,
            string educationalInstitution)
            : base(firstName, lastName, BuildBirthDateFromAge(age), sex)
        {
            if (age >= AdultAge)
            {
                throw new ArgumentOutOfRangeException(nameof(age),
                    "Возраст ребёнка должен быть меньше 18 лет.");
            }

            Language = language;
            EducationalInstitution = NormalizeEducationalInstitution(
                educationalInstitution);
            Parents = BuildParentList(parents);
        }

        /// <summary>
        /// Предпочитаемый язык общения.
        /// </summary>
        public Language Language { get; }

        /// <summary>
        /// Название образовательного учреждения.
        /// </summary>
        public string EducationalInstitution { get; }

        /// <summary>
        /// Родители ребёнка.
        /// </summary>
        public IReadOnlyList<Adult> Parents { get; }

        /// <inheritdoc />
        public override string PersonType => Sex == Gender.Male
            ? "Мальчик"
            : "Девочка";

        /// <inheritdoc />
        public override string GetInformation()
        {
            var builder = new StringBuilder();
            builder.AppendLine(BuildBaseInformation());
            builder.AppendLine("Язык: " + Language);
            builder.AppendLine("Образовательное учреждение: " + EducationalInstitution);
            builder.Append("Родители: " + string.Join(", ", Parents.Select(p => p.FullName)));
            return builder.ToString();
        }

        private static IReadOnlyList<Adult> BuildParentList(IEnumerable<Adult> parents)
        {
            if (parents == null)
            {
                throw new ArgumentNullException(nameof(parents));
            }

            var parentList = parents
                .Where(parent => parent != null)
                .Distinct()
                .ToList();

            if (parentList.Count == 0)
            {
                throw new ArgumentException(
                    "Необходимо указать хотя бы одного родителя.",
                    nameof(parents));
            }

            return parentList.AsReadOnly();
        }

        private static string NormalizeEducationalInstitution(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Название образовательного учреждения обязательно.",
                    nameof(value));
            }

            return value.Trim();
        }
    }
}
