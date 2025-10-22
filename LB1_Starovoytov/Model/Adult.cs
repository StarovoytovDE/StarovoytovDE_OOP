using LB1_Starovoytov;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Model
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
            if (age < AdultAge)
            {
                throw new ArgumentOutOfRangeException(nameof(age),
                    "Возраст совершеннолетнего должен быть не меньше 18 лет.");
            }

            WorkPlace = NormalizeOptionalField(workPlace);
            Position = NormalizeOptionalField(position);
            PhoneNumber = NormalizePhone(phoneNumber);
            Passport = passport ?? throw new ArgumentNullException(nameof(passport));

            if (spouse != null)
            {
                Marry(spouse);
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
    }
}
