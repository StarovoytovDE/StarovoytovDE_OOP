using Model_LB3_4;
using Model_LB3_4.Discounts;

namespace WinFormsLB4
{
    /// <summary>
    /// Фабрика для создания объектов расчёта скидки.
    /// Инкапсулирует логику выбора стратегии и вычисления результатов.
    /// </summary>
    internal static class DiscountCalculationFactory
    {
        /// <summary>
        /// Создаёт расчёт скидки по заданным параметрам.
        /// </summary>
        /// <param name="purchaseAmount">Сумма покупки.</param>
        /// <param name="strategyKind">Тип стратегии скидки.</param>
        /// <param name="discountValue">
        /// Значение стратегии: процент скидки или номинал сертификата.
        /// </param>
        /// <returns>Готовый объект расчёта скидки (DTO для UI).</returns>
        public static DiscountCalculation Create(decimal purchaseAmount, 
                                                 DiscountStrategyKind strategyKind, 
                                                 decimal discountValue)
        {
            DiscountStrategy strategy;

            switch (strategyKind)
            {
                //TODO: {}
                case DiscountStrategyKind.Percent:
                    strategy = new PercentageDiscount(discountValue);
                    break;

                case DiscountStrategyKind.Certificate:
                    strategy = new CertificateDiscount(discountValue);
                    break;

                default:
                    throw new IncorrectArgumentException(nameof(strategyKind), 
                                            "Неизвестный тип стратегии скидки.");
            }

            var discount = strategy.CalculateDiscount(purchaseAmount);
            var finalPrice = strategy.CalculatePrice(purchaseAmount);

            return new DiscountCalculation(purchaseAmount, 
                                           strategyKind, 
                                           discountValue, 
                                           discount, 
                                           finalPrice);
        }
    }
}
