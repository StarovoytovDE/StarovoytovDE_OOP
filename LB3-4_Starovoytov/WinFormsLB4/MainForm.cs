using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Model_LB3_4;

namespace WinFormsLB4
{
    /// <summary>
    /// Главная форма приложения расчёта скидок.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Расширение файла для сохранения и загрузки данных о расчётах скидок.
        /// </summary>
        private const string FileExtension = "discounts";

        /// <summary>
        /// Полный список всех выполненных расчётов скидок.
        /// </summary>
        private readonly List<DiscountCalculation> _allCalculations =
            new List<DiscountCalculation>();

        /// <summary>
        /// Список расчётов скидок, отображаемых в пользовательском интерфейсе
        /// с учётом текущей фильтрации.
        /// </summary>
        private readonly BindingList<DiscountCalculation> _displayedCalculations =
            new BindingList<DiscountCalculation>();
#if DEBUG
        /// <summary>
        /// Генератор случайных значений, используемый для создания тестовых данных.
        /// </summary>
        private readonly Random _random = new Random();
#endif
        /// <summary>
        /// Текущие критерии поиска и фильтрации расчётов скидок.
        /// </summary>
        private SearchCriteria _currentCriteria;

        /// <summary>
        /// Флаг, указывающий, применена ли в данный момент фильтрация списка расчётов.
        /// </summary>
        private bool _isFiltered;


        /// <summary>
        /// Создаёт главную форму.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Text = UiText.MainFormTitle;

            ConfigureGrid();
            dataGridViewMainForm.DataSource = _displayedCalculations;
#if DEBUG
                        ApplyBuildConfigurationUi();
#endif
        }

        /// <summary>
        /// Скрывает кнопку генерации случайного расчёта в Release.
        /// </summary>
        private void ApplyBuildConfigurationUi()
        {
#if DEBUG
            RandomButton.Visible = true;
#else
            RandomButton.Visible = false;
#endif
        }

        /// <summary>
        /// Настраивает колонки таблицы с форматированием.
        /// </summary>
        private void ConfigureGrid()
        {
            dataGridViewMainForm.AutoGenerateColumns = false;
            dataGridViewMainForm.Columns.Clear();

            dataGridViewMainForm.Columns.Add(CreateTextColumn(
                "PurchaseAmount", 
                "Сумма покупки", 
                "N2"));
            dataGridViewMainForm.Columns.Add(CreateTextColumn(
                "StrategyDisplay", 
                "Стратегия", 
                null));
            dataGridViewMainForm.Columns.Add(CreateTextColumn(
                "DiscountValue", 
                "Величина скидки", 
                "N2"));
            dataGridViewMainForm.Columns.Add(CreateTextColumn(
                "Discount", 
                "Сумма скидки", 
                "N2"));
            dataGridViewMainForm.Columns.Add(CreateTextColumn(
                "FinalPrice", 
                "К оплате", 
                "N2"));

            dataGridViewMainForm.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewMainForm.MultiSelect = true;

            dataGridViewMainForm.AllowUserToAddRows = false;
            dataGridViewMainForm.AllowUserToDeleteRows = false;
            dataGridViewMainForm.AllowUserToResizeRows = false;
        }

        /// <summary>
        /// Создаёт текстовую колонку таблицы.
        /// </summary>
        private static DataGridViewTextBoxColumn CreateTextColumn(
            string dataPropertyName, 
            string headerText, 
            string format)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                HeaderText = headerText,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
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
                if (form.ShowDialog(this) == DialogResult.OK 
                    && form.Calculation != null)
                {
                    _allCalculations.Add(form.Calculation);
                    RefreshAfterChange();
                }
            }
        }

        /// <summary>
        /// Обработчик удаления выбранных расчётов 
        /// (поддерживает множественное выделение).
        /// </summary>
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (dataGridViewMainForm.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, 
                                UiText.SelectRowToDelete, 
                                UiText.DeleteTitle, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);

                return;
            }

            var toRemove = new List<DiscountCalculation>();

            foreach (DataGridViewRow row in dataGridViewMainForm.SelectedRows)
            {
                var item = row.DataBoundItem as DiscountCalculation;
                if (item != null)
                {
                    toRemove.Add(item);
                }
            }

            if (toRemove.Count == 0)
            {
                return;
            }

            // Запоминаем состояние ДО удаления:
            // если фильтр активен и сейчас удаляют ВСЕ отображаемые элементы
            // — после удаления сбросим фильтр.
            bool isFilterActive = _isFiltered && _currentCriteria != null;
            int displayedCountBeforeDelete = _displayedCalculations.Count;

            // Удаляем выбранные элементы из общего списка.
            foreach (var item in toRemove)
            {
                _allCalculations.Remove(item);
            }

            // Если в результате удаления данных вообще не осталось
            // — фильтр тоже должен быть выключен.
            if (_allCalculations.Count == 0)
            {
                _isFiltered = false;
                _currentCriteria = null;
                RefreshDisplay(_allCalculations);
                return;
            }

            // Если фильтр был активен и удалили все элементы,
            // которые были отображены — сбрасываем фильтрацию.
            if (isFilterActive && toRemove.Count == displayedCountBeforeDelete)
            {
                _isFiltered = false;
                _currentCriteria = null;
                RefreshDisplay(_allCalculations);
                return;
            }

            RefreshAfterChange();
        }
