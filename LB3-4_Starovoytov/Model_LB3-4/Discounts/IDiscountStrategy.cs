using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_LB3_4.Discounts
{
    /// <summary>
    /// Контракт для расчёта скидок.
    /// </summary>
    internal interface IDiscountStrategy
    {
        /// <summary>
        /// Человекопонятное описание скидки.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Вычисляет скидку для суммы покупки.
        /// </summary>
        /// <param name="purchaseAmount">Положительная сумма покупки.</param>
        /// <returns>Сумма скидки.</returns>
        decimal CalculateDiscount(decimal purchaseAmount);

        /// <summary>
        /// Вычисляет итоговую цену после применения скидки.
        /// </summary>
        /// <param name="purchaseAmount">Положительная сумма покупки.</param>
        /// <returns>Итоговая сумма.</returns>
        decimal CalculatePrice(decimal purchaseAmount);
    }
}
