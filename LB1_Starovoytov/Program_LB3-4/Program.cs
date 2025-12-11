using System;
using System.Globalization;
using Model_LB3_4;
using Model_LB3_4.Discounts;

namespace Program_LB3_4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Первичная демонстрация системы скидок (вариант 5).");
            Console.WriteLine("Доступные стратегии: процентная и по сертификату.\n");

            try
            {
                var purchaseAmount = ReadDecimal("Введите сумму покупки: ");
                var strategy = ChooseStrategy();

                Console.WriteLine($"\nВыбрана скидка: {strategy.Description}");
                var discount = strategy.CalculateDiscount(purchaseAmount);
                var finalPrice = strategy.CalculatePrice(purchaseAmount);

                Console.WriteLine($"Сумма скидки: {discount:C}");
                Console.WriteLine($"Итоговая цена: {finalPrice:C}");
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

        private static DiscountStrategy ChooseStrategy()
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
                        var percentage = ReadDecimal("Введите процент скидки (0-100): ");
                        return new PercentageDiscount(percentage);
                    case "2":
                        var certificateValue = ReadDecimal("Введите номинал сертификата: ");
                        return new CertificateDiscount(certificateValue);
                    default:
                        Console.WriteLine("Неизвестный вариант. Повторите ввод.");
                        break;
                }
            }
        }

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

                Console.WriteLine("Не удалось распознать число. Используйте точку или запятую в качестве разделителя дробной части.");
            }
        }

        private static bool TryParseDecimal(string input, out decimal value)
        {
            var styles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign;

            var normalizedInput = input ?? string.Empty;

            return decimal.TryParse(normalizedInput, styles, CultureInfo.CurrentCulture, out value) ||
                   decimal.TryParse(normalizedInput, styles, CultureInfo.GetCultureInfo("ru-RU"), out value) ||
                   decimal.TryParse(normalizedInput, styles, CultureInfo.InvariantCulture, out value);
        }
    }
}
