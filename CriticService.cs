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
    /// Класс для управления данными о критиках.
    /// Позволяет выполнять операции CRUD с критиками.
    /// </summary>
    internal partial class CriticService
    {
        /// <summary>
        /// База данных для выполнения запросов.
        /// </summary>
        public static DataBase DB { get; set; }

        /// <summary>
        /// Имя таблицы для хранения данных о критиках.
        /// </summary>
        private const string TableName = "critics";

        /// <summary>
        /// Словарь для маппинга полей класса на столбцы базы данных.
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
        /// <returns>Объект <see cref="Person"/>, представляющий критика.</returns>
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
        /// Возвращает таблицу данных со всеми критиками.
        /// </summary>
        /// <returns>Таблица данных <see cref="DataTable"/> со всеми критиками.</returns>
        public DataTable GetDataTableOfAll()
        {
            var command = new SQLiteCommand($"SELECT * FROM `{TableName}`");
            return DB.GetDataTable(command);
        }

        /// <summary>
        /// Сохраняет нового критика в базу данных.
        /// </summary>
        /// <param name="employee">Объект <see cref="Person"/>, представляющий критика.</param>
        public void Save(Person employee)
        {
            if (Exists(employee.PhoneNumber))
            {
                throw new Exception("Добавление невозможно: номер телефона уже используется.");
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
        /// Удаляет критика из базы данных по номеру телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона критика.</param>
        public void Delete(string phoneNumber)
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}` " +
                $"WHERE {ColumnMapping["PhoneNumber"]} = @phoneNumber;");

            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            DB.ExecuteCommandNQ(command);
        }

        /// <summary>
        /// Обновляет информацию о критике в базе данных.
        /// </summary>
        /// <param name="employee">Объект <see cref="Person"/>, представляющий критика.</param>
        public void Update(Person employee)
        {
            var command = new SQLiteCommand($"UPDATE " +
                $"`{TableName}` " +
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
        /// Удаляет всех критиков из базы данных.
        /// </summary>
        public void DeleteAll()
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}`;");
            DB.ExecuteCommandNQ(command);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Возвращает форматированную дату рождения.
        /// </summary>
        /// <param name="dateOfBirth">Дата рождения критика.</param>
        /// <returns>Дата в формате "yyyy-MM-dd".</returns>
        public string GetFormatDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Загружает данные критика по номеру телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона критика.</param>
        /// <returns>Словарь с данными критика.</returns>
        public Dictionary<string, string> LoadFields(string phoneNumber)
        {
            var command = new SQLiteCommand(
                $"SELECT * FROM `{TableName}` " +
                $"WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");

            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            return DB.GetRowAsDictionary(command);
        }

        /// <summary>
        /// Проверяет, существует ли критик с данным номером телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона критика.</param>
        /// <returns>True, если критик существует, иначе False.</returns>
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
        /// Регулярное выражение для валидации имени.
        /// </summary>
        /// <returns>Регулярное выражение для имени (3-15 символов).</returns>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexFirstName();

        /// <summary>
        /// Возвращает требования для имени критика.
        /// </summary>
        /// <returns>Описание требований к имени.</returns>
        public static string GetRequirementsForFirstName()
        {
            return "Имя должно состоять из латинских или кириллических букв и быть длиной от 3 до 15 символов";
        }

        /// <summary>
        /// Регулярное выражение для валидации фамилии.
        /// </summary>
        /// <returns>Регулярное выражение для фамилии (3-15 символов).</returns>
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexLastName();

        /// <summary>
        /// Возвращает требования для фамилии критика.
        /// </summary>
        /// <returns>Описание требований к фамилии.</returns>
        public static string GetRequirementsForLastName()
        {
            return "Фамилия должна состоять из латинских или кириллических букв и быть длиной от 3 до 15 символов";
        }

        /// <summary>
        /// Регулярное выражение для валидации номера телефона.
        /// </summary>
        /// <returns>Регулярное выражение для номера телефона.</returns>
        [GeneratedRegex("^\\+?\\d{1,3}\\s?\\(?\\d{3}\\)?[-.\\s]?\\d{3}[-.\\s]?\\d{4}$")]
        public static partial Regex RegexPhoneNumber();

        /// <summary>
        /// Возвращает требования для номера телефона критика.
        /// </summary>
        /// <returns>Описание требований к номеру телефона.</returns>
        public static string GetRequirementsForPhoneNumber()
        {
            return "Номер телефона должен быть корректным";
        }

        #endregion
    }
}
