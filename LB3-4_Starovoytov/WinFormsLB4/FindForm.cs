using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsLB4
{
    /// <summary>
    /// Форма задания критериев поиска расчётов.
    /// </summary>
    public partial class FindForm : Form
    {
        /// <summary>
        /// Создаёт форму поиска.
        /// </summary>
        public FindForm()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new object[]
            {
                "Все стратегии",
                "Процентная",
                "Сертификат"
            });
            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// Критерии поиска, заполненные пользователем.
        /// </summary>
        public SearchCriteria Criteria { get; private set; }

        /// <summary>
        /// Обработчик применения критериев поиска.
        /// </summary>
        private void FindApplyButton_Click(object sender, EventArgs e)
        {
            if (!TryGetOptionalDecimal(SummForTextbox.Text, out var purchaseFrom))
            {
                ShowError("Некорректное значение \"Сумма покупки: От\".");
                return;
            }

            if (!TryGetOptionalDecimal(SummToTextBox.Text, out var purchaseTo))
            {
                ShowError("Некорректное значение \"Сумма покупки: До\".");
                return;
            }

            if (!TryGetOptionalDecimal(textBoxFinalSummFrom.Text, out var finalFrom))
            {
                ShowError("Некорректное значение \"Сумма к оплате: От\".");
                return;
            }

            if (!TryGetOptionalDecimal(textBoxFinalSummTo.Text, out var finalTo))
            {
                ShowError("Некорректное значение \"Сумма к оплате: До\".");
                return;
            }

            if (!TryGetOptionalDecimal(CertificateFromTextBox.Text, out var certificateFrom))
            {
                ShowError("Некорректное значение \"Номинал сертификата: От\".");
                return;
            }

            if (!TryGetOptionalDecimal(CertificateToTextBox1.Text, out var certificateTo))
            {
                ShowError("Некорректное значение \"Номинал сертификата: До\".");
                return;
            }

            if (!TryGetOptionalDecimal(textBoxPercentageFrom.Text, out var percentageFrom))
            {
                ShowError("Некорректное значение \"%: От\".");
                return;
            }

            if (!TryGetOptionalDecimal(textBoxPercentageTo.Text, out var percentageTo))
            {
                ShowError("Некорректное значение \"%: До\".");
                return;
            }

            if (!ValidateRange(purchaseFrom, purchaseTo, "Сумма покупки") ||
                !ValidateRange(finalFrom, finalTo, "Сумма к оплате") ||
                !ValidateRange(certificateFrom, certificateTo, "Номинал сертификата") ||
                !ValidateRange(percentageFrom, percentageTo, "Процент скидки"))
            {
                return;
            }

            Criteria = new SearchCriteria
            {
                StrategyFilter = GetStrategyFilter(),
                PurchaseAmountFrom = purchaseFrom,
                PurchaseAmountTo = purchaseTo,
                FinalPriceFrom = finalFrom,
                FinalPriceTo = finalTo,
                CertificateValueFrom = certificateFrom,
                CertificateValueTo = certificateTo,
                PercentageFrom = percentageFrom,
                PercentageTo = percentageTo
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обработчик отмены поиска.
        /// </summary>
        private void FindRejectButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Получает выбранный режим фильтра стратегии.
        /// </summary>
        private StrategyFilterKind GetStrategyFilter()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    return StrategyFilterKind.Percent;
                case 2:
                    return StrategyFilterKind.Certificate;
                default:
                    return StrategyFilterKind.All;
            }
        }

        /// <summary>
        /// Пытается получить значение decimal, допускает пустое поле.
        /// </summary>
        private static bool TryGetOptionalDecimal(string text, out decimal? value)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                value = null;
                return true;
            }

            if (decimal.TryParse(text, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// Проверяет корректность диапазона значений.
        /// </summary>
        private bool ValidateRange(decimal? from, decimal? to, string label)
        {
            if (from.HasValue && to.HasValue && from.Value > to.Value)
            {
                ShowError($"Диапазон \"{label}\" указан некорректно.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Показывает пользователю сообщение об ошибке.
        /// </summary>
        private void ShowError(string message)
        {
            MessageBox.Show(this, message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
