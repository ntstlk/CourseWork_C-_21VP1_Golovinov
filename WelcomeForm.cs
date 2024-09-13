using CourseWork.Source.Services;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CourseWork
{
    /// <summary>
    /// Форма приветствия приложения
    /// </summary>
    public partial class WelcomeForm : Form
    {
        /// <summary>
        /// Сервис для работы с базой данных
        /// </summary>
        DataBaseService dataBaseService = null;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public WelcomeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Начать"
        /// </summary>
        private void StartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SetUpDB();
                MainForm mainForm = new MainForm();
                mainForm.Closed += (s, args) => this.Close();
                mainForm.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Настройка базы данных
        /// </summary>
        private void SetUpDB()
        {
            string nameDB = NameDB.Text;
            dataBaseService = DataBaseService.GetInstance();

            if (CreateEmptyDB.Checked)
            {
                if (!DataBaseService.RegexDataBaseName().IsMatch(nameDB))
                {
                    throw new Exception(DataBaseService.GetRequirementsForDataBaseName());
                }
                dataBaseService.SetNewDataBase(nameDB);
            }

            if (UseExistingDB.Checked)
            {
                if (!dataBaseService.CheckDataBaseExists(nameDB))
                {
                    throw new Exception("Базы данных с таким именем не существует");
                }
                dataBaseService.SetExistingDataBase(nameDB);
            }
        }
    }
}