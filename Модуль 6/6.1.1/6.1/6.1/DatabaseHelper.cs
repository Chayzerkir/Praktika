using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;

namespace _6._1
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }

    public static class DatabaseHelper
    {
        private static string databasePath = "finance.db";
        private static string connectionString = $"Data Source={databasePath};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Transactions (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Description TEXT NOT NULL,
                        Amount DECIMAL NOT NULL,
                        Type TEXT NOT NULL,
                        Date DATETIME NOT NULL,
                        Category TEXT NOT NULL
                    )";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void AddTransaction(Transaction transaction)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
                    INSERT INTO Transactions (Description, Amount, Type, Date, Category)
                    VALUES (@Description, @Amount, @Type, @Date, @Category)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Description", transaction.Description);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@Type", transaction.Type);
                    command.Parameters.AddWithValue("@Date", transaction.Date);
                    command.Parameters.AddWithValue("@Category", transaction.Category);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateTransaction(Transaction transaction)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string updateQuery = @"
                    UPDATE Transactions 
                    SET Description = @Description, 
                        Amount = @Amount, 
                        Type = @Type, 
                        Date = @Date, 
                        Category = @Category
                    WHERE Id = @Id";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", transaction.Id);
                    command.Parameters.AddWithValue("@Description", transaction.Description);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@Type", transaction.Type);
                    command.Parameters.AddWithValue("@Date", transaction.Date);
                    command.Parameters.AddWithValue("@Category", transaction.Category);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTransaction(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Transactions WHERE Id = @Id";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Transaction> GetAllTransactions()
        {
            var transactions = new List<Transaction>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Transactions ORDER BY Date DESC";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new Transaction
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Description = reader["Description"].ToString(),
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            Type = reader["Type"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"]),
                            Category = reader["Category"].ToString()
                        });
                    }
                }
            }

            return transactions;
        }

        public static decimal GetTotalIncome()
        {
            return GetTotalByType("Income");
        }

        public static decimal GetTotalExpenses()
        {
            return GetTotalByType("Expense");
        }

        private static decimal GetTotalByType(string type)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT SUM(Amount) FROM Transactions WHERE Type = @Type";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", type);
                    var result = command.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }
    }
}
