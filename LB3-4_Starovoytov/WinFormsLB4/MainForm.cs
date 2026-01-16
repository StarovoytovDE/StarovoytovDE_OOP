using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Model_LB3_4;
using Model_LB3_4.Discounts;

namespace WinFormsLB4
{
    /// <summary>
    /// Главная форма приложения расчёта скидок.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Минимально допустимое значение процента скидки.
        /// </summary>
        public static readonly decimal MinPercentage = 0m;

        /// <summary>
        /// Максимально допустимое значение процента скидки.
        /// </summary>
        public static readonly decimal MaxPercentage = 100m;

        /// <summary>
        /// Уникальное расширение файлов расчётов.
        /// </summary>
        private const string FileExtension = "discounts";
        private readonly List<DiscountCalculation> _allCalculations = new List<DiscountCalculation>();
        private readonly BindingList<DiscountCalculation> _displayedCalculations = new BindingList<DiscountCalculation>();
        private readonly Random _random = new Random();
        private SearchCriteria _currentCriteria;
        private bool _isFiltered;

        /// <summary>
        /// Создаёт главную форму.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ConfigureGrid();
            WireHandlers();
            dataGridView1.DataSource = _displayedCalculations;
        }

        /// <summary>
        /// Переподписывает обработчики событий кнопок и меню.
        /// </summary>
        private void WireHandlers()
        {
            AddButton.Click -= AddButton_Click;
            AddButton.Click += AddButton_Clicked;
            DeleteButton.Click -= DeleteButton_Click;
            DeleteButton.Click += DeleteButton_Clicked;
            RandomButton.Click -= RandomButton_Click;
            RandomButton.Click += RandomButton_Clicked;
            DeleteAllButton.Click -= DeleteAllButton_Click;
            DeleteAllButton.Click += DeleteAllButton_Clicked;
            FindButton.Click -= FindButton_Click;
            FindButton.Click += FindButton_Clicked;
            FilterResetButton.Click -= FilterResetButton_Click;
            FilterResetButton.Click += FilterResetButton_Clicked;
        }

        /// <summary>
        /// Настраивает колонки таблицы с форматированием.
        /// </summary>
        private void ConfigureGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(CreateTextColumn("PurchaseAmount", "Сумма покупки", "N2"));
            dataGridView1.Columns.Add(CreateTextColumn("StrategyDisplay", "Стратегия", null));
            dataGridView1.Columns.Add(CreateTextColumn("DiscountValue", "Величина скидки", "N2"));
            dataGridView1.Columns.Add(CreateTextColumn("Discount", "Сумма скидки", "N2"));
            dataGridView1.Columns.Add(CreateTextColumn("FinalPrice", "К оплате", "N2"));
        }

        /// <summary>
        /// Создаёт текстовую колонку таблицы.
        /// </summary>
        private static DataGridViewTextBoxColumn CreateTextColumn(string dataPropertyName, string headerText, string format)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                HeaderText = headerText,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.DefaultCellStyle.Format = format;
            }

            return column;
        }

        /// <summary>
        /// Обработчик добавления нового расчёта.
        /// </summary>
        private void AddButton_Clicked(object sender, EventArgs e)
        {
            using (var form = new AddForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.Calculation != null)
                {
                    _allCalculations.Add(form.Calculation);
                    RefreshAfterChange();
                }
            }
        }
        
        /// <summary>
        /// Обработчик удаления выбранного расчёта.
        /// </summary>
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Выберите строку для удаления.", 
                    "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = dataGridView1.SelectedRows[0].DataBoundItem as DiscountCalculation;
            if (item == null)
            {
                return;
            }

            _allCalculations.Remove(item);
            RefreshAfterChange();
        }
        
        /// <summary>
        /// Обработчик добавления случайного расчёта.
        /// </summary>
        private void RandomButton_Clicked(object sender, EventArgs e)
        {
            var purchaseAmount = _random.Next(1, 1_000_001);
            var strategyKind = _random.Next(0, 2) == 0
                ? DiscountStrategyKind.Percent
                : DiscountStrategyKind.Certificate;

            decimal discountValue;
            if (strategyKind == DiscountStrategyKind.Percent)
            {
                discountValue = _random.Next(1, 100);
            }
            else
            {
                discountValue = _random.Next(1, purchaseAmount + 1);
            }

            try
            {
                var calculation = CreateCalculation(purchaseAmount, strategyKind, discountValue);
                _allCalculations.Add(calculation);
                RefreshAfterChange();
            }
            catch (IncorrectArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Обработчик очистки всех расчётов.
        /// </summary>
        private void DeleteAllButton_Clicked(object sender, EventArgs e)
        {
            if (_allCalculations.Count == 0)
            {
                return;
            }

            var result = MessageBox.Show(this, "Очистить список расчётов?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            _allCalculations.Clear();
            _isFiltered = false;
            _currentCriteria = null;
            RefreshDisplay(_allCalculations);
        }

        /// <summary>
        /// Обработчик открытия формы поиска.
        /// </summary>
        private void FindButton_Clicked(object sender, EventArgs e)
        {
            using (var form = new FindForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.Criteria != null)
                {
                    _currentCriteria = form.Criteria;
                    _isFiltered = true;
                    ApplyFilter();
                }
            }
        }

        /// <summary>
        /// Обработчик сброса фильтра.
        /// </summary>
        private void FilterResetButton_Clicked(object sender, EventArgs e)
        {
            _isFiltered = false;
            _currentCriteria = null;
            RefreshDisplay(_allCalculations);
        }

        /// <summary>
        /// Обработчик сохранения списка расчётов.
        /// </summary>
        private void ToolStripSaveMenuItem_Click_1(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = $"Discount files (*.{FileExtension})|*.{FileExtension}|All files (*.*)|*.*";
                dialog.DefaultExt = FileExtension;
                dialog.AddExtension = true;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (var stream = File.Create(dialog.FileName))
                    {
                        var formatter = new BinaryFormatter();
                        formatter.Serialize(stream, _allCalculations);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Ошибка сохранения: {ex.Message}", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик загрузки списка расчётов.
        /// </summary>
        private void ToolStripLoadMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = $"Discount files (*.{FileExtension})|*.{FileExtension}|All files (*.*)|*.*";

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (var stream = File.OpenRead(dialog.FileName))
                    {
                        var formatter = new BinaryFormatter();
                        var loaded = (List<DiscountCalculation>)formatter.Deserialize(stream);
                        _allCalculations.Clear();
                        _allCalculations.AddRange(loaded);
                    }

                    _isFiltered = false;
                    _currentCriteria = null;
                    RefreshDisplay(_allCalculations);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Ошибка загрузки: {ex.Message}", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обновляет отображение после изменений.
        /// </summary>
        private void RefreshAfterChange()
        {
            if (_isFiltered && _currentCriteria != null)
            {
                ApplyFilter();
            }
            else
            {
                RefreshDisplay(_allCalculations);
            }
        }

        /// <summary>
        /// Применяет фильтр к списку расчётов.
        /// </summary>
        private void ApplyFilter()
        {
            if (_currentCriteria == null)
            {
                RefreshDisplay(_allCalculations);
                return;
            }

            var filtered = _allCalculations
                .Where(item => MatchesCriteria(item, _currentCriteria))
                .ToList();
            RefreshDisplay(filtered);
        }

        /// <summary>
        /// Проверяет соответствие расчёта критериям фильтра.
        /// </summary>
        private static bool MatchesCriteria(DiscountCalculation item, SearchCriteria criteria)
        {
            if (criteria.StrategyFilter == StrategyFilterKind.Percent && item.StrategyKind != DiscountStrategyKind.Percent)
            {
                return false;
            }

            if (criteria.StrategyFilter == StrategyFilterKind.Certificate && item.StrategyKind != DiscountStrategyKind.Certificate)
            {
                return false;
            }

            if (!IsWithinRange(item.PurchaseAmount, criteria.PurchaseAmountFrom, criteria.PurchaseAmountTo))
            {
                return false;
            }

            if (!IsWithinRange(item.FinalPrice, criteria.FinalPriceFrom, criteria.FinalPriceTo))
            {
                return false;
            }

            if (item.StrategyKind == DiscountStrategyKind.Percent)
            {
                if (!IsWithinRange(item.DiscountValue, criteria.PercentageFrom, criteria.PercentageTo))
                {
                    return false;
                }
            }

            if (item.StrategyKind == DiscountStrategyKind.Certificate)
            {
                if (!IsWithinRange(item.DiscountValue, criteria.CertificateValueFrom, criteria.CertificateValueTo))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Проверяет, что значение входит в диапазон.
        /// </summary>
        private static bool IsWithinRange(decimal value, decimal? from, decimal? to)
        {
            if (from.HasValue && value < from.Value)
            {
                return false;
            }

            if (to.HasValue && value > to.Value)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обновляет отображаемый список расчётов.
        /// </summary>
        private void RefreshDisplay(IEnumerable<DiscountCalculation> calculations)
        {
            _displayedCalculations.Clear();
            foreach (var item in calculations)
            {
                _displayedCalculations.Add(item);
            }
        }

        /// <summary>
        /// Создаёт расчёт скидки по выбранной стратегии.
        /// </summary>
        private DiscountCalculation CreateCalculation(decimal purchaseAmount, DiscountStrategyKind strategyKind, decimal discountValue)
        {
            DiscountStrategy strategy = strategyKind == DiscountStrategyKind.Percent
                ? (DiscountStrategy)new PercentageDiscount(discountValue)
                : new CertificateDiscount(discountValue);

            var discount = strategy.CalculateDiscount(purchaseAmount);
            var finalPrice = strategy.CalculatePrice(purchaseAmount);
            return new DiscountCalculation(purchaseAmount, strategyKind, discountValue, discount, finalPrice);
        }
    }
}
