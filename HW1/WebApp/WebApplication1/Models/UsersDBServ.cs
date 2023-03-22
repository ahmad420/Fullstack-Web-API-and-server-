using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public static class UsersDBServ
    {

        public static User[] GetAllUsers()
        {
            List<User> users = new List<User>();
            string connectionString = @"Data Source=LAPTOP-3NQL7H3O\SQLEXPRESS;Initial Catalog=Nirc7DB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM nirc7UsersTb";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                          
                            while (reader.Read())
                            {

                                users.Add(new User()
                                { 
                                    Id = (int)reader["Id"],
                                    FirstName = (string)reader["firstName"],
                                    LastName = (string)reader["lastName"],
                                    Age = (string)reader["age"],
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
            return users.ToArray();
        }
    }
}