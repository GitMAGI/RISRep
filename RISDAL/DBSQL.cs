using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBSQL
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                
        static public DataTable ExecuteQuery(string connectionString, string sql)
        {
            log.Info(string.Format("Setting up ..."));
            //string connectionString = "";
            DataTable dataTable = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                log.Info(string.Format("Opening Connection on {0} ...", connectionString));
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    dataTable = new DataTable();
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        }
        static public DataTable ExecuteQueryWithParams(string connectionString, string sql, Dictionary<string, object> atts)
        {
            //string connectionString = "";
            DataTable dataTable = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                foreach (KeyValuePair<string, object> entry in atts)
                {
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

        static public int ExecuteNonQuery(string connectionString, string sql)
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
        static public int ExecuteNonQueryWithParams(string connectionString, string sql, Dictionary<string, object> atts)
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
