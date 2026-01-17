namespace WinFormsLB4
{
    /// <summary>
    /// Набор критериев поиска расчётов скидок.
    /// </summary>
    public sealed class SearchCriteria
    {
        /// <summary>
        /// Выбранные стратегии для фильтрации.
        /// </summary>
        public StrategyFilterFlags StrategyFlags { get; set; }

        /// <summary>
        /// Нижняя граница суммы покупки.
        /// </summary>
        public decimal? PurchaseAmountFrom { get; set; }

        /// <summary>
        /// Верхняя граница суммы покупки.
        /// </summary>
        public decimal? PurchaseAmountTo { get; set; }

        /// <summary>
        /// Нижняя граница величины скидки (процент или сумма сертификата).
        /// </summary>
        public decimal? DiscountValueFrom { get; set; }

        /// <summary>
        /// Верхняя граница величины скидки (процент или сумма сертификата).
        /// </summary>
        public decimal? DiscountValueTo { get; set; }
    }
}
