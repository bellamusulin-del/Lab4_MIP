
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Lab4_MIP
{
    public class SQLiteHandler
    {
        private readonly string databaseFileName =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "keywords.db");

        private SQLiteConnection databaseConnection;

        public void ConnectToDb()
        {
            if (databaseConnection != null &&
                databaseConnection.State == System.Data.ConnectionState.Open)
            {
                return;
            }

            if (!File.Exists(databaseFileName))
            {
                SQLiteConnection.CreateFile(databaseFileName);
            }

            string connectionString =
                "Data Source=" + databaseFileName + ";Version=3;";

            databaseConnection = new SQLiteConnection(connectionString);
            databaseConnection.Open();

            string createTableSql =
                "CREATE TABLE IF NOT EXISTS Keywords (" +
                "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "keyword TEXT NOT NULL UNIQUE COLLATE NOCASE)";

            using (SQLiteCommand command =
                new SQLiteCommand(createTableSql, databaseConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void InsertKeyword(string keywordText)
        {
            if (string.IsNullOrWhiteSpace(keywordText))
            {
                throw new ArgumentException("A kulcsszo nem lehet ures.");
            }

            ConnectToDb();

            string insertSql =
                "INSERT INTO Keywords (keyword) VALUES (@keyword)";

            using (SQLiteCommand command =
                new SQLiteCommand(insertSql, databaseConnection))
            {
                command.Parameters.AddWithValue("@keyword", keywordText.Trim());
                command.ExecuteNonQuery();
            }
        }

        public List<string> GetAllKeywords()
        {
            ConnectToDb();

            List<string> keywordList = new List<string>();

            string selectSql =
                "SELECT keyword FROM Keywords ORDER BY id";

            using (SQLiteCommand command =
                new SQLiteCommand(selectSql, databaseConnection))
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    keywordList.Add(reader["keyword"].ToString());
                }
            }

            return keywordList;
        }

        public void DisconnectFromDb()
        {
            if (databaseConnection != null)
            {
                databaseConnection.Close();
                databaseConnection.Dispose();
                databaseConnection = null;
            }
        }
    }
}

