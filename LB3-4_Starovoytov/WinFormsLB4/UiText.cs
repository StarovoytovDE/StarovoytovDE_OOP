namespace WinFormsLB4
{
    /// <summary>
    /// Текстовые константы пользовательского интерфейса
    /// (заголовки окон, сообщения, подписи элементов управления).
    /// </summary>
    internal static class UiText
    {
        /// <summary>
        /// Заголовок окна ошибки ввода данных.
        /// </summary>
        public const string InputErrorTitle = "Ошибка ввода";

        /// <summary>
        /// Общий заголовок окна ошибки приложения.
        /// </summary>
        public const string AppErrorTitle = "Ошибка";

        /// <summary>
        /// Заголовок окна подтверждения действий пользователя.
        /// </summary>
        public const string ConfirmTitle = "Подтверждение";

        /// <summary>
        /// Заголовок окна удаления данных.
        /// </summary>
        public const string DeleteTitle = "Удаление";

        /// <summary>
        /// Заголовок окна сохранения данных.
        /// </summary>
        public const string SaveTitle = "Сохранение";

        /// <summary>
        /// Заголовок окна загрузки данных.
        /// </summary>
        public const string LoadTitle = "Загрузка";

        /// <summary>
        /// Сообщение о необходимости выбрать строку для удаления.
        /// </summary>
        public const string SelectRowToDelete =
            "Выберите строку для удаления.";

        /// <summary>
        /// Сообщение подтверждения очистки полного списка расчётов.
        /// </summary>
        public const string ConfirmClearList =
            "Очистить список расчётов?";

        /// <summary>
        /// Сообщение подтверждения очистки только отфильтрованных расчётов.
        /// </summary>
        public const string ConfirmClearFilteredList =
            "Очистить только отфильтрованные расчёты?";

        /// <summary>
        /// Отображаемое наименование процентной стратегии скидки.
        /// </summary>
        public const string StrategyPercentDisplay = "Процентная";

        /// <summary>
        /// Отображаемое наименование стратегии скидки по сертификату.
        /// </summary>
        public const string StrategyCertificateDisplay = "Сертификат";

        /// <summary>
        /// Текстовое описание процентной стратегии в пользовательском интерфейсе.
        /// </summary>
        public const string StrategyPercentUi =
            "Процентная стратегия";

        /// <summary>
        /// Текстовое описание стратегии скидки по сертификату
        /// в пользовательском интерфейсе.
        /// </summary>
        public const string StrategyCertificateUi =
            "Стратегия сертификат";

        /// <summary>
        /// Подпись поля ввода значения процентной скидки.
        /// </summary>
        public const string LabelPercentValue =
            "Процент скидки (%):";

        /// <summary>
        /// Подпись поля ввода суммы сертификата.
        /// </summary>
        public const string LabelCertificateValue =
            "Сумма сертификата:";

        /// <summary>
        /// Наименование поля суммы покупки.
        /// </summary>
        public const string FieldPurchaseAmount =
            "Сумма покупки";

        /// <summary>
        /// Наименование поля величины скидки.
        /// </summary>
        public const string FieldDiscountValue =
            "Величина скидки";

        /// <summary>
        /// Заголовок формы поиска расчётов.
        /// </summary>
        public const string FindFormTitle = "Поиск";

        /// <summary>
        /// Заголовок формы добавления нового расчёта.
        /// </summary>
        public const string AddFormTitle = "Добавить расчёт";

        /// <summary>
        /// Заголовок главной формы приложения.
        /// </summary>
        public const string MainFormTitle = "Расчёт скидки";

        /// <summary>
        /// Сообщение об отсутствии выбранных стратегий скидки.
        /// </summary>
        public const string NoStrategySelected =
            "Выберите хотя бы одну стратегию скидки.";
    }
}