#if DEBUG
        /// <summary>
        /// Обработчик добавления случайного расчёта (только Debug, в Release кнопка скрыта).
        /// </summary>
        private void RandomButton_Clicked(object sender, EventArgs e)
        {
            var purchaseAmount = _random.Next(UiConstants.RandomPurchaseAmountMin, 
                                              UiConstants.RandomPurchaseAmountMax + 1);

            var strategyKind = _random.Next(0, 2) == 0
                ? DiscountStrategyKind.Percent
                : DiscountStrategyKind.Certificate;

            decimal discountValue;

            if (strategyKind == DiscountStrategyKind.Percent)
            {
                discountValue = _random.Next(UiConstants.RandomPercentMin, 
                                             UiConstants.RandomPercentMax + 1);
            }
            else
            {
                discountValue = _random.Next(1, purchaseAmount + 1);
            }

            try
            {
                var calculation = DiscountCalculationFactory.Create(
                    purchaseAmount, 
                    strategyKind, 
                    discountValue);
                _allCalculations.Add(calculation);
                RefreshAfterChange();
            }
            catch (IncorrectArgumentException ex)
            {
                MessageBox.Show(this,
                                ex.Message,
                                UiText.AppErrorTitle,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
#endif
        /// <summary>
        /// Обработчик очистки расчётов.
        /// Если фильтр активен — очищает только отфильтрованные элементы.
        /// Если фильтр не активен — очищает весь список.
        /// </summary>
        private void DeleteAllButton_Clicked(object sender, EventArgs e)
        {
            if (_isFiltered && _currentCriteria != null)
            {
                // Если фильтр активен — удаляем только то, что сейчас отображается.
                if (_displayedCalculations.Count == 0)
                {
                    return;
                }

                var resultFiltered = MessageBox.Show(
                    this,
                    UiText.ConfirmClearFilteredList,
                    UiText.ConfirmTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultFiltered != DialogResult.Yes)
                {
                    return;
                }

                var toRemove = _displayedCalculations.ToList();

                foreach (var item in toRemove)
                {
                    _allCalculations.Remove(item);
                }

                // Выключаем фильтр
                RefreshDisplay(_allCalculations);
                return;
            }

            // Иначе — очищаем весь список.
            if (_allCalculations.Count == 0)
            {
                return;
            }

            var resultAll = MessageBox.Show(
                this,
                UiText.ConfirmClearList,
                UiText.ConfirmTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultAll != DialogResult.Yes)
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
                if (form.ShowDialog(this) == DialogResult.OK
                   && form.Criteria != null)
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
        private void ToolStripSaveMenuItem_Clicked(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Discount files (*." + FileExtension + ")|*." +
                                        FileExtension + "|All files (*.*)|*.*";
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
                    MessageBox.Show(this,
                                    "Ошибка сохранения: " +
                                    ex.Message, UiText.SaveTitle,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик загрузки списка расчётов.
        /// </summary>
        private void ToolStripLoadMenuItem_Clicked(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                //TOOD: refactor
                dialog.Filter = "Discount files (*." + FileExtension + ")|*." + 
                                        FileExtension + "|All files (*.*)|*.*";

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (var stream = File.OpenRead(dialog.FileName))
                    {
                        var formatter = new BinaryFormatter();
                        var loaded = (
                            List<DiscountCalculation>)formatter.Deserialize(
                                                                    stream);

                        _allCalculations.Clear();
                        _allCalculations.AddRange(loaded);
                    }

                    _isFiltered = false;
                    _currentCriteria = null;
                    RefreshDisplay(_allCalculations);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                                    "Ошибка загрузки: " +
                                    ex.Message,
                                    UiText.LoadTitle,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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
        private static bool MatchesCriteria(DiscountCalculation item, 
                                            SearchCriteria criteria)
        {
            if (criteria == null)
            {
                return true;
            }

            if (!IsStrategyAllowed(item, criteria))
            {
                return false;
            }

            if (!IsWithinRange(item.DiscountValue, 
                               criteria.DiscountValueFrom, 
                               criteria.DiscountValueTo))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет, разрешена ли стратегия расчёта 
        /// согласно выбранным стратегиям в критериях.
        /// </summary>
        private static bool IsStrategyAllowed(
            DiscountCalculation item, 
            SearchCriteria criteria)
        {
            
            if (criteria.StrategyFlags == StrategyFilterFlags.None)
            {
                return false;
            }


            switch (item.StrategyKind)
            {
                //TODO: {}+
                case DiscountStrategyKind.Percent:
                {
                    return criteria.StrategyFlags.HasFlag(
                        StrategyFilterFlags.Percent);
                }

                case DiscountStrategyKind.Certificate:
                {
                    return criteria.StrategyFlags.HasFlag(
                        StrategyFilterFlags.Certificate);
                }

                default:
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Проверяет, что значение входит в диапазон.
        /// </summary>
        private static bool IsWithinRange(
            decimal value,
            decimal? from,
            decimal? to)
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
        private void RefreshDisplay(
            IEnumerable<DiscountCalculation> calculations)
        {
            _displayedCalculations.Clear();

            foreach (var item in calculations)
            {
                _displayedCalculations.Add(item);
            }
        }
    }
}
