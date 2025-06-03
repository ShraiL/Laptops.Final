using LashaShraieri.Final.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LashaShraieri.Final.Services
{
    public class SqlHelper
    {
        private readonly string _connectionString;

        public SqlHelper()
        {
            // Use Integrated Security for Windows Authentication
            // Ensure your SQL Server instance name and database name are correct
            _connectionString = "Server=SHRAI\\SQLEXPRESS;Database=Laptops;Integrated Security=True;TrustServerCertificate=True;";
        }

        public void AddLaptop(Laptop laptop)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Laptops (Model, ReleaseYear, MemorySize, Cores) VALUES (@Model, @ReleaseYear, @MemorySize, @Cores)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Model", laptop.Model);
                    command.Parameters.AddWithValue("@ReleaseYear", laptop.ReleaseYear);
                    command.Parameters.AddWithValue("@MemorySize", laptop.MemorySize);
                    command.Parameters.AddWithValue("@Cores", laptop.Cores);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Laptop> GetLaptops()
        {
            List<Laptop> laptops = new List<Laptop>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Model, ReleaseYear, MemorySize, Cores FROM Laptops";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            laptops.Add(new Laptop(
                                model: reader["Model"].ToString(),
                                releaseYear: Convert.ToInt32(reader["ReleaseYear"]),
                                memorySize: Convert.ToInt32(reader["MemorySize"]),
                                cores: Convert.ToInt32(reader["Cores"])
                            )
                            {
                                Id = Convert.ToInt32(reader["Id"])
                            });
                        }
                    }
                }
            }

            return laptops;
        }

        public void DeleteLaptop(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Laptops WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
