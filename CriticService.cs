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
        public static DataBase DB { get; set; }
        private const string TableName = "critics";
        public static readonly Dictionary<string, string> ColumnMapping = new Dictionary<string, string>()
        {
            { "FirstName", "first_name" },
            { "LastName", "last_name" },
            { "PhoneNumber", "phone_number" },
            { "DateOfBirth", "date_of_birth"}
        };
        #region CRUD Operations
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
        public DataTable GetDataTableOfAll()
        {
            var command = new SQLiteCommand($"SELECT * FROM `{TableName}`");
            return DB.GetDataTable(command);
        }
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
        public void Delete(string phoneNumber)
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}` " +
                $"WHERE {ColumnMapping["PhoneNumber"]} = @phoneNumber;");

            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            DB.ExecuteCommandNQ(command);
        }
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
        public void DeleteAll()
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}`;");
            DB.ExecuteCommandNQ(command); 
        }

        #endregion
        #region Helper Methods
        public string GetFormatDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth.ToString("yyyy-MM-dd");
        }
        public Dictionary<string, string> LoadFields(string phoneNumber)
        {
            var command = new SQLiteCommand(
                $"SELECT * FROM `{TableName}` " +
                $"WHERE {ColumnMapping["PhoneNumber"]}=@phoneNumber;");

            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            return DB.GetRowAsDictionary(command);
        }
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
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexFirstName();
        public static string GetRequirementsForFirstName()
        {
            return "имя должно состояьть из латинских или кириллических букв и быть длиной от 3 до 15 символов";
        }
        [GeneratedRegex("^[A-Za-zА-ЯЁа-яё]{3,15}$")]
        public static partial Regex RegexLastName();
        public static string GetRequirementsForLastName()
        {
            return "фамилия должна состояьть из латинских или кириллических букв и быть длиной от 3 до 15 символов";
        }
        [GeneratedRegex("^\\+?\\d{1,3}\\s?\\(?\\d{3}\\)?[-.\\s]?\\d{3}[-.\\s]?\\d{4}$")]
        public static partial Regex RegexPhoneNumber();
        public static string GetRequirementsForPhoneNumber()
        {
            return "номер телефона должен быть корректным";
        }
        #endregion
    }
}
