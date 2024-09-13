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
        /// соединение с базой данных
        /// </summary>
        public SQLiteConnection Connection { set; get; }

        /// <summary>
        /// выполнить команду без возврата данных
        /// </summary>
        /// <param name="command">sql-команда</param>
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
                CloseConnectionIfOpen();
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// выполнить команду с возвратом результата
        /// </summary>
        /// <param name="command">sql-команда</param>
        /// <returns>результат команды</returns>
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
                CloseConnectionIfOpen();
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// получить данные как таблицу
        /// </summary>
        /// <param name="command">sql-команда</param>
        /// <returns>таблица данных</returns>
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
                CloseConnectionIfOpen();
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// получить строку как словарь
        /// </summary>
        /// <param name="command">sql-команда</param>
        /// <returns>словарь данных</returns>
        public Dictionary<string, string> GetRowAsDictionary(SQLiteCommand command)
        {
            try
            {
                Connection.Open();
                command.Connection = Connection;
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.FieldCount == 0) 
                {
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
                CloseConnectionIfOpen();
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// получить значения столбца как список
        /// </summary>
        /// <param name="command">sql-команда</param>
        /// <returns>список строк</returns>
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
                CloseConnectionIfOpen();
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// закрыть соединение если оно открыто
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
