using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_LB3_4.Discounts
{
    /// <summary>
    /// Рассчитывает скидку как процент от суммы покупки.
    /// </summary>
    public sealed class PercentageDiscount : DiscountStrategy
    {
        //TODO: XML+
        /// <summary>
        /// Хранит значение процента скидки.
        /// </summary>
        private decimal _percentage;

        /// <summary>
        /// Минимально допустимое значение процента скидки.
        /// </summary>
        public static readonly decimal MinPercentage = 0m;

        /// <summary>
        /// Максимально допустимое значение процента скидки.
        /// </summary>
        public static readonly decimal MaxPercentage = 100m;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="PercentageDiscount"/>.
        /// </summary>
        /// <param name="percentage">Процент скидки в диапазоне от 0 до 100.</param>
        public PercentageDiscount(decimal percentage)
        {
            Percentage = percentage;
        }

        /// <summary>
        /// Процент скидки. Значение должно быть в диапазоне от 0 до 100 включительно.
        /// </summary>
        public decimal Percentage
        {
            get => _percentage;
            set
            {
                //TOOD: refactor+
                if (value < MinPercentage || value > MaxPercentage)
                {
                    throw new IncorrectArgumentException(
                        nameof(value),
                        $"Процент должен быть между {MinPercentage}% " +
                                                $"и {MaxPercentage}%.");
                }

                _percentage = value;
            }
        }

        /// <inheritdoc />
        public override string Description => $"Процентная скидка {Percentage}%";

        /// <inheritdoc />
        public override decimal CalculateDiscount(decimal purchaseAmount)
        {
            ValidatePurchaseAmount(purchaseAmount);
            return decimal.Round(purchaseAmount * Percentage / 100m, 2, 
                MidpointRounding.AwayFromZero);
        }
    }
}
