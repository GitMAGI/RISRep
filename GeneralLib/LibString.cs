using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLib
{
    public static class LibString
    {
        public static string TimeSpanToTimeHmsms(TimeSpan ts)
        {
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                ts.Hours,
                ts.Minutes,
                ts.Seconds,
                ts.Milliseconds);

            return elapsedTime;
        }

        static public bool IsNumericType(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        static public string SQLCommand2String(SqlCommand cmd)
        {
            string result = "";
            if (cmd.CommandType == System.Data.CommandType.StoredProcedure)
            {
                result = "exec " + cmd.CommandText + " ";
            }
            else
            {
                result = cmd.CommandText + " ";
            }
           
            int _l = 1;
            foreach (SqlParameter p in cmd.Parameters)
            {
                string pv = IsNumericType(p.Value) == true ? p.ParameterName + " = " + p.Value.ToString() : p.ParameterName + " = '" + p.Value.ToString() + "'";
                result += pv;
                if (_l < cmd.Parameters.Count)
                    result += ", ";
                _l++;
            }
            return result;
        }
    }
}
