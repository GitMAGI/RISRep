using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLib;
using System.Diagnostics;

namespace DAL
{
    public class DBSQL
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                
        static public DataTable ExecuteQuery(string connectionString, string sql)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Setting up ..."));
            //string connectionString = "";
            DataTable dataTable = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                log.Info(string.Format("Opening Connection on '{0}' ...", connectionString));
                connection.Open();
                log.Info(string.Format("Query: {0}", LibString.SQLCommand2String(cmd)));
                log.Info(string.Format("Query execution starting ..."));
                using (var reader = cmd.ExecuteReader())
                {
                    dataTable = new DataTable();
                    dataTable.Load(reader);
                }
                log.Info(string.Format("Query executed! Result count: {0}", dataTable.Rows.Count));
                connection.Close();
                log.Info("Connection Closed!");
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return dataTable;
        }
        static public DataTable ExecuteQueryWithParams(string connectionString, string sql, Dictionary<string, object> atts)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Setting up ..."));
            //string connectionString = "";
            DataTable dataTable = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {                
                foreach (KeyValuePair<string, object> entry in atts)
                {
                    cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                }
                log.Info(string.Format("Opening Connection on '{0}' ...", connectionString));
                connection.Open();
                log.Info(string.Format("Query: {0}", LibString.SQLCommand2String(cmd)));
                log.Info(string.Format("Query execution starting ..."));
                using (var reader = cmd.ExecuteReader())
                {
                    dataTable = new DataTable();
                    dataTable.Load(reader);
                }
                log.Info(string.Format("Query executed! Result count: {0}", dataTable.Rows.Count));
                connection.Close();
                log.Info("Connection Closed!");

            } 
            
            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return dataTable;
        }

        static public int ExecuteNonQuery(string connectionString, string sql)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Setting up ..."));
            int result = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                log.Info(string.Format("Opening Connection on '{0}' ...", connectionString));
                connection.Open();
                log.Info(string.Format("Query: {0}", LibString.SQLCommand2String(cmd)));
                log.Info(string.Format("Query execution starting ..."));
                result = cmd.ExecuteNonQuery();
                log.Info(string.Format("Query executed! Result count: {0}", result));
                connection.Close();
                log.Info("Connection Closed!");
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
        static public int ExecuteNonQueryWithParams(string connectionString, string sql, Dictionary<string, object> atts)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Setting up ..."));
            int result = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {                
                foreach (KeyValuePair<string, object> entry in atts)
                {
                    cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                }
                log.Info(string.Format("Opening Connection on '{0}' ...", connectionString));
                connection.Open();
                log.Info(string.Format("Query: {0}", LibString.SQLCommand2String(cmd)));
                log.Info(string.Format("Query execution starting ..."));
                result = cmd.ExecuteNonQuery();
                log.Info(string.Format("Query executed! Result count: {0}", result));
                connection.Close();
                log.Info("Connection Closed!");
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }    
    }
}
