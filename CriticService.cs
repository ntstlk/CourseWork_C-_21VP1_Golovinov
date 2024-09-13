using CourseWork.Source.Entities;
using CourseWork.Source.DataBaseRelated;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Text.RegularExpressions;

namespace CourseWork.Source.Services
{
    /// <summary>
    /// Управление данными критиков. Операции CRUD.
    /// </summary>
    internal partial class CriticService
    {
        /// <summary>
        /// База данных для запросов.
        /// </summary>
        public static DataBase DB { get; set; }

        /// <summary>
        /// Таблица критиков.
        /// </summary>
        private const string TableName = "critics";

        /// <summary>
        /// Сопоставление полей класса и колонок таблицы.
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
        /// Возвращает критика по номеру телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона критика.</param>
        /// <returns>Критик.</returns>
        public Person GetByPhoneNumber(string phoneNumber)
        {
            var fields = LoadFields(phoneNumber);
            return new Person()
            {
                FirstName = fields[ColumnMapping["FirstName"]],
                LastName = fields[ColumnMapping["LastName"]],
                PhoneNumber = fields[ColumnMapping["PhoneNumber"]],
                DateOfBirth = DateTime.Parse(fields[ColumnMapping["DateOfBirth"]]),
                Role = Person.Roles.Critic
            };
        }

        /// <summary>
        /// Возвращает всех критиков.
        /// </summary>
        /// <returns>Таблица критиков.</returns>
        public DataTable GetDataTableOfAll()
        {
            var command = new SQLiteCommand($"SELECT * FROM `{TableName}`");
            return DB.GetDataTable(command);
        }

        /// <summary>
        /// Сохраняет критика.
        /// </summary>
        /// <param name="employee">Критик.</param>
        public void Save(Person employee)
        {
            if (Exists(employee.PhoneNumber))
            {
                throw new Exception("Номер телефона уже используется.");
            }
            var command = new SQLiteCommand(
                $"INSERT INTO `{TableName}`" +
                $"({ColumnMapping["PhoneNumber"]}, {ColumnMapping["FirstName"]}, " +
                $"{ColumnMapping["LastName"]}, {ColumnMapping["DateOfBirth"]})" +
                $"VALUES (@phoneNumber, @firstName, @lastName, @dateOfBirth);");

            command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("@firstName", employee.FirstName);
            command.Parameters.AddWithValue("@lastName", employee.LastName);
            command.Parameters.AddWithValue("@dateOfBirth", GetFormatDateOfBirth(employee.DateOfBirth));
            DB.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// Удаляет критика по номеру телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        public void Delete(string phoneNumber)
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}` WHERE {ColumnMapping["PhoneNumber"]} = @phoneNumber;");
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            DB.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// Обновляет данные критика.
        /// </summary>
        /// <param name="employee">Критик.</param>
        public void Update(Person employee)
        {
            var command = new SQLiteCommand($"UPDATE `{TableName}` " +
                $"SET {ColumnMapping["FirstName"]}=@firstName, " +
                $"{ColumnMapping["LastName"]}=@lastName, {ColumnMapping["DateOfBirth"]}=@dateOfBirth " +
                $"WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");

            command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("@firstName", employee.FirstName);
            command.Parameters.AddWithValue("@lastName", employee.LastName);
            command.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);
            DB.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// Удаляет всех критиков.
        /// </summary>
        public void DeleteAll()
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}`;");
            DB.ExecuteCommandNQ(command);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Форматирует дату рождения.
        /// </summary>
        /// <param name="dateOfBirth">Дата рождения.</param>
        /// <returns>Отформатированная дата.</returns>
        public string GetFormatDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Загружает поля критика.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        /// <returns>Словарь данных критика.</returns>
        public Dictionary<string, string> LoadFields(string phoneNumber)
        {
            var command = new SQLiteCommand($"SELECT * FROM `{TableName}` WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            return DB.GetRowAsDictionary(command);
        }

        /// <summary>
        /// Проверяет наличие критика по номеру телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        /// <returns>True, если существует.</returns>
        private bool Exists(string phoneNumber)
        {
            var command = new SQLiteCommand($"SELECT COUNT(*) FROM `{TableName}` WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            return Convert.ToInt32(DB.ExecuteCommandScalar(command)) != 0;
        }

        #endregion

        #region Validation Methods

        /// <summary>
        /// Регулярное выражение для имени.
        /// </summary>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexFirstName();

        /// <summary>
        /// Требования для имени.
        /// </summary>
        public static string GetRequirementsForFirstName()
        {
            return "Имя должно состоять из букв (3-15 символов)";
        }

        /// <summary>
        /// Регулярное выражение для фамилии.
        /// </summary>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexLastName();

        /// <summary>
        /// Требования для фамилии.
        /// </summary>
        public static string GetRequirementsForLastName()
        {
            return "Фамилия должна состоять из букв (3-15 символов)";
        }

        /// <summary>
        /// Регулярное выражение для номера телефона.
        /// </summary>
        [GeneratedRegex("^\\+?\\d{1,3}\\s?\\(?\\d{3}\\)?[-.\\s]?\\d{3}[-.\\s]?\\d{4}$")]
        public static partial Regex RegexPhoneNumber();

        /// <summary>
        /// Требования для номера телефона.
        /// </summary>
        public static string GetRequirementsForPhoneNumber()
        {
            return "Номер телефона должен быть корректным";
        }

        #endregion
    }
}
