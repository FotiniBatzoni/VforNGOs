using System.Data;
using System.Data.SqlClient;

namespace VforNGOss.DataAccessLayer
{
    public class DataAccessClient 
    {
        public static Int32 ExecuteNonQuery(String query, String parameterName, String value)
        {
            using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
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
            using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Set the connection, command, and then execute the command with query and return the reader.  
        //  public static SqlDataReader ExecuteReader( String commandText, CommandType commandType, params SqlParameter[] parameters)
        public static SqlDataReader ExecuteReader( String query)
        {
            SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;");

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                //cmd.CommandType = commandType;
                //cmd.Parameters.AddRange(parameters);

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the   
                // IDataReader is closed.  
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

        public static void ConnectionClose()
        {
            SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;");
            conn.Close();
        }
    }
}
