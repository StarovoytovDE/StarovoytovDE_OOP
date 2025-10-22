using LB1_Starovoytov;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;

namespace Model
{
    /// <summary>
    /// Класс, описывающий совершеннолетнего человека.
    /// </summary>
    public class Adult : PersonBase
    {
        private static readonly Random Random = new Random();

        private static readonly IReadOnlyList<string> MaleFirstNames = new[]
        {
            "Алексей", "Иван", "Николай", "Павел", "Сергей", "Максим",
            "Дмитрий", "Ярослав", "Кирилл", "Георгий"
        };

        private static readonly IReadOnlyList<string> FemaleFirstNames = new[]
        {
            "Анна", "Мария", "Екатерина", "Ольга", "Светлана", "Наталья",
            "Елизавета", "Полина", "Вероника", "Виктория"
        };

        private static readonly IReadOnlyList<string> LastNames = new[]
        {
            "Иванов", "Петров", "Сидоров", "Орлов", "Кузнецов", "Смирнов",
            "Попов", "Васильев", "Зайцев", "Тарасов"
        };

        private static readonly IReadOnlyList<string> WorkPlaces = new[]
        {
            "ООО \"Ромашка\"", "АО \"Прогресс\"", "Банк \"Единство\"",
            "IT-компания \"Кванта\"", "Городская больница №3",
            "Школа №17", "Почта России", "Страховая группа \"Надежда\""
        };

        private static readonly IReadOnlyList<string> Positions = new[]
        {
            "инженер", "аналитик", "учитель", "менеджер проектов",
            "программист", "врач", "бухгалтер", "дизайнер"
        };

        private static readonly IReadOnlyList<string> IssuingAuthorities = new[]
        {
            "ГУ МВД России по г. Москве",
            "ГУ МВД России по г. Санкт-Петербургу",
            "Отдел УФМС по Московской области",
            "Отдел УФМС по Новосибирской области",
            "ГУ МВД России по Краснодарскому краю",
            "ГУ МВД России по Республике Татарстан"
        };

