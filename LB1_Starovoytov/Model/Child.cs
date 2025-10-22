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
            builder.AppendLine("Образовательное учреждение:" + EducationalInstitution);
            builder.Append(BuildParentInformation());
            return builder.ToString();
        }

        private static IReadOnlyList<Adult> BuildParentList(IEnumerable<Adult> parents)
        {
            if (parents == null)
            {
                return Array.Empty<Adult>();
            }

            var parentList = parents
                .Where(parent => parent != null)
                .Distinct()
                .ToList();

            return parentList.Count == 0
                ? (IReadOnlyList<Adult>)Array.Empty<Adult>() // Adult[] реализует IReadOnlyList<Adult>
                : parentList;
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

        private string BuildParentInformation()
        {
            if (Parents.Count == 0)
            {
                return "Родители: информация отсутствует";
            }

            var fathers = Parents
                .Where(parent => parent.Sex == Gender.Male)
                .Select(parent => parent.FullName)
                .ToList();
            var mothers = Parents
                .Where(parent => parent.Sex == Gender.Female)
                .Select(parent => parent.FullName)
                .ToList();

            var builder = new StringBuilder("Родители: ");
            if (fathers.Count > 0)
            {
                builder.Append("отец - ");
                builder.Append(string.Join(", ", fathers));
            }
            else
            {
                builder.Append("отец не указан");
            }

            builder.Append("; ");

            if (mothers.Count > 0)
            {
                builder.Append("мать - ");
                builder.Append(string.Join(", ", mothers));
            }
            else
            {
                builder.Append("мать не указана");
            }

            return builder.ToString();
        }
    }
}
