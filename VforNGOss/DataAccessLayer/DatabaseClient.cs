﻿using System.Data;
using System.Data.SqlClient;

namespace VforNGOss.DataAccessLayer
{
    public static class DatabaseClient 
    {
        public const string ConnectionString = "Server= .; Database=VforNGOs;Trusted_Connection=True;";
        public static Int32 ExecuteNonQuery(String query, String parameterName, String value)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue(parameterName,value);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static Int32 ExecuteNonQuery(String query)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Set the connection, command, and then execute the command with query and return the reader.  
        public static SqlDataReader ExecuteReader( String query)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                return reader;
            }
        }

        public static void ConnectionClose()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Close();
        }
    }
}
