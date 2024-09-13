using CourseWork.Source.DataBaseRelated;
using CourseWork.Source.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace CourseWork.Source.Services
{
    internal partial class PoetService
    {
        public static DataBase DB { get; set; }
        private const string TableName = "poets";
        public static readonly Dictionary<string, string> ColumnMapping = new Dictionary<string, string>()
        {
            { "FirstName", "first_name" },
            { "LastName", "last_name" },
            { "PhoneNumber", "phone_number" },
            { "DateOfBirth", "date_of_birth"}
        };

        #region CRUD Operations

        /// <summary>
        /// получает поэта по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">номер телефона</param>
        /// <returns>объект поэта</returns>
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
        /// возвращает всех поэтов
        /// </summary>
        /// <returns>таблица поэтов</returns>
        public DataTable GetDataTableOfAll()
        {
            var command = new SQLiteCommand($"SELECT * FROM `{TableName}`");
            return DB.GetDataTable(command);
        }

        /// <summary>
        /// сохраняет поэта
        /// </summary>
        /// <param name="poet">объект поэта</param>
        public void Save(Person poet)
        {
            if (Exists(poet.PhoneNumber))
            {
                throw new Exception("номер телефона уже используется");
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
        /// удаляет поэта по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">номер телефона</param>
        public void Delete(string phoneNumber)
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}` " +
                $"WHERE {ColumnMapping["PhoneNumber"]} = @phoneNumber;");
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            DB.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// обновляет данные поэта
        /// </summary>
        /// <param name="poet">объект поэта</param>
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
        /// удаляет всех поэтов
        /// </summary>
        public void DeleteAll()
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}`;");
            DB.ExecuteCommandNQ(command);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// форматирует дату рождения
        /// </summary>
        /// <param name="dateOfBirth">дата рождения</param>
        /// <returns>форматированная дата рождения</returns>
        public string GetFormatDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// загружает поля поэта по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">номер телефона</param>
        /// <returns>словарь с полями поэта</returns>
        public Dictionary<string, string> LoadFields(string phoneNumber)
        {
            var command = new SQLiteCommand(
                $"SELECT * FROM `{TableName}` " +
                $"WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            return DB.GetRowAsDictionary(command);
        }

        /// <summary>
        /// проверяет, существует ли поэт с данным номером телефона
        /// </summary>
        /// <param name="phoneNumber">номер телефона</param>
        /// <returns>true если поэт существует</returns>
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
        /// регулярное выражение для имени
        /// </summary>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexFirstName();

        /// <summary>
        /// требования к имени
        /// </summary>
        public static string GetRequirementsForFirstName()
        {
            return "имя должно состоять из латинских или кириллических букв и быть длиной от 3 до 15 символов";
        }

        /// <summary>
        /// регулярное выражение для фамилии
        /// </summary>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexLastName();

        /// <summary>
        /// требования к фамилии
        /// </summary>
        public static string GetRequirementsForLastName()
        {
            return "фамилия должна состоять из латинских или кириллических букв и быть длиной от 3 до 15 символов";
        }

        /// <summary>
        /// регулярное выражение для номера телефона
        /// </summary>
        [GeneratedRegex("^\\+?\\d{1,3}\\s?\\(?\\d{3}\\)?[-.\\s]?\\d{3}[-.\\s]?\\d{4}$")]
        public static partial Regex RegexPhoneNumber();

        /// <summary>
        /// требования к номеру телефона
        /// </summary>
        public static string GetRequirementsForPhoneNumber()
        {
            return "номер телефона должен быть корректным";
        }

        #endregion
    }
}
