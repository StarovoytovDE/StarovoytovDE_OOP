using System;

namespace WinFormsLB4
{
    /// <summary>
    /// Виды стратегий скидки для расчётов.
    /// </summary>
    public enum DiscountStrategyKind
    {
        Percent = 0,
        Certificate = 1
    }

    /// <summary>
    /// Результат вычисления скидки для одной покупки (DTO для UI и сериализации).
    /// </summary>
    [Serializable]
    public sealed class DiscountCalculation
    {
        /// <summary>
        /// Сумма покупки.
        /// </summary>
        public decimal PurchaseAmount { get; }

        /// <summary>
        /// Тип стратегии скидки.
        /// </summary>
        public DiscountStrategyKind StrategyKind { get; }

        /// <summary>
        /// Величина скидки (процент или номинал).
        /// </summary>
        public decimal DiscountValue { get; }

        /// <summary>
        /// Сумма скидки.
        /// </summary>
        public decimal Discount { get; }

        /// <summary>
        /// Итоговая цена после скидки.
        /// </summary>
        public decimal FinalPrice { get; }

        /// <summary>
        /// Создаёт результат расчёта скидки.
        /// </summary>
        /// <param name="purchaseAmount">Сумма покупки.</param>
        /// <param name="strategyKind">Тип стратегии скидки.</param>
        /// <param name="discountValue">Величина скидки.</param>
        /// <param name="discount">Сумма скидки.</param>
        /// <param name="finalPrice">Итоговая стоимость.</param>
        public DiscountCalculation(
            decimal purchaseAmount,
            DiscountStrategyKind strategyKind,
            decimal discountValue,
            decimal discount,
            decimal finalPrice)
        {
            PurchaseAmount = purchaseAmount;
            StrategyKind = strategyKind;
            DiscountValue = discountValue;
            Discount = discount;
            FinalPrice = finalPrice;
        }

        /// <summary>
        /// Текстовое отображение стратегии.
        /// </summary>
        public string StrategyDisplay
        {
            get
            {
                return StrategyKind == DiscountStrategyKind.Percent
                    ? UiText.StrategyPercentDisplay
                    : UiText.StrategyCertificateDisplay;
            }
        }
    }
}
