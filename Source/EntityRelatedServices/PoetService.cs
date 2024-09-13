using CourseWork.Source.DataBaseRelated;
using CourseWork.Source.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace CourseWork.Source.Services
{
    /// <summary>
    /// Класс для работы с поэтами
    /// </summary>
    internal partial class PoetService
    {
        /// <summary>
        /// Экземпляр базы данных
        /// </summary>
        public static DataBase DB { get; set; }

        /// <summary>
        /// Имя таблицы в базе данных
        /// </summary>
        private const string TableName = "poets";

        /// <summary>
        /// Сопоставление свойств класса с полями таблицы
        /// </summary>
        public static readonly Dictionary<string, string> ColumnMapping = new Dictionary<string, string>()
        {
            { "FirstName", "first_name" },
            { "LastName", "last_name" },
            { "PhoneNumber", "phone_number" },
            { "DateOfBirth", "date_of_birth"}
        };

        #region CRUD Operations

        /// <summary>
        /// Получить объект Person по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">Номер телефона для поиска</param>
        /// <returns>Объект Person</returns>
        public Person GetByPhoneNumber(string phoneNumber)
        {
            var fields = LoadFields(phoneNumber);
            return new Person()
            {
                FirstName = fields[ColumnMapping["FirstName"]],
                LastName = fields[ColumnMapping["LastName"]],
                PhoneNumber = fields[ColumnMapping["PhoneNumber"]],
                DateOfBirth = DateTime.Parse(fields[ColumnMapping["DateOfBirth"]]),
                Role = Person.Roles.Poet
            };
        }

        /// <summary>
        /// Получить таблицу всех поэтов
        /// </summary>
        /// <returns>DataTable с поэтами</returns>
        public DataTable GetDataTableOfAll()
        {
            var command = new SQLiteCommand($"SELECT * FROM `{TableName}`");
            return DB.GetDataTable(command);
        }

        /// <summary>
        /// Сохранить нового поэта в базу данных
        /// </summary>
        /// <param name="poet">Объект поэта для сохранения</param>
        public void Save(Person poet)
        {
            if (Exists(poet.PhoneNumber))
            {
                throw new Exception("Добавление невозможно: номер телефона уже используется");
            }
            var command = new SQLiteCommand(
                $"INSERT INTO `{TableName}`" +
                $"({ColumnMapping["PhoneNumber"]}, {ColumnMapping["FirstName"]}, " +
                $"{ColumnMapping["LastName"]}, {ColumnMapping["DateOfBirth"]})" +
                $"VALUES (@phoneNumber, @firstName, @lastName, @dateOfBirth);");

            command.Parameters.AddWithValue("@phoneNumber", poet.PhoneNumber);
            command.Parameters.AddWithValue("@firstName", poet.FirstName);
            command.Parameters.AddWithValue("@lastName", poet.LastName);
            command.Parameters.AddWithValue("@dateOfBirth", GetFormatDateOfBirth(poet.DateOfBirth));
            DB.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// Удалить поэта по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">Номер телефона поэта</param>
        public void Delete(string phoneNumber)
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}` " +
                $"WHERE {ColumnMapping["PhoneNumber"]} = @phoneNumber;");

            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            DB.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// Обновить информацию о поэте
        /// </summary>
        /// <param name="poet">Объект поэта с обновленными данными</param>
        public void Update(Person poet)
        {
            var command = new SQLiteCommand($"UPDATE " +
                $"`{TableName}` " +
                $"SET {ColumnMapping["FirstName"]}=@firstName, " +
                $"{ColumnMapping["LastName"]}=@lastName, {ColumnMapping["DateOfBirth"]}=@dateOfBirth " +
                $"WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");

            command.Parameters.AddWithValue("@phoneNumber", poet.PhoneNumber);
            command.Parameters.AddWithValue("@firstName", poet.FirstName);
            command.Parameters.AddWithValue("@lastName", poet.LastName);
            command.Parameters.AddWithValue("@dateOfBirth", GetFormatDateOfBirth(poet.DateOfBirth));
            DB.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// Удалить всех поэтов из базы данных
        /// </summary>
        public void DeleteAll()
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}`;");
            DB.ExecuteCommandNQ(command);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Получить дату рождения в формате строки
        /// </summary>
        /// <param name="dateOfBirth">Дата рождения</param>
        /// <returns>Строка даты в формате "yyyy-MM-dd"</returns>
        public string GetFormatDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Загрузить поля по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">Номер телефона для поиска</param>
        /// <returns>Словарь полей и значений</returns>
        public Dictionary<string, string> LoadFields(string phoneNumber)
        {
            var command = new SQLiteCommand(
                $"SELECT * FROM `{TableName}` " +
                $"WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");

            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            return DB.GetRowAsDictionary(command);
        }

        /// <summary>
        /// Проверить существование поэта по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <returns>True, если поэт существует</returns>
        private bool Exists(string phoneNumber)
        {
            var command = new SQLiteCommand(
                $"SELECT COUNT(*) FROM `{TableName}` " +
                $"WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");

            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            return Convert.ToInt32(DB.ExecuteCommandScalar(command)) != 0;
        }

        #endregion

        #region Validation Methods

        /// <summary>
        /// Регулярное выражение для проверки имени
        /// </summary>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexFirstName();

        /// <summary>
        /// Требования к имени
        /// </summary>
        /// <returns>Описание требований к имени</returns>
        public static string GetRequirementsForFirstName()
        {
            return "имя должно состоять из букв и быть длиной от 3 до 15 символов";
        }

        /// <summary>
        /// Регулярное выражение для проверки фамилии
        /// </summary>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexLastName();

        /// <summary>
        /// Требования к фамилии
        /// </summary>
        /// <returns>Описание требований к фамилии</returns>
        public static string GetRequirementsForLastName()
        {
            return "фамилия должна состоять из букв и быть длиной от 3 до 15 символов";
        }

        /// <summary>
        /// Регулярное выражение для проверки номера телефона
        /// </summary>
        [GeneratedRegex("^\\+?\\d{1,3}\\s?\\(?\\d{3}\\)?[-.\\s]?\\d{3}[-.\\s]?\\d{4}$")]
        public static partial Regex RegexPhoneNumber();

        /// <summary>
        /// Требования к номеру телефона
        /// </summary>
        /// <returns>Описание требований к номеру телефона</returns>
        public static string GetRequirementsForPhoneNumber()
        {
            return "номер телефона должен быть корректным";
        }

        #endregion
    }
}