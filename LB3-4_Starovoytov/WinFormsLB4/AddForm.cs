using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model_LB3_4;
using Model_LB3_4.Discounts;

namespace WinFormsLB4
{
    /// <summary>
    /// Форма добавления нового расчёта скидки.
    /// </summary>
    public partial class AddForm : Form
    {
        /// <summary>
        /// Создаёт форму добавления.
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
            AddStategyBox.Items.AddRange(new object[]
            {
                "Процентная",
                "Сертификат"
            });
            AddStategyBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Созданный расчёт скидки после подтверждения.
        /// </summary>
        public DiscountCalculation Calculation { get; private set; }

        /// <summary>
        /// Обработчик подтверждения добавления расчёта.
        /// </summary>
        private void AddApproveFigureButton_Click(object sender, EventArgs e)
        {
            if (!TryParseDecimal(SummTextbox.Text, out var purchaseAmount) || purchaseAmount <= 0)
            {
                ShowError("Сумма покупки должна быть положительным числом.");
                return;
            }

            if (!TryParseDecimal(DiscountValueTextBox.Text, out var discountValue) || discountValue <= 0)
            {
                ShowError("Величина скидки должна быть положительным числом.");
                return;
            }

            var strategyKind = AddStategyBox.SelectedIndex == 0
                ? DiscountStrategyKind.Percent
                : DiscountStrategyKind.Certificate;

            if (strategyKind == DiscountStrategyKind.Percent && discountValue > 100m)
            {
                ShowError("Процент скидки должен быть не больше 100.");
                return;
            }

            if (strategyKind == DiscountStrategyKind.Certificate && discountValue > purchaseAmount)
            {
                ShowError("Номинал сертификата не может превышать сумму покупки.");
                return;
            }

            try
            {
                DiscountStrategy strategy = strategyKind == DiscountStrategyKind.Percent
                    ? (DiscountStrategy)new PercentageDiscount(discountValue)
                    : new CertificateDiscount(discountValue);

                var discount = strategy.CalculateDiscount(purchaseAmount);
                var finalPrice = strategy.CalculatePrice(purchaseAmount);

                Calculation = new DiscountCalculation(purchaseAmount, strategyKind, discountValue, discount, finalPrice);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (IncorrectArgumentException ex)
            {
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик отмены добавления.
        /// </summary>
        private void AddCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Парсит decimal-значение.
        /// </summary>
        private static bool TryParseDecimal(string input, out decimal value)
        {
            return decimal.TryParse(input, out value);
        }

        /// <summary>
        /// Показывает пользователю сообщение об ошибке.
        /// </summary>
        private void ShowError(string message)
        {
            MessageBox.Show(this, message, "Ошибка ввода", MessageBoxButtons.OK, 
                                                        MessageBoxIcon.Warning);
        }
    }
}
