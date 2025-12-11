using System;

namespace Model.Discounts;

/// <summary>
/// Рассчитывает скидку как процент от суммы покупки.
/// </summary>
public sealed class PercentageDiscount : IDiscountStrategy
{
    private decimal _percentage;

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
            if (value is < 0 or > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Процент должен быть между 0 и 100.");
            }

            _percentage = value;
        }
    }

    /// <inheritdoc />
    public string Description => $"Процентная скидка {Percentage}%";

    /// <inheritdoc />
    public decimal CalculateDiscount(decimal purchaseAmount)
    {
        ValidatePurchaseAmount(purchaseAmount);
        return decimal.Round(purchaseAmount * Percentage / 100m, 2, MidpointRounding.AwayFromZero);
    }

    /// <inheritdoc />
    public decimal CalculatePrice(decimal purchaseAmount)
    {
        ValidatePurchaseAmount(purchaseAmount);
        return decimal.Round(purchaseAmount - CalculateDiscount(purchaseAmount), 2, MidpointRounding.AwayFromZero);
    }

    private static void ValidatePurchaseAmount(decimal purchaseAmount)
    {
        if (purchaseAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(purchaseAmount), "Сумма покупки должна быть положительной.");
        }
    }
}
