using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_LB3_4
{
    /// <summary>
    /// Представляет абстракцию для расчёта скидок на покупку.
    /// </summary>
    public interface IDiscountStrategy
    {
        /// <summary>
        /// Человекопонятное описание типа скидки.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Вычисляет сумму скидки для указанной суммы покупки.
        /// </summary>
        /// <param name="purchaseAmount">Положительная сумма покупки.</param>
        /// <returns>Значение скидки, которое может быть применено.</returns>
        decimal CalculateDiscount(decimal purchaseAmount);

        /// <summary>
        /// Вычисляет итоговую стоимость после применения скидки.
        /// </summary>
        /// <param name="purchaseAmount">Положительная сумма покупки.</param>
        /// <returns>Итоговая сумма после скидки.</returns>
        decimal CalculatePrice(decimal purchaseAmount);
    }
}
