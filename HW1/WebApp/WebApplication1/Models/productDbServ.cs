using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public static class productDbServ
    {
        public static Product[] GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string connectionString = @"Data Source=LAPTOP-3NQL7H3O\SQLEXPRESS;Initial Catalog=Nirc7DB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM productsTb";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                products.Add(new Product()
                                {
                                    Id = (int)reader["Id"],
                                    Name = (string)reader["Name"],
                                    Description = (string)reader["Description"],
                                    Barcode = (string)reader["Barcode"]
                                });

                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            return products.ToArray();
        }
    }
}