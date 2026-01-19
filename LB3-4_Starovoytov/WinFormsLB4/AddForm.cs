using System;
using System.Windows.Forms;
using Model_LB3_4;

namespace WinFormsLB4
{
    /// <summary>
    /// Форма добавления нового расчёта скидки.
    /// Позволяет выбрать стратегию и ввести сумму покупки и параметр стратегии.
    /// </summary>
    public partial class AddForm : Form
    {
        /// <summary>
        /// Индекс стратегии расчёта скидки «Процент» в списке стратегий пользовательского интерфейса.
        /// </summary>
        private const int StrategyIndexPercent = 0;

        //TODO: remove
        /// <summary>
        /// Индекс стратегии расчёта скидки «Сертификат» в списке стратегий пользовательского интерфейса.
        /// </summary>
        private const int StrategyIndexCertificate = 1;

        /// <summary>
        /// Созданный пользователем расчёт скидки.
        /// </summary>
        public DiscountCalculation Calculation { get; private set; }

        /// <summary>
        /// Создаёт форму добавления расчёта.
        /// </summary>
        public AddForm()
        {
            InitializeComponent();

            InitializeStrategyComboBox();
            ApplyStrategyUi();
        }

        /// <summary>
        /// Заполняет список стратегий и устанавливает выбранную стратегию по умолчанию.
        /// </summary>
        private void InitializeStrategyComboBox()
        {
            comboBoxStrategy.Items.Clear();
            comboBoxStrategy.Items.Add(UiText.StrategyPercentUi);
            comboBoxStrategy.Items.Add(UiText.StrategyCertificateUi);
            comboBoxStrategy.SelectedIndex = StrategyIndexPercent;
        }

        /// <summary>
        /// Обработчик изменения выбранной стратегии.
        /// Переключает подпись поля параметра стратегии и очищает ввод.
        /// </summary>
        private void ComboBoxStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyStrategyUi();
            ClearInputFields();
        }

        /// <summary>
        /// Настраивает подписи полей ввода под выбранную стратегию.
        /// </summary>
        private void ApplyStrategyUi()
        {
            labelValue.Text = 
                comboBoxStrategy.SelectedIndex == StrategyIndexPercent 
                ? UiText.LabelPercentValue 
                : UiText.LabelCertificateValue;
        }

        /// <summary>
        /// Очищает поля ввода.
        /// </summary>
        private void ClearInputFields()
        {
            textBoxPurchaseAmount.Clear();
            textBoxValue.Clear();
        }

        /// <summary>
        /// Обработчик нажатия кнопки ОК.
        /// Выполняет валидацию, создаёт расчёт скидки и закрывает форму.
        /// </summary>
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (!TryGetRequiredDecimal(textBoxPurchaseAmount.Text, 
                                        out var purchaseAmount, 
                                        UiText.FieldPurchaseAmount))
            {
                return;
            }

            if (!TryGetRequiredDecimal(textBoxValue.Text, 
                                        out var value, 
                                        UiText.FieldDiscountValue))
            {
                return;
            }

            var strategyKind = GetSelectedStrategyKind();

            if (!ValidateStrategyValue(strategyKind, purchaseAmount, value))
            {
                return;
            }

            try
            {
                Calculation = DiscountCalculationFactory.Create(purchaseAmount, 
                                                                strategyKind, 
                                                                value);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (IncorrectArgumentException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ShowError("Ошибка создания расчёта: " + ex.Message);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Отмена.
        /// Закрывает форму без создания расчёта.
        /// </summary>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Определяет выбранный тип стратегии скидки.
        /// </summary>
        private DiscountStrategyKind GetSelectedStrategyKind()
        {
            return comboBoxStrategy.SelectedIndex == StrategyIndexPercent
                ? DiscountStrategyKind.Percent
                : DiscountStrategyKind.Certificate;
        }

        /// <summary>
        /// Проверяет корректность параметров расчёта в зависимости от выбранной стратегии.
        /// </summary>
        private bool ValidateStrategyValue(
            DiscountStrategyKind strategyKind, 
            decimal purchaseAmount, 
            decimal value)
        {
            if (purchaseAmount < 0m)
            {
                ShowError("Сумма покупки не может быть отрицательной.");
                return false;
            }
            switch (strategyKind)
            {
                case DiscountStrategyKind.Percent:
                {
                    if (value < UiConstants.PercentageMin
                        || value > UiConstants.PercentageMax)
                    {
                        ShowError(
                            $"Процент скидки должен быть в диапазоне " +
                            $"от {UiConstants.PercentageMin} " +
                            $"до {UiConstants.PercentageMax}.");
                        return false;
                    }

                    return true;
                }

                case DiscountStrategyKind.Certificate:
                {
                    if (value < 0m)
                    {
                        ShowError("Сумма сертификата не может быть отрицательной.");
                        return false;
                    }

                    if (value < UiConstants.CertificateAmountMin
                        || value > UiConstants.CertificateAmountMax)
                    {
                        ShowError($"Сумма сертификата должна быть в диапазоне " +
                                            $"от {UiConstants.CertificateAmountMin} " +
                                            $"до {UiConstants.CertificateAmountMax}.");
                        return false;
                    }

                    if (value > purchaseAmount)
                    {
                        ShowError("Сумма сертификата не может превышать сумму покупки.");
                        return false;
                    }

                    return true;
                }

            default:
                {
                    ShowError("Выбрана неизвестная стратегия скидки.");
                        return false;
                }
            }
        }

        /// <summary>
        /// Ограничивает ввод в числовые поля.
        /// Разрешает цифры, запятую, точку и Backspace.
        /// </summary>
        private void NumericTextboxKeyPress(object sender, KeyPressEventArgs e)
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
        /// Пытается получить обязательное значение decimal из строки.
        /// </summary>
        private bool TryGetRequiredDecimal(string text, out decimal value, string fieldName)
        {
            value = 0m;

            var normalized = (text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(normalized))
            {
                ShowError($"Поле \"{fieldName}\" должно быть заполнено.");
                return false;
            }

            normalized = normalized.Replace('.', ',');

            if (!decimal.TryParse(normalized, out value))
            {
                ShowError($"Поле \"{fieldName}\" заполнено некорректно.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Показывает пользователю сообщение об ошибке ввода.
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
