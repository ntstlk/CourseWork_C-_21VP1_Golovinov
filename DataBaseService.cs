using CourseWork.Source.DataBaseRelated;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;

namespace CourseWork.Source.Services
{
    /// <summary>
    /// Управление базой данных. Создание и подключение.
    /// </summary>
    internal partial class DataBaseService
    {
        private static DataBaseService _instance;
        private string _dataBasesPath = string.Empty;
        private DataBase _dataBase;

        /// <summary>
        /// Конструктор (приватный для Singleton).
        /// </summary>
        private DataBaseService() { }

        /// <summary>
        /// Получить экземпляр сервиса (Singleton).
        /// </summary>
        /// <returns>Экземпляр <see cref="DataBaseService"/>.</returns>
        public static DataBaseService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataBaseService();
                _instance._dataBasesPath = "DataBases";
                _instance._dataBase = new DataBase();
            }
            return _instance;
        }

        /// <summary>
        /// Создать новую базу данных.
        /// </summary>
        /// <param name="dataBaseName">Имя базы данных.</param>
        public void SetNewDataBase(string dataBaseName)
        {
            string dataBasePath = Path.Combine(_dataBasesPath, $"{dataBaseName}.db");
            SQLiteConnection.CreateFile(dataBasePath);
            SetConnectionToDataBase(dataBasePath);
            CreateDataTables();
            SetDataBaseToServices();
        }

        /// <summary>
        /// Подключиться к существующей базе данных.
        /// </summary>
        /// <param name="dataBaseName">Имя базы данных.</param>
        public void SetExistingDataBase(string dataBaseName)
        {
            string dataBasePath = Path.Combine(_dataBasesPath, $"{dataBaseName}.db");
            SetConnectionToDataBase(dataBasePath);
            SetDataBaseToServices();
        }

        /// <summary>
        /// Установить подключение к базе данных.
        /// </summary>
        /// <param name="dataBasePath">Путь к базе данных.</param>
        private void SetConnectionToDataBase(string dataBasePath)
        {
            string connectionString = $"Data Source={dataBasePath}; Version=3;";
            _dataBase.Connection = new SQLiteConnection(connectionString);
        }

        /// <summary>
        /// Настроить подключение к сервисам поэтов, критиков и работ.
        /// </summary>
        private void SetDataBaseToServices()
        {
            PoetService.DB = _dataBase;
            CriticService.DB = _dataBase;
            PoemService.DB = _dataBase;
        }

        /// <summary>
        /// Создать таблицы базы данных.
        /// </summary>
        private void CreateDataTables()
        {
            SQLiteCommand command = new SQLiteCommand(
                @"CREATE TABLE poets (
                    phone_number VARCHAR(12) NOT NULL PRIMARY KEY,
                    first_name VARCHAR(20) NOT NULL,
                    last_name VARCHAR(20) NOT NULL,
                    date_of_birth DATE NOT NULL 
                );
                CREATE TABLE critics (
                    phone_number VARCHAR(12) NOT NULL PRIMARY KEY,
                    first_name VARCHAR(20) NOT NULL,
                    last_name VARCHAR(20) NOT NULL,
                    date_of_birth DATE NOT NULL 
                );
                CREATE TABLE poems (   
                    poet_phone_number VARCHAR(12) NOT NULL,
                    critic_phone_number VARCHAR(12) NOT NULL,
                    uploaded_date DATE NOT NULL,
                    uploaded_time TIME NOT NULL,
                    text_data VARCHAR NOT NULL,
                    FOREIGN KEY (poet_phone_number) REFERENCES poets(phone_number),
                    FOREIGN KEY (critic_phone_number) REFERENCES critics(phone_number)
                );");
            _dataBase.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// Проверить, существует ли база данных.
        /// </summary>
        /// <param name="dataBaseName">Имя базы данных.</param>
        /// <returns>True, если база данных существует.</returns>
        public bool CheckDataBaseExists(string dataBaseName)
        {
            return File.Exists(Path.Combine(_dataBasesPath, $"{dataBaseName}.db"));
        }

        /// <summary>
        /// Регулярное выражение для валидации имени базы данных.
        /// </summary>
        [GeneratedRegex("^[A-Za-zА]{3,15}$")]
        public static partial Regex RegexDataBaseName();

        /// <summary>
        /// Описание требований к имени базы данных.
        /// </summary>
        /// <returns>Сообщение о требованиях к имени базы данных.</returns>
        public static string GetRequirementsForDataBaseName()
        {
            return "Имя должно состоять из латинских букв и быть длиной от 3 до 15 символов";
        }
    }
}
