using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;

namespace CourseWork.Source.DataBaseRelated
{
    internal class DataBase
    {
        /// <summary>
        /// Соединение с базой.
        /// </summary>
        public SQLiteConnection Connection { set; get; }

        /// <summary>
        /// Выполнить команду без результата.
        /// </summary>
        /// <param name="command">SQL-команда.</param>
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
        /// Выполнить команду, вернуть результат.
        /// </summary>
        /// <param name="command">SQL-команда.</param>
        /// <returns>Результат команды.</returns>
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
        /// Вернуть данные как таблицу.
        /// </summary>
        /// <param name="command">SQL-команда.</param>
        /// <returns>Таблица данных.</returns>
        public DataTable GetDataTable(SQLiteCommand command)
        {
            try
            {
                Connection.Open();
                command.Connection = Connection;
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
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
        /// Вернуть строку как словарь.
        /// </summary>
        /// <param name="command">SQL-команда.</param>
        /// <returns>Словарь данных.</returns>
        public Dictionary<string, string> GetRowAsDictionary(SQLiteCommand command)
        {
            try
            {
                Connection.Open();
                command.Connection = Connection;
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.FieldCount == 0) {
                    throw new Exception("ошибка данных");
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
        /// Вернуть значения столбца как список.
        /// </summary>
        /// <param name="command">SQL-команда.</param>
        /// <returns>Список строк.</returns>
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

        /// <summary>
        /// Закрыть соединение, если оно открыто.
        /// </summary>
        private void CloseConnectionIfOpen()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
