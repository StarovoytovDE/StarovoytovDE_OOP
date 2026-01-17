namespace WinFormsLB4
{
    /// <summary>
    /// Константы пользовательского интерфейса (ограничения, диапазоны, 
    /// служебные значения).
    /// </summary>
    internal static class UiConstants
    {
        /// <summary>
        /// Минимально допустимый процент скидки.
        /// </summary>
        public const decimal PercentageMin = 0m;

        /// <summary>
        /// Максимально допустимый процент скидки.
        /// </summary>
        public const decimal PercentageMax = 100m;

        /// <summary>
        /// Минимально допустимая сумма сертификата.
        /// </summary>
        public const decimal CertificateAmountMin = 0m;

        /// <summary>
        /// Максимально допустимая сумма сертификата.
        /// </summary>
        public const decimal CertificateAmountMax = 100000m;

        /// <summary>
        /// Минимальная сумма покупки для генерации случайного расчёта.
        /// </summary>
        public const int RandomPurchaseAmountMin = 1;

        /// <summary>
        /// Максимальная сумма покупки для генерации случайного расчёта.
        /// </summary>
        public const int RandomPurchaseAmountMax = 1_000_000;

        /// <summary>
        /// Минимальный процент скидки для генерации случайного расчёта.
        /// </summary>
        public const int RandomPercentMin = 1;

        /// <summary>
        /// Максимальный процент скидки для генерации случайного расчёта.
        /// </summary>
        public const int RandomPercentMax = 99;
    }
}
