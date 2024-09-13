using CourseWork.Source.DataBaseRelated;
using CourseWork.Source.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace CourseWork.Source.Services
{
    internal class PoemService
    {
        public static DataBase DB { get; set; }
        private const string TableName = "poems";
        public static readonly Dictionary<string, string> ColumnMapping = new Dictionary<string, string>()
        {
            { "Poet", "poet_phone_number" },
            { "Critic", "critic_phone_number" },
            { "UploadedDate", "uploaded_date" },
            { "UploadedTime", "uploaded_time"},
            { "TextData",  "text_data"}
        };
        #region CRUD operations
       
        public void Save(Poem poem)
        {
            if (Exists(poem))
            {
                throw new Exception("Добавление невозможно: работа у данного автора уже заявлена.");
            }
            var command = new SQLiteCommand($"INSERT INTO `{TableName}` (" +
                $"{ColumnMapping["Poet"]}, {ColumnMapping["Critic"]}, {ColumnMapping["UploadedDate"]}, {ColumnMapping["UploadedTime"]}, {ColumnMapping["TextData"]}) " +
                $"VALUES(@poet, @critic, @date, @time, @textData);");

            command.Parameters.AddWithValue("@poet", poem.PoetPhoneNumber);
            command.Parameters.AddWithValue("@critic", poem.CriticPhoneNumber);
            command.Parameters.AddWithValue("@date", GetFormatDate(poem.Uploaded));
            command.Parameters.AddWithValue("@time", GetFormatTime(poem.Uploaded));
            command.Parameters.AddWithValue("@textData", poem.TextData);
            DB.ExecuteCommandNQ(command);
        }
        public void DeleteAll()
        {
            var command = new SQLiteCommand($"DELETE FROM `{TableName}`;");
            DB.ExecuteCommandNQ(command);
        }
        public DataTable GetDataTableOfAll()
        {
            var command = new SQLiteCommand($"SELECT * FROM `{TableName}`");
            return DB.GetDataTable(command);
        }
        #endregion
        #region Helper Methods
        public bool Exists(Poem poem)
        {
            var command = new SQLiteCommand($"SELECT COUNT(*) FROM `{TableName}` " +
                $"WHERE {ColumnMapping["Poet"]}=@poet;");

            command.Parameters.AddWithValue("@poet", poem.PoetPhoneNumber);
            return Convert.ToInt32(DB.ExecuteCommandScalar(command)) != 0;
        }
        public string GetFormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        public string GetFormatTime(DateTime time)
        {
            return time.ToString("HH:mm");
        }
        #endregion
    }
}
