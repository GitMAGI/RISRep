using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRetriever
{
    class DBSQLLayer
    {
        public static DataTable ExecuteQuery(string connectionString, string sql)
        {
            //string connectionString = "";
            DataTable dataTable = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {                
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    dataTable = new DataTable();
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        }

        public static DataTable ExecuteQueryWithParams(string connectionString, string sql, Dictionary<string, string> atts)
        {
            //string connectionString = "";
            DataTable dataTable = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                foreach(KeyValuePair<string, string> entry in atts){
                    cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                }
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    dataTable = new DataTable();
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        }

        public static int ExecuteNonQuery(string connectionString, string sql)
        {
            int result = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                connection.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int ExecuteNonQueryWithParams(string connectionString, string sql, Dictionary<string, object> atts)
        {
            int result = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                foreach (KeyValuePair<string, object> entry in atts)
                {
                    cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                }
                connection.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }    
    }
}
