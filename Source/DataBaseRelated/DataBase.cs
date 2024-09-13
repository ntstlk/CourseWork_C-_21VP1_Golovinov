using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;

namespace CourseWork.Source.DataBaseRelated
{
    /// <summary>
    /// Класс для работы с базой данных SQLite
    /// </summary>
    internal class DataBase
    {
        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        public SQLiteConnection Connection { set; get; }

        /// <summary>
        /// Выполняет команду SQLite без возвращения результата
        /// </summary>
        /// <param name="command">Команда SQLite</param>
        public void ExecuteCommandNQ(SQLiteCommand command)
        {
            try
            {
                Connection.Open();
                command.Connection = Connection;
                command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Выполняет команду SQLite и возвращает скалярный результат
        /// </summary>
        /// <param name="command">Команда SQLite</param>
        /// <returns>Результат выполнения команды</returns>
        public object ExecuteCommandScalar(SQLiteCommand command)
        {
            try
            {
                Connection.Open();
                command.Connection = Connection;
                object scalar = command.ExecuteScalar();
                Connection.Close();
                return scalar;
            }
            catch (Exception ex)
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Выполняет команду SQLite и возвращает результат в виде DataTable
        /// </summary>
        /// <param name="command">Команда SQLite</param>
        /// <returns>Таблица данных</returns>
        public DataTable GetDataTable(SQLiteCommand command)
        {
            try
            {
                Connection.Open();
                command.Connection = Connection;
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(dataAdapter);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataAdapter.Dispose();
                Connection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Получает строку из базы данных в виде словаря
        /// </summary>
        /// <param name="command">Команда SQLite</param>
        /// <returns>Словарь с данными строки</returns>
        public Dictionary<string, string> GetRowAsDictionary(SQLiteCommand command)
        {
            try
            {
                Connection.Open();
                command.Connection = Connection;
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.FieldCount == 0)
                {
                    throw new Exception("Ошибка получения данных");
                }
                reader.Read();
                Dictionary<string, string> dictionary = Enumerable.Range(0, reader.FieldCount)
                    .ToDictionary(reader.GetName, reader.GetString);
                reader.Close();
                reader.DisposeAsync();
                Connection.Close();
                return dictionary;
            }
            catch (Exception ex)
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Получает значения из одного столбца базы данных в виде списка
        /// </summary>
        /// <param name="command">Команда SQLite</param>
        /// <returns>Список значений столбца</returns>
        public List<string> GetColumnValuesAsList(SQLiteCommand command)
        {
            try
            {
                Connection.Open();
                command.Connection = Connection;
                SQLiteDataReader reader = command.ExecuteReader();
                List<string> list = new List<string>();
                while (reader.Read())
                {
                    string item = reader.GetString(0);
                    list.Add(item);
                }
                reader.Close();
                reader.DisposeAsync();
                Connection.Close();
                return list;
            }
            catch (Exception ex)
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
                throw ex.InnerException;
            }
        }
    }
}