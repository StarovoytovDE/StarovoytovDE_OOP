namespace WinFormsLB4
{
    /// <summary>
    /// Режимы фильтрации по стратегии скидки.
    /// </summary>
    public enum StrategyFilterKind
    {
        All = 0,
        Percent = 1,
        Certificate = 2
    }

    /// <summary>
    /// Набор критериев поиска расчётов скидок.
    /// </summary>
    public sealed class SearchCriteria
    {
        /// <summary>
        /// Фильтр по типу стратегии.
        /// </summary>
        public StrategyFilterKind StrategyFilter { get; set; }

        /// <summary>
        /// Нижняя граница суммы покупки.
        /// </summary>
        public decimal? PurchaseAmountFrom { get; set; }

        /// <summary>
        /// Верхняя граница суммы покупки.
        /// </summary>
        public decimal? PurchaseAmountTo { get; set; }

        /// <summary>
        /// Нижняя граница суммы к оплате.
        /// </summary>
        public decimal? FinalPriceFrom { get; set; }

        /// <summary>
        /// Верхняя граница суммы к оплате.
        /// </summary>
        public decimal? FinalPriceTo { get; set; }

        /// <summary>
        /// Нижняя граница номинала сертификата.
        /// </summary>
        public decimal? CertificateValueFrom { get; set; }

        /// <summary>
        /// Верхняя граница номинала сертификата.
        /// </summary>
        public decimal? CertificateValueTo { get; set; }

        /// <summary>
        /// Нижняя граница процента скидки.
        /// </summary>
        public decimal? PercentageFrom { get; set; }

        /// <summary>
        /// Верхняя граница процента скидки.
        /// </summary>
        public decimal? PercentageTo { get; set; }
    }
}
