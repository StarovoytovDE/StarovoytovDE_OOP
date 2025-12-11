using Model_LB3_4.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_LB3_4
{
    /// <summary>
    /// Базовый класс для расчёта скидок на покупку.
    /// </summary>
    public abstract class DiscountStrategy : IDiscountStrategy
    {
        /// <summary>
        /// Описание типа скидки.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Вычисляет сумму скидки.
        /// </summary>
        /// <param name="purchaseAmount">Положительная сумма покупки.</param>
        /// <returns>Значение скидки, которое может быть применено.</returns>
        public abstract decimal CalculateDiscount(decimal purchaseAmount);

        /// <summary>
        /// Вычисляет итоговую стоимость после применения скидки.
        /// </summary>
        /// <param name="purchaseAmount">Положительная сумма покупки.</param>
        /// <returns>Итоговая сумма после скидки.</returns>
        public virtual decimal CalculatePrice(decimal purchaseAmount)
        {
            ValidatePurchaseAmount(purchaseAmount);
            var discount = CalculateDiscount(purchaseAmount);
            var price = purchaseAmount - discount;
            return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Проверяет корректность суммы покупки.
        /// </summary>
        /// <param name="purchaseAmount">Сумма покупки.</param>
        /// <exception cref="IncorrectArgumentException">Если сумма некорректна.</exception>
        protected static void ValidatePurchaseAmount(decimal purchaseAmount)
        {
            if (purchaseAmount <= 0)
            {
                throw new IncorrectArgumentException(nameof(purchaseAmount),
                    "Сумма покупки должна быть положительной.");
            }
        }
    }
}
