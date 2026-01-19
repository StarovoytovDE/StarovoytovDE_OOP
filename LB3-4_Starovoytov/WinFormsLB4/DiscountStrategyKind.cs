using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLB4
{
    /// <summary>
    /// Виды стратегий скидки для расчётов.
    /// </summary>
    public enum DiscountStrategyKind
    {
        /// <summary>
        /// Стратегия процентной скидки.
        /// </summary>
        Percent = 0,

        /// <summary>
        /// Стратегия скидки по сертификату.
        /// </summary>
        Certificate = 1
    }
}
