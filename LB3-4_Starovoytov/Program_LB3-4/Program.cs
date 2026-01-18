using System;
using System.Globalization;
using Model_LB3_4;
using Model_LB3_4.Discounts;

namespace Program_LB3_4
{    
     /// <summary>
     /// Точка входа в программу. Содержит демонстрацию работы системы скидочных стратегий.
     /// </summary>
    internal class Program
    {
        /// <summary>
        /// Основной метод, выполняющий взаимодействие с пользователем,
        /// выбор стратегии скидки и отображение результата.
        /// </summary>
        private static void Main(string[] args)
        {
            Console.WriteLine("Первичная демонстрация системы скидок (вариант 5).");
            Console.WriteLine("Доступные стратегии: процентная и по сертификату.\n");

            try
            {
                var purchaseAmount = ReadPositiveDecimal("Введите сумму " +
                    "покупки (в рублях): ");
                var strategy = ChooseStrategy();

                Console.WriteLine($"\nВыбрана скидка: {strategy.Description}");
                var discount = strategy.CalculateDiscount(purchaseAmount);
                var finalPrice = strategy.CalculatePrice(purchaseAmount);

                Console.WriteLine($"Сумма скидки: {discount:N2} руб.");
                Console.WriteLine($"Итоговая цена: {finalPrice:N2} руб.");
            }
            catch (IncorrectArgumentException ex)
            {
                Console.WriteLine($"Ошибка валидации: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Выполняет выбор пользователем одной из доступных стратегий скидок:
        /// процентной или сертификатной.
        /// </summary>
        /// <returns>Экземпляр выбранной стратегии скидки.</returns>
        private static DiscountStrategyBase ChooseStrategy()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите тип скидки:");
                Console.WriteLine("1 — Процентная скидка");
                Console.WriteLine("2 — Скидка по сертификату");
                Console.Write("Ваш выбор: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                    {
                        while (true)
                        {
                            var percentage = ReadDecimal($"Введите процент " +
                               $"скидки ({PercentageDiscount.MinPercentage}-" +
                               $"{PercentageDiscount.MaxPercentage}): ");

                            try
                            {
                                return new PercentageDiscount(percentage);
                            }
                            catch (IncorrectArgumentException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}");
                            }
                        }
                    }
                    case "2":
                    {
                        while (true)
                        {
                            var certificateValue = 
                                    ReadPositiveDecimal("Введите номинал " +
                                    "сертификата (в рублях): ");

                            try
                            {
                                return new CertificateDiscount(certificateValue);
                            }
                            catch (IncorrectArgumentException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}");
                            }
                        }
                    }
                    default:
                    {
                        Console.WriteLine("Неизвестный вариант. Повторите ввод.");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Запрашивает у пользователя десятичное число,
        /// требуя, чтобы оно было строго положительным.
        /// </summary>
        /// <param name="prompt">Текст приглашения.</param>
        /// <returns>Положительное число.</returns>
        private static decimal ReadPositiveDecimal(string prompt)
        {
            while (true)
            {
                var value = ReadDecimal(prompt);

                if (value > 0)
                {
                    return value;
                }

                Console.WriteLine("Сумма должна быть положительной. Повторите ввод.");
            }
        }

        /// <summary>
        /// Запрашивает у пользователя число типа <see cref="decimal"/>, 
        /// используя несколько возможных культур для корректного распознавания
        /// точки или запятой.
        /// </summary>
        /// <param name="prompt">Текст приглашения.</param>
        /// <returns>Распознанное число.</returns>
        private static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (TryParseDecimal(input, out var value))
                {
                    return value;
                }
                Console.WriteLine("Не удалось распознать число. Используйте " +
                    "точку или запятую в качестве разделителя дробной части.");
            }
        }

        /// <summary>
        /// Пытается преобразовать строку в число <see cref="decimal"/> 
        /// с учётом возможных вариантов записи дробной части (точка или запятая)
        /// и разных систем локализации.
        /// </summary>
        /// <param name="input">Строка, введённая пользователем.</param>
        /// <param name="value">Распознанный результат, если преобразование успешно.</param>
        /// <returns>true — если распознавание удалось; иначе false.</returns>
        private static bool TryParseDecimal(string input, out decimal value)
        {
            var styles = NumberStyles.AllowDecimalPoint 
                            | NumberStyles.AllowThousands 
                            | NumberStyles.AllowLeadingSign;

            var normalizedInput = input ?? string.Empty;

            return decimal.TryParse(normalizedInput, styles, 
                                        CultureInfo.CurrentCulture, out value) 
                || decimal.TryParse(normalizedInput, styles, 
                                        CultureInfo.GetCultureInfo("ru-RU"), out value) 
                || decimal.TryParse(normalizedInput, styles, 
                                        CultureInfo.InvariantCulture, out value);
        }
    }
}
