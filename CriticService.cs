using CourseWork.Source.Entities;
using CourseWork.Source.DataBaseRelated;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Text.RegularExpressions;

namespace CourseWork.Source.Services
{
    internal partial class CriticService
    {
        /// <summary>
        /// база данных для запросов
        /// </summary>
        public static DataBase DB { get; set; }

        /// <summary>
        /// таблица критиков
        /// </summary>
        private const string TableName = "critics";

        /// <summary>
        /// маппинг полей критика с таблицей
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
        /// получить критика по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">номер телефона критика</param>
        /// <returns>объект Person с данными критика</returns>
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
        /// получить всех критиков
        /// </summary>
        /// <returns>таблица данных всех критиков</returns>
        public DataTable GetDataTableOfAll()
        {
            var command = new SQLiteCommand($"SELECT * FROM `{TableName}`");
            return DB.GetDataTable(command);
        }

        /// <summary>
        /// сохранить критика
        /// </summary>
        /// <param name="employee">объект Person с данными критика</param>
        public void Save(Person employee)
        {
            if (Exists(employee.PhoneNumber))
            {
                throw new Exception("Номер телефона уже используется");
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
        /// удалить критика по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">номер телефона критика</param>
        public void Delete(string phoneNumber)
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}` WHERE {ColumnMapping["PhoneNumber"]} = @phoneNumber;");
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            DB.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// обновить данные критика
        /// </summary>
        /// <param name="employee">объект Person с обновленными данными критика</param>
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
        /// удалить всех критиков
        /// </summary>
        public void DeleteAll()
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}`;");
            DB.ExecuteCommandNQ(command);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// форматировать дату рождения
        /// </summary>
        /// <param name="dateOfBirth">дата рождения</param>
        /// <returns>форматированная дата рождения</returns>
        public string GetFormatDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// загрузить поля критика по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">номер телефона критика</param>
        /// <returns>словарь с полями критика</returns>
        public Dictionary<string, string> LoadFields(string phoneNumber)
        {
            var command = new SQLiteCommand($"SELECT * FROM `{TableName}` WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            return DB.GetRowAsDictionary(command);
        }

        /// <summary>
        /// проверяет наличие критика по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">номер телефона критика</param>
        /// <returns>true если критик существует</returns>
        private bool Exists(string phoneNumber)
        {
            var command = new SQLiteCommand($"SELECT COUNT(*) FROM `{TableName}` WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            return Convert.ToInt32(DB.ExecuteCommandScalar(command)) != 0;
        }

        #endregion

        #region Validation Methods

        /// <summary>
        /// регулярное выражение для имени
        /// </summary>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexFirstName();

        /// <summary>
        /// требования для имени
        /// </summary>
        /// <returns>требования для имени</returns>
        public static string GetRequirementsForFirstName()
        {
            return "Имя должно состоять из букв 3-15 символов";
        }

        /// <summary>
        /// регулярное выражение для фамилии
        /// </summary>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexLastName();

        /// <summary>
        /// требования для фамилии
        /// </summary>
        /// <returns>требования для фамилии</returns>
        public static string GetRequirementsForLastName()
        {
            return "Фамилия должна состоять из букв 3-15 символов";
        }

        /// <summary>
        /// регулярное выражение для номера телефона
        /// </summary>
        [GeneratedRegex("^\\+?\\d{1,3}\\s?\\(?\\d{3}\\)?[-.\\s]?\\d{3}[-.\\s]?\\d{4}$")]
        public static partial Regex RegexPhoneNumber();

        /// <summary>
        /// требования для номера телефона
        /// </summary>
        /// <returns>требования для номера телефона</returns>
        public static string GetRequirementsForPhoneNumber()
        {
            return "номер телефона должен быть корректным";
        }

        #endregion
    }
}
