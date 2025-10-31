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
        /// Генератор случайных чисел для построения примеров.
        /// </summary>
        private static readonly Random Random = new Random();

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
            Language = language;
            EducationalInstitution = NormalizeEducationalInstitution(
                educationalInstitution);
            Parents = BuildParentList(parents);
        }

        /// <inheritdoc />
        protected override void ValidateAgeForType(int age)
        {
            if (age >= AdultAge)
            {
                throw new ArgumentOutOfRangeException(nameof(age),
                    "Возраст ребёнка должен быть меньше 18 лет.");
            }
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

        /// <summary>
        /// Создаёт список родителей с фильтрацией недопустимых значений.
        /// </summary>
        /// <param name="parents">Исходная коллекция родителей.</param>
        /// <returns>Список родителей без повторов.</returns>
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

        /// <summary>
        /// Нормализует название образовательного учреждения.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <returns>Очищенное название.</returns>
        /// <exception cref="ArgumentException">Название отсутствует.</exception>
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

        /// <summary>
        /// Формирует строку с информацией о родителях ребёнка.
        /// </summary>
        /// <returns>Описание родителей.</returns>
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

        /// <summary>
        /// Возвращает краткое текстовое описание родителей ребёнка.
        /// </summary>
        /// <returns>Строка с информацией о родителях.</returns>
        public string GetParentSummary()
        {
            return BuildParentInformation();
        }

        /// <summary>
        /// Создаёт ребёнка со случайными параметрами.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Child"/>.</returns>
        public static Child CreateRandomChild()
        {
            var maleFirstNames = new[]
            {
                "Артём", "Матвей", "Алексей", "Ярослав", "Кирилл", "Лев",
                "Илья", "Богдан", "Тимофей", "Максим"
            };

            var femaleFirstNames = new[]
            {
                "Алиса", "Ева", "Милана", "Варвара", "София", "Ксения",
                "Дарья", "Арина", "Маргарита", "Ульяна"
            };

            var lastNames = new[]
            {
                "Иванов", "Поляков", "Романов", "Сергеев", "Лебедев",
                "Голубев", "Александров", "Жуков", "Комаров", "Соколов"
            };

            var kindergartenNames = new[]
            {
                "Детский сад №12 \"Ромашка\"",
                "Детский сад №48 \"Звёздочка\"",
                "Детский сад №3 \"Солнышко\"",
                "Детский сад №21 \"Аленький цветочек\""
            };

            var schoolNames = new[]
            {
                "Средняя школа №5",
                "Гимназия №2",
                "Лицей №17",
                "Школа с углублённым изучением английского языка №12",
                "Частная школа \"Перспектива\""
            };

            var languages = Enum
                .GetValues(typeof(Language))
                .Cast<Language>()
                .Where(candidate => candidate != Language.Unknown)
                .ToArray();

            Gender sex = Random.Next(2) == 0 ? Gender.Male : Gender.Female;
            string firstName = sex == Gender.Male
                ? PickRandomValue(maleFirstNames)
                : PickRandomValue(femaleFirstNames);

            string baseLastName = PickRandomValue(lastNames);

            int age = Random.Next(MinAge, AdultAge); // 0-17 лет
            Language primaryLanguage = PickRandomValue(languages);

            var parents = GenerateRandomParents(baseLastName);
            if (parents.Count > 0)
            {
                baseLastName = parents[0].LastName;
            }

            string educationalInstitution = age < 7
                ? PickRandomValue(kindergartenNames)
                : PickRandomValue(schoolNames);

            return new Child(firstName, baseLastName, age, sex, primaryLanguage,
                parents, educationalInstitution);
        }

        /// <summary>
        /// Создаёт случайный набор родителей для ребёнка.
        /// </summary>
        /// <param name="lastName">Базовая фамилия ребёнка.</param>
        /// <returns>Коллекция родителей.</returns>
        private static IReadOnlyList<Adult> GenerateRandomParents(string lastName)
        {
            var parents = new List<Adult>();

            if (Random.NextDouble() < 0.75)
            {
                parents.Add(Adult.CreateRandomAdult(Gender.Male, lastName));
            }

            if (Random.NextDouble() < 0.85)
            {
                parents.Add(Adult.CreateRandomAdult(Gender.Female, lastName));
            }

            if (parents.Count == 2)
            {
                parents[0].Marry(parents[1]);
            }

            return parents;
        }

        /// <summary>
        /// Возвращает случайный элемент из набора.
        /// </summary>
        /// <typeparam name="T">Тип элементов.</typeparam>
        /// <param name="values">Набор возможных значений.</param>
        /// <returns>Случайный элемент списка.</returns>
        private static T PickRandomValue<T>(IReadOnlyList<T> values)
        {
            return values[Random.Next(values.Count)];
        }
    }
}
