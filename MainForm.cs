using CourseWork.Source.Entities;
using CourseWork.Source.Services;
using System.Windows.Forms;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data;

namespace CourseWork
{
    public partial class MainForm : Form
    {
        private CriticService _criticService;
        private PoetService _poetService;
        private PoemService _poemService;
        private DataGridViewRow _choosenPoet;
        private DataGridViewRow _choosenCritic;

        /// <summary>
        /// Конструктор MainForm. Инициализация компонентов и сервисов.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _criticService = new CriticService();
            _poetService = new PoetService();
            _poemService = new PoemService();
            LoadPoetsDataGrid();
            LoadCriticDataGrid();
            LoadPoemDataGrid();
            FormatDataGrids();
        }

        #region DataGrid Methods

        /// <summary>
        /// Форматирование таблиц данных.
        /// </summary>
        private void FormatDataGrids()
        {
            var SetAutoSizeToDataGrid = (DataGridView dataGrid) =>
            {
                foreach (DataGridViewColumn column in dataGrid.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
            SetAutoSizeToDataGrid(PoetsDataGrid);
            SetAutoSizeToDataGrid(CriticsDataGrid);
            SetAutoSizeToDataGrid(PoemDataGrid);

            PoemDataGrid.Columns[PoemService.ColumnMapping["UploadedDate"]].DefaultCellStyle.Format = "dd-MM-yyyy";
            PoemDataGrid.Columns[PoemService.ColumnMapping["UploadedTime"]].DefaultCellStyle.Format = "HH:mm";
            PoetsDataGrid.Columns[PoetService.ColumnMapping["DateOfBirth"]].DefaultCellStyle.Format = "dd-MM-yyyy";
            CriticsDataGrid.Columns[CriticService.ColumnMapping["DateOfBirth"]].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        /// <summary>
        /// Возвращает выбранную строку в таблице.
        /// </summary>
        /// <param name="dataGrid">Таблица данных.</param>
        /// <returns>Выбранная строка.</returns>
        private DataGridViewRow GetSelectedRowFromDataGrid(DataGridView dataGrid)
        {
            if (dataGrid.SelectedRows.Count == 0 || dataGrid.SelectedRows is null) return null;
            return dataGrid.SelectedRows[0];
        }

        /// <summary>
        /// Заменяет строку в таблице.
        /// </summary>
        /// <param name="dataGrid">Таблица данных.</param>
        /// <param name="rowToReplaceIndex">Индекс заменяемой строки.</param>
        /// <param name="columnValuePairs">Значения колонок для замены.</param>
        private void ReplaceRowInDataGrid(DataGridView dataGrid, int rowToReplaceIndex, Dictionary<string, string> columnValuePairs)
        {
            var dataTable = (DataTable)dataGrid.DataSource;
            var row = dataTable.NewRow();
            foreach (KeyValuePair<string, string> cvp in columnValuePairs)
            {
                row[cvp.Key] = cvp.Value;
            }
            dataTable.Rows.RemoveAt(rowToReplaceIndex);
            dataTable.Rows.InsertAt(row, rowToReplaceIndex);
            dataGrid.Refresh();
        }

        /// <summary>
        /// Добавляет строку в таблицу.
        /// </summary>
        /// <param name="dataGrid">Таблица данных.</param>
        /// <param name="columnValuePairs">Значения колонок для добавления.</param>
        private void AddRowToDataGrid(DataGridView dataGrid, Dictionary<string, string> columnValuePairs)
        {
            var dataTable = (DataTable)dataGrid.DataSource;
            var row = dataTable.NewRow();
            foreach (KeyValuePair<string, string> cvp in columnValuePairs)
            {
                row[cvp.Key] = cvp.Value;
            }
            dataTable.Rows.Add(row);
            dataGrid.Refresh();
        }

        /// <summary>
        /// Отображает строки с ключевым словом.
        /// </summary>
        /// <param name="dataGridView">Таблица данных.</param>
        /// <param name="keyword">Ключевое слово для поиска.</param>
        private void ShowRowsWithKeyword(DataGridView dataGridView, string keyword)
        {
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView.DataSource];
            currencyManager.SuspendBinding();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool keywordFound = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Contains(keyword))
                    {
                        keywordFound = true;
                        break;
                    }
                }
                row.Visible = keywordFound;
            }
            dataGridView.Refresh();
            currencyManager.ResumeBinding();
        }

        #endregion

        #region Form Methods

        /// <summary>
        /// Проверка введенных данных.
        /// </summary>
        /// <param name="input">Элемент управления.</param>
        /// <param name="RegexGen">Функция для генерации регулярного выражения.</param>
        /// <param name="RequirementsGen">Функция для получения требований.</param>
        /// <returns>True, если данные корректны.</returns>
        private bool CheckInput(Control input, Func<Regex> RegexGen, Func<string> RequirementsGen)
        {
            if (!RegexGen().IsMatch(input.Text))
            {
                errorProvider.SetError(input, RequirementsGen());
                return false;
            }
            else
            {
                errorProvider.SetError(input, "");
                return true;
            }
        }

        /// <summary>
        /// Обработчик смены вкладки в TabControl.
        /// </summary>
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab == PoemPage)
            {
                ChoosenPoetLabel.Text = _choosenPoet != null ?
                    $"поэт: {_choosenPoet.Cells[PoetService.ColumnMapping["FirstName"]].Value} {_choosenPoet.Cells[PoetService.ColumnMapping["LastName"]].Value}" :
                    "поэт не выбран";
                ChoosenCriticLabel.Text = _choosenCritic != null ?
                    $"критик: {_choosenCritic.Cells[CriticService.ColumnMapping["FirstName"]].Value} {_choosenCritic.Cells[CriticService.ColumnMapping["LastName"]].Value}" :
                    "критик не выбран";
            }
        }

        #endregion

        #region Poet Page

        /// <summary>
        /// Удаление поэта.
        /// </summary>
        private void DeletePoetBtn_Click(object sender, EventArgs e)
        {
            if (_choosenPoet == null)
            {
                MessageBox.Show("Выберите поэта для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string phoneNumber = _choosenPoet.Cells[PoetService.ColumnMapping["PhoneNumber"]].Value.ToString();
            try
            {
                _poetService.Delete(phoneNumber);
                PoetsDataGrid.Rows.Remove(_choosenPoet);
                _choosenPoet = null;
                ClearPoetsInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавление поэта.
        /// </summary>
        private void AddPoetBtn_Click(object sender, EventArgs e)
        {
            bool isFirstNameValid = CheckInput(PoetFirstNameInput, PoetService.RegexFirstName, PoetService.GetRequirementsForFirstName);
            bool isLastNameValid = CheckInput(PoetLastNameInput, PoetService.RegexLastName, PoetService.GetRequirementsForLastName);
            bool isPhoneNumberValid = CheckInput(PoetPhoneNumberInput, PoetService.RegexPhoneNumber, PoetService.GetRequirementsForPhoneNumber);

            if (!isFirstNameValid || !isLastNameValid || !isPhoneNumberValid) return;

            Person poet = new Person()
            {
                Role = Person.Roles.Poet,
                FirstName = PoetFirstNameInput.Text,
                LastName = PoetLastNameInput.Text,
                PhoneNumber = PoetPhoneNumberInput.Text,
                DateOfBirth = PoetDateOfBirthInput.Value
            };

            try
            {
                _poetService.Save(poet);
                AddRowToDataGrid(PoetsDataGrid, _poetService.LoadFields(poet.PhoneNumber));
                ClearPoetsInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление данных поэта.
        /// </summary>
        private void UpdatePoetBtn_Click(object sender, EventArgs e)
        {
            if (_choosenPoet == null)
            {
                MessageBox.Show("Выберите поэта для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool isFirstNameValid = CheckInput(PoetFirstNameInput, PoetService.RegexFirstName, PoetService.GetRequirementsForFirstName);
            bool isLastNameValid = CheckInput(PoetLastNameInput, PoetService.RegexLastName, PoetService.GetRequirementsForLastName);

            if (!isFirstNameValid || !isLastNameValid) return;

            string phoneNumber = _choosenPoet.Cells[PoetService.ColumnMapping["PhoneNumber"]].Value.ToString();
            try
            {
                Person poet = _poetService.GetByPhoneNumber(phoneNumber);
                poet.FirstName = PoetFirstNameInput.Text;
                poet.LastName = PoetLastNameInput.Text;
                poet.DateOfBirth = PoetDateOfBirthInput.Value;
                _poetService.Update(poet);
                ReplaceRowInDataGrid(PoetsDataGrid, _choosenPoet.Index, _poetService.LoadFields(poet.PhoneNumber));
                ClearPoetsInputs();
                _choosenPoet = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработка двойного клика в таблице поэтов.
        /// </summary>
        private void DataGridPoets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearPoetsInputs();
            _choosenPoet = GetSelectedRowFromDataGrid(PoetsDataGrid);
            PoetPhoneNumberInput.Text = _choosenPoet.Cells[PoetService.ColumnMapping["PhoneNumber"]].Value.ToString();
            PoetFirstNameInput.Text = _choosenPoet.Cells[PoetService.ColumnMapping["FirstName"]].Value.ToString();
            PoetLastNameInput.Text = _choosenПоет.Cells[PoetService.ColumnMapping["LastName"]].Value.ToString();
            PoetDateOfBirthInput.Value = DateTime.Parse(_choosenPoet.Cells[PoetService.ColumnMapping["DateOfBirth"]].Value.ToString());
            PoetPhoneNumberInput.ReadOnly = true;
        }

        /// <summary>
        /// Поиск поэтов.
        /// </summary>
        private void PoetSearchBtn_Click(object sender, EventArgs e)
        {
            ShowRowsWithKeyword(PoetsDataGrid, PoetSearchInput.Text);
        }

        /// <summary>
        /// Очистить поля ввода поэтов.
        /// </summary>
        private void ClearPoetsInputs()
        {
            PoetFirstNameInput.Text = "";
            PoetLastNameInput.Text = "";
            PoetPhoneNumberInput.Text = "";
            PoetDateOfBirthInput.Value = PoetDateOfBirthInput.MinDate;
            PoetPhoneNumberInput.ReadOnly = false;
            errorProvider.SetError(PoetFirstNameInput, "");
            errorProvider.SetError(PoetLastNameInput, "");
            errorProvider.SetError(PoetPhoneNumberInput, "");
        }

        /// <summary>
        /// Очистить поля поэтов по кнопке.
        /// </summary>
        private void ClearPoetInputsBtn_Click(object sender, EventArgs e)
        {
            ClearPoetsInputs();
        }

        /// <summary>
        /// Удалить всех поэтов.
        /// </summary>
        private void DeleteAllPoetsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _poetService.DeleteAll();
                LoadPoetsDataGrid();
                ClearPoetsInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загрузить таблицу поэтов.
        /// </summary>
        private void LoadPoetsDataGrid()
        {
            PoetsDataGrid.DataSource = _poetService.GetDataTableOfAll();
        }

        #endregion

        #region Critic Page

        /// <summary>
        /// Удалить критика.
        /// </summary>
        private void DeleteCriticBtn_Click(object sender, EventArgs e)
        {
            if (_choosenCritic == null)
            {
                MessageBox.Show("Выберите критика для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string phoneNumber = _choosenCritic.Cells[CriticService.ColumnMapping["PhoneNumber"]].Value.ToString();
            try
            {
                _criticService.Delete(phoneNumber);
                CriticsDataGrid.Rows.Remove(_choosenCritic);
                _choosenCritic = null;
                ClearCriticsInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавить критика.
        /// </summary>
        private void AddCriticBtn_Click(object sender, EventArgs e)
        {
            bool isFirstNameValid = CheckInput(CriticFirstNameInput, CriticService.RegexFirstName, CriticService.GetRequirementsForFirstName);
            bool isLastNameValid = CheckInput(CriticLastNameInput, CriticService.RegexLastName, CriticService.GetRequirementsForLastName);
            bool isPhoneNumberValid = CheckInput(CriticPhoneNumberInput, CriticService.RegexPhoneNumber, CriticService.GetRequirementsForPhoneNumber);

            if (!isFirstNameValid || !isLastNameValid || !isPhoneNumberValid) return;

            Person critic = new Person()
            {
                Role = Person.Roles.Critic,
                FirstName = CriticFirstNameInput.Text,
                LastName = CriticLastNameInput.Text,
                PhoneNumber = CriticPhoneNumberInput.Text,
                DateOfBirth = CriticDateOfBirthInput.Value
            };

            try
            {
                _criticService.Save(critic);
                AddRowToDataGrid(CriticsDataGrid, _criticService.LoadFields(critic.PhoneNumber));
                ClearCriticsInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление данных критика.
        /// </summary>
        private void UpdateCriticBtn_Click(object sender, EventArgs e)
        {
            if (_choosenCritic == null)
            {
                MessageBox.Show("Выберите критика для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isFirstNameValid = CheckInput(CriticFirstNameInput, CriticService.RegexFirstName, CriticService.GetRequirementsForFirstName);
            bool isLastNameValid = CheckInput(CriticLastNameInput, CriticService.RegexLastName, CriticService.GetRequirementsForLastName);

            if (!isFirstNameValid || !isLastNameValid) return;

            string phoneNumber = _choosenCritic.Cells[CriticService.ColumnMapping["PhoneNumber"]].Value.ToString();
            try
            {
                Person critic = _criticService.GetByPhoneNumber(phoneNumber);
                critic.FirstName = CriticFirstNameInput.Text;
                critic.LastName = CriticLastNameInput.Text;
                critic.DateOfBirth = CriticDateOfBirthInput.Value;
                _criticService.Update(critic);
                ReplaceRowInDataGrid(CriticsDataGrid, _choosenCritic.Index, _criticService.LoadFields(critic.PhoneNumber));
                ClearCriticsInputs();
                _choosenCritic = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработка двойного клика в таблице критиков.
        /// </summary>
        private void CriticDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearCriticsInputs();
            _choosenCritic = GetSelectedRowFromDataGrid(CriticsDataGrid);
            CriticPhoneNumberInput.Text = _choosenCritic.Cells[CriticService.ColumnMapping["PhoneNumber"]].Value.ToString();
            CriticFirstNameInput.Text = _choosenCritic.Cells[CriticService.ColumnMapping["FirstName"]].Value.ToString();
            CriticLastNameInput.Text = _choosenCritic.Cells[CriticService.ColumnMapping["LastName"]].Value.ToString();
            CriticDateOfBirthInput.Value = DateTime.Parse(_choosenCritic.Cells[CriticService.ColumnMapping["DateOfBirth"]].Value.ToString());
            CriticPhoneNumberInput.ReadOnly = true;
        }

        /// <summary>
        /// Очистить поля критиков.
        /// </summary>
        private void ClearCriticsInputs()
        {
            CriticFirstNameInput.Text = "";
            CriticLastNameInput.Text = "";
            CriticPhoneNumberInput.Text = "";
            CriticDateOfBirthInput.Value = CriticDateOfBirthInput.MinDate;
            CriticPhoneNumberInput.ReadOnly = false;
            errorProvider.SetError(CriticFirstNameInput, "");
            errorProvider.SetError(CriticLastNameInput, "");
            errorProvider.SetError(CriticPhoneNumberInput, "");
        }

        /// <summary>
        /// Очистить поля критиков по кнопке.
        /// </summary>
        private void ClearCriticsInputsBtn_Click(object sender, EventArgs e)
        {
            ClearCriticsInputs();
        }

        /// <summary>
        /// Поиск критиков.
        /// </summary>
        private void CriticSearchBtn_Click(object sender, EventArgs e)
        {
            ShowRowsWithKeyword(CriticsDataGrid, CriticSearchInput.Text);
        }

        /// <summary>
        /// Удалить всех критиков.
        /// </summary>
        private void DeleteAllCriticsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _criticService.DeleteAll();
                LoadCriticDataGrid();
                ClearCriticsInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загрузить таблицу критиков.
        /// </summary>
        private void LoadCriticDataGrid()
        {
            CriticsDataGrid.DataSource = _criticService.GetDataTableOfAll();
        }

        #endregion

        #region Poem Page

        /// <summary>
        /// Добавление работы.
        /// </summary>
        private void AddPoemBtn_Click(object sender, EventArgs e)
        {
            if (_choosenPoet == null)
            {
                MessageBox.Show("Выберите поэта для добавления работы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_choosenCritic == null)
            {
                MessageBox.Show("Выберите критика для добавления работы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PoemTextData.Text.Length == 0)
            {
                MessageBox.Show("Введите текст работы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var poem = new Poem()
            {
                PoetPhoneNumber = _choosenPoet.Cells[PoetService.ColumnMapping["PhoneNumber"]].Value.ToString(),
                CriticPhoneNumber = _choosenCritic.Cells[CriticService.ColumnMapping["PhoneNumber"]].Value.ToString(),
                Uploaded = DateTime.Now,
                TextData = PoemTextData.Text,
            };

            try
            {
                _poemService.Save(poem);
                PoemTextData.Text = "";
                LoadPoemDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загрузить таблицу работ.
        /// </summary>
        private void LoadPoemDataGrid()
        {
            PoemDataGrid.DataSource = _poemService.GetDataTableOfAll();
        }

        /// <summary>
        /// Удалить все работы.
        /// </summary>
        private void DeleteAlllPoemsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _poemService.DeleteAll();
                LoadPoemDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        /// <summary>
        /// Обработка двойного клика в таблице работ.
        /// </summary>
        private void PoemDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var _choosenPoem = GetSelectedRowFromDataGrid(PoemDataGrid);
            PoemTextData.Text = _choosenPoem.Cells[PoemService.ColumnMapping["TextData"]].Value.ToString();
        }
    }
}
