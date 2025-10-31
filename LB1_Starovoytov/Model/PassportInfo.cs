using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Паспортные данные.
    /// </summary>
    public class PassportInfo
    {
        /// <summary>
        /// Регулярное выражение для проверки серии паспорта.
        /// </summary>
        private static readonly Regex SeriesRegex = new Regex(
            @"^\d{4}$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        /// Регулярное выражение для проверки номера паспорта.
        /// </summary>
        private static readonly Regex NumberRegex = new Regex(
            @"^\d{6}$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        /// Создаёт паспортные данные.
        /// </summary>
        /// <param name="series">Серия паспорта (4 цифры).</param>
        /// <param name="number">Номер паспорта (6 цифр).</param>
        /// <param name="issueDate">Дата выдачи.</param>
        /// <param name="issuedBy">Орган, выдавший паспорт.</param>
        public PassportInfo(string series, string number, DateTime issueDate,
            string issuedBy)
        {
            Series = ValidatePassportSeries(series);
            Number = ValidatePassportNumber(number);
            IssueDate = ValidateIssueDate(issueDate);
            IssuedBy = ValidateIssuedBy(issuedBy);
        }

        /// <summary>
        /// Серия паспорта.
        /// </summary>
        public string Series { get; }

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public string Number { get; }

        /// <summary>
        /// Дата выдачи документа.
        /// </summary>
        public DateTime IssueDate { get; }

        /// <summary>
        /// Орган, выдавший документ.
        /// </summary>
        public string IssuedBy { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Series} {Number}, выдан {IssueDate:d} {IssuedBy}";
        }

        /// <summary>
        /// Проверяет серию паспорта.
        /// </summary>
        /// <param name="series">Серия паспорта.</param>
        /// <returns>Очищенная серия паспорта.</returns>
        /// <exception cref="ArgumentException">Серия отсутствует или имеет
        /// неверный формат.</exception>
        private static string ValidatePassportSeries(string series)
        {
            if (string.IsNullOrWhiteSpace(series))
            {
                throw new ArgumentException(
                    "Серия паспорта обязательна.", nameof(series));
            }

            string normalized = series.Trim();
            if (!SeriesRegex.IsMatch(normalized))
            {
                throw new ArgumentException(
                    "Серия паспорта должна состоять из четырёх цифр.",
                    nameof(series));
            }

            return normalized;
        }

        /// <summary>
        /// Проверяет номер паспорта.
        /// </summary>
        /// <param name="number">Номер паспорта.</param>
        /// <returns>Очищенный номер паспорта.</returns>
        /// <exception cref="ArgumentException">Номер отсутствует или имеет
        /// неверный формат.</exception>
        private static string ValidatePassportNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException(
                    "Номер паспорта обязателен.", nameof(number));
            }

            string normalized = number.Trim();
            if (!NumberRegex.IsMatch(normalized))
            {
                throw new ArgumentException(
                    "Номер паспорта должен состоять из шести цифр.",
                    nameof(number));
            }

            return normalized;
        }

        /// <summary>
        /// Проверяет название органа выдачи паспорта.
        /// </summary>
        /// <param name="issuedBy">Орган, выдавший документ.</param>
        /// <returns>Очищенное значение.</returns>
        /// <exception cref="ArgumentException">Название органа отсутствует.</exception>
        private static string ValidateIssuedBy(string issuedBy)
        {
            if (string.IsNullOrWhiteSpace(issuedBy))
            {
                throw new ArgumentException(
                    "Необходимо указать орган, выдавший паспорт.",
                    nameof(issuedBy));
            }

            return issuedBy.Trim();
        }

        /// <summary>
        /// Проверяет дату выдачи паспорта.
        /// </summary>
        /// <param name="issueDate">Дата выдачи документа.</param>
        /// <returns>Корректная дата выдачи.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Дата находится в
        /// будущем или выглядит нереалистично.</exception>
        private static DateTime ValidateIssueDate(DateTime issueDate)
        {
            DateTime today = DateTime.Today;
            if (issueDate.Date > today)
            {
                throw new ArgumentOutOfRangeException(nameof(issueDate),
                    "Дата выдачи паспорта не может находиться в будущем.");
            }

            if (issueDate.Year < 1960)
            {
                throw new ArgumentOutOfRangeException(nameof(issueDate),
                    "Дата выдачи паспорта выглядит нереалистично.");
            }

            return issueDate.Date;
        }
    }
}
