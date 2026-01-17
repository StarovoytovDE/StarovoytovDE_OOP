using System;

namespace WinFormsLB4
{
    /// <summary>
    /// Флаги фильтрации по стратегиям скидки (можно выбрать одну или обе).
    /// </summary>
    [Flags]
    public enum StrategyFilterFlags
    {
        /// <summary>
        /// Ничего не выбрано.
        /// </summary>
        None = 0,

        /// <summary>
        /// Процентная стратегия.
        /// </summary>
        Percent = 1,

        /// <summary>
        /// Сертификат.
        /// </summary>
        Certificate = 2
    }
}
