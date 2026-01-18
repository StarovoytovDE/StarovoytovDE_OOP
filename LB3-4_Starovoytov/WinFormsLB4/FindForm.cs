using System;
using System.Windows.Forms;

namespace WinFormsLB4
{
    /// <summary>
    /// Форма задания критериев поиска расчётов.
    /// </summary>
    public partial class FindForm : Form
    {
        /// <summary>
        /// Критерии поиска, заполненные пользователем.
        /// </summary>
        public SearchCriteria Criteria { get; private set; }

        /// <summary>
        /// Создаёт форму поиска.
        /// </summary>
        public FindForm()
        {
            InitializeComponent();

            checkBoxPercent.Checked = true;
            checkBoxCertificate.Checked = true;
            Text = UiText.FindFormTitle;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Найти".
        /// </summary>
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            var flags = GetStrategyFlags();
            if (flags == StrategyFilterFlags.None)
            {
                ShowError(UiText.NoStrategySelected);
                return;
            }

            if (!TryGetOptionalDecimal(textBoxPurchaseFrom.Text, 
                out var purchaseFrom))
            {
                ShowError($"Некорректное значение " +
                    $"\"{UiText.FieldPurchaseAmount}: От\".");
                return;
            }

            if (!TryGetOptionalDecimal(textBoxPurchaseTo.Text, 
                out var purchaseTo))
            {
                ShowError($"Некорректное значение " +
                    $"\"{UiText.FieldPurchaseAmount}: До\".");
                return;
            }

            if (!TryGetOptionalDecimal(textBoxDiscountFrom.Text, 
                out var discountFrom))
            {
                ShowError($"Некорректное значение " +
                    $"\"{UiText.FieldDiscountValue}: От\".");
                return;
            }

            if (!TryGetOptionalDecimal(textBoxDiscountTo.Text, 
                out var discountTo))
            {
                ShowError($"Некорректное значение " +
                    $"\"{UiText.FieldDiscountValue}: До\".");
                return;
            }
            //TODO: RSDN+
            if (!ValidateNonNegative(
                purchaseFrom, 
                purchaseTo, 
                UiText.FieldPurchaseAmount)
                || !ValidateNonNegative(
                   discountFrom, 
                   discountTo, 
                   UiText.FieldDiscountValue))
            {
                return;
            }

            //TODO: RSDN+
            if (!ValidateRange(
                purchaseFrom, 
                purchaseTo, 
                UiText.FieldPurchaseAmount)
                || !ValidateRange(
                    discountFrom, 
                    discountTo, 
                    UiText.FieldDiscountValue))
            {
                return;
            }

            Criteria = new SearchCriteria
            {
                StrategyFlags = flags,
                PurchaseAmountFrom = purchaseFrom,
                PurchaseAmountTo = purchaseTo,
                DiscountValueFrom = discountFrom,
                DiscountValueTo = discountTo
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена".
        /// </summary>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Ограничивает ввод в числовые поля.
        /// Разрешает цифры, запятую, точку и Backspace.
        /// </summary>
        private void NumericTextboxKeyPress(
            object sender, 
            KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                return;
            }

            e.Handled = true;
        }

        /// <summary>
        /// Получает выбранные стратегии скидки в виде флагов.
        /// </summary>
        private StrategyFilterFlags GetStrategyFlags()
        {
            var flags = StrategyFilterFlags.None;

            if (checkBoxPercent.Checked)
            {
                flags |= StrategyFilterFlags.Percent;
            }

            if (checkBoxCertificate.Checked)
            {
                flags |= StrategyFilterFlags.Certificate;
            }

            return flags;
        }

        /// <summary>
        /// Пытается получить значение decimal, допускает пустое поле.
        /// </summary>
        private static bool TryGetOptionalDecimal(
            string text, 
            out decimal? value)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                value = null;
                return true;
            }

            var normalized = text.Trim().Replace('.', ',');

            if (decimal.TryParse(normalized, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// Проверяет, что значения диапазона неотрицательны (если заданы).
        /// </summary>
        private bool ValidateNonNegative(
            decimal? from, 
            decimal? to, 
            string fieldName)
        {
            if (from.HasValue && from.Value < 0m)
            {
                ShowError($"Поле \"{fieldName}: " +
                    $"От\" не может быть отрицательным.");
                return false;
            }

            if (to.HasValue && to.Value < 0m)
            {
                ShowError($"Поле \"{fieldName}: " +
                    $"До\" не может быть отрицательным.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет корректность диапазона значений (from <= to).
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
            MessageBox.Show(this, 
                            message, 
                            UiText.InputErrorTitle, 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
        }
    }
}
