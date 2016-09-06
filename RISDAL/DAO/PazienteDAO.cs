using GeneralLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mappers;

namespace DAL
{
    public partial class RISDAL
    {
        public IDAL.VO.PazienteVO GetPazienteById(string pazidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            IDAL.VO.PazienteVO pazi = null;

            try
            {
                string connectionString = this.HLTDesktopConnectionString;

                string query = "SELECT * FROM AnagraficaPazienti WHERE seriale = @seriale";
                Dictionary<string, object> pars = new Dictionary<string, object>();
                pars["seriale"] = pazidid;

                log.Info(string.Format("Query: {0}", query));
                log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

                DataTable data = DAL.DBSQL.ExecuteQueryWithParams(connectionString, query, pars);

                log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));

                if (data != null && data.Rows.Count == 1)
                {
                    DataRow row = data.Rows[0];
                                        
                    pazi = PazienteMapper.PaziMapper(row);

                    log.Info(string.Format("Record mapped to {0}", pazi.GetType().ToString()));
                }
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return pazi;
        }
        
    }
}
