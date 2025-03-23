using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LibraryManagementSystem.Models
{
    public static class Database
    {
        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        // Execute a query and return DataTable
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            
            return dataTable;
        }

        // Execute a non-query command (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int result;
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
            }
            
            return result;
        }

        // Execute a scalar query (returns a single value)
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result;
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    
                    connection.Open();
                    result = command.ExecuteScalar();
                }
            }
            
            return result;
        }
    }
} 