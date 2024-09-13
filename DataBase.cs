using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;

namespace CourseWork.Source.DataBaseRelated
{
    internal class DataBase
    {
        public SQLiteConnection Connection { set; get; }

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
        public Dictionary<string, string> GetRowAsDictionary(SQLiteCommand command)
        {
            //method for getting a row from sql data base as a dictionary
            try
            {
                Connection.Open();
                command.Connection = Connection;
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.FieldCount == 0) {
                    throw new Exception("ошибка получения данных");
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
        public List<string> GetColumnValuesAsList(SQLiteCommand command)
        {
            //method for getting values from one column in sql data base  
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