        private static readonly Regex PhoneRegex = new Regex(
                    @"^\+(?:\d[ \-]?){10,15}$",
                    RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        /// Создаёт взрослого человека.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст (не менее 18).</param>
        /// <param name="sex">Пол.</param>
        /// <param name="workPlace">Место работы.</param>
        /// <param name="position">Должность.</param>
        /// <param name="phoneNumber">Номер телефона с кодом страны.</param>
        /// <param name="passport">Паспортные данные.</param>
        /// <param name="spouse">Партнёр.</param>
        public Adult(string firstName, string lastName, int age, Gender sex,
            string workPlace, string position, string phoneNumber,
            PassportInfo passport, Adult spouse = null)
            : base(firstName, lastName, BuildBirthDateFromAge(age), sex)
        {
            WorkPlace = NormalizeOptionalField(workPlace);
            Position = NormalizeOptionalField(position);
            PhoneNumber = NormalizePhone(phoneNumber);
            Passport = passport ?? throw new ArgumentNullException(nameof(passport));

            if (spouse != null)
            {
                Marry(spouse);
            }
        }

        /// <inheritdoc />
        protected override void ValidateAgeForType(int age)
        {
            if (age < AdultAge)
            {
                throw new ArgumentOutOfRangeException(nameof(age),
                    "Возраст совершеннолетнего должен быть не меньше 18 лет.");
            }
        }

        /// <summary>
        /// Паспортные данные.
        /// </summary>
        public PassportInfo Passport { get; }

        /// <summary>
        /// Супруг или супруга.
        /// </summary>
        public Adult Spouse { get; private set; }

        /// <summary>
        /// Признак, состоит ли человек в браке.
        /// </summary>
        public bool IsMarried => Spouse != null;

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
        public override string PersonType => Sex == Gender.Male
            ? "Взрослый"
            : "Взрослая";

        /// <inheritdoc />
        public override string GetInformation()
        {
            var builder = new StringBuilder();
            builder.AppendLine(BuildBaseInformation());
            builder.AppendLine("Телефон: " + PhoneNumber);
            builder.AppendLine("Паспорт: " + Passport);
            builder.AppendLine(BuildMarriageInformation());
            builder.Append(BuildEmploymentInformation());
            return builder.ToString();
        }

        private static string NormalizeOptionalField(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
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

        private string BuildMarriageInformation()
        {
            if (!IsMarried)
            {
                return "Семейное положение: " + (Sex == Gender.Male
                    ? "Не женат"
                    : "Не замужем");
            }

            string marriedText = Sex == Gender.Male
                ? "Женат на "
                : "Замужем за ";
            return "Семейное положение: " + marriedText + Spouse.FullName;
        }

        private string BuildEmploymentInformation()
        {
            if (string.IsNullOrEmpty(WorkPlace))
            {
                return "Место работы: Безработный";
            }

            var builder = new StringBuilder();
            builder.Append("Место работы: ");
            builder.Append(WorkPlace);

            if (!string.IsNullOrEmpty(Position))
            {
                builder.Append("; Должность: ");
                builder.Append(Position);
            }
            else
            {
                builder.Append("; Должность: не указана");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Заключает брак с указанным партнёром.
        /// </summary>
        /// <param name="partner">Партнёр.</param>
        public void Marry(Adult partner)
        {
            if (partner is null)
            {
                throw new ArgumentNullException(nameof(partner));
            }

            if (ReferenceEquals(partner, this))
            {
                throw new ArgumentException(
                    "Нельзя вступить в брак с самим собой.",
                    nameof(partner));
            }

            if (Spouse == partner)
            {
                return;
            }

            AnnulMarriage();
            partner.AnnulMarriage();

            Spouse = partner;
            partner.Spouse = this;
        }

        /// <summary>
        /// Расторгает текущий брак.
        /// </summary>
        public void AnnulMarriage()
        {
            if (Spouse == null)
            {
                return;
            }

            var partner = Spouse;
            Spouse = null;

            if (partner.Spouse == this)
            {
                partner.Spouse = null;
            }
        }

                    /// <summary>
                    /// Создаёт взрослого человека со случайно сгенерированными данными.
                    /// </summary>
                    /// <returns>Экземпляр класса <see cref="Adult"/>.</returns>
        public static Adult CreateRandomAdult()
        {
            return CreateRandomAdult(null, null);
        }

        /// <summary>
        /// Создаёт взрослого со случайными данными с возможностью указать пол
        /// и фамилию.
        /// </summary>
        /// <param name="sex">Предпочитаемый пол. Если не указан,
        /// выбирается случайный.</param>
        /// <param name="lastName">Предпочитаемая фамилия. Если не указана,
        /// будет выбрана случайная.</param>
        /// <returns>Новый объект <see cref="Adult"/>.</returns>
        internal static Adult CreateRandomAdult(Gender? sex, string lastName)
        {
            Gender actualSex = sex ?? (Random.Next(2) == 0
                ? Gender.Male
                : Gender.Female);

            string firstName = actualSex == Gender.Male
                ? PickRandomValue(MaleFirstNames)
                : PickRandomValue(FemaleFirstNames);

            string actualLastName = string.IsNullOrWhiteSpace(lastName)
                ? PickRandomValue(LastNames)
                : lastName.Trim();

            int age = Random.Next(AdultAge, 76); // 18-75 лет
            string workPlace = PickRandomOptional(WorkPlaces, 0.3);
            string position = workPlace != null
                ? PickRandomOptional(Positions, 0.25)
                : null;

            string phoneNumber = GeneratePhoneNumber();
            DateTime birthDate = BuildBirthDateFromAge(age);
            PassportInfo passport = GeneratePassport(birthDate);

            return new Adult(firstName, actualLastName, age, actualSex,
                workPlace, position, phoneNumber, passport);
        }

        private static string PickRandomValue(IReadOnlyList<string> values)
        {
            return values[Random.Next(values.Count)];
        }

        private static string PickRandomOptional(IReadOnlyList<string> values,
            double nullProbability)
        {
            if (values.Count == 0 || Random.NextDouble() < nullProbability)
            {
                return null;
            }

            return PickRandomValue(values);
        }

        private static string GeneratePhoneNumber()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "+7-{0:D3}-{1:D3}-{2:D2}-{3:D2}",
                Random.Next(900, 1000),
                Random.Next(100, 1000),
                Random.Next(10, 100),
                Random.Next(10, 100));
        }

        private static PassportInfo GeneratePassport(DateTime birthDate)
        {
            string series = Random.Next(0, 10000).ToString("D4",
                CultureInfo.InvariantCulture);
            string number = Random.Next(0, 1_000_000).ToString("D6",
                CultureInfo.InvariantCulture);

            DateTime minimalIssueDate = birthDate.AddYears(14);
            DateTime legalMinimalDate = new DateTime(1960, 1, 1);
            if (minimalIssueDate < legalMinimalDate)
            {
                minimalIssueDate = legalMinimalDate;
            }

            DateTime issueDate = GetRandomDate(minimalIssueDate, DateTime.Today);
            string issuedBy = PickRandomValue(IssuingAuthorities);

            return new PassportInfo(series, number, issueDate, issuedBy);
        }

        private static DateTime GetRandomDate(DateTime start, DateTime end)
        {
            if (start > end)
            {
                start = end;
            }

            int range = (end - start).Days;
            if (range <= 0)
            {
                return start;
            }

            return start.AddDays(Random.Next(range + 1));
        }
    }
 }

