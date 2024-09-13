using CourseWork.Source.Services;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class WelcomeForm : Form
    {
        DataBaseService dataBaseService = null;
        public WelcomeForm()
        {
            InitializeComponent();
        }

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
                    throw new Exception("Базы данных с таким именем не существует.");
                }
                dataBaseService.SetExistingDataBase(nameDB);
            }
        }
       
    }
}
