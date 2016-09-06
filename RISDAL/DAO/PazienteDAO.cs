using GeneralLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                    pazi = PaziMapper(row);

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
        
        public IDAL.VO.PazienteVO PaziMapper(DataRow row)
        {
            IDAL.VO.PazienteVO pazi = new IDAL.VO.PazienteVO();

            pazi.archivio = row["archivio"] != DBNull.Value ? (int)row["archivio"] : 0;
            pazi.nominativo = row["nominativo"] != DBNull.Value ? (string)row["nominativo"] : null;
            pazi.coniugata = row["coniugata"] != DBNull.Value ? (string)row["coniugata"] : null;
            pazi.sesso = row["sesso"] != DBNull.Value ? (string)row["sesso"] : null;
            pazi.data_nascita = row["data_nascita"] != DBNull.Value ? (string)row["data_nascita"].ToString() : null;
            pazi.luogo_nascita = row["luogo_nascita"] != DBNull.Value ? (string)row["luogo_nascita"] : null;
            pazi.paese = row["paese"] != DBNull.Value ? (string)row["paese"] : null;
            pazi.indirizzo = row["indirizzo"] != DBNull.Value ? (string)row["indirizzo"] : null;
            pazi.comune = row["comune"] != DBNull.Value ? (string)row["comune"] : null;
            pazi.cap = row["cap"] != DBNull.Value ? (string)row["cap"] : null;
            pazi.prefisso = row["prefisso"] != DBNull.Value ? (string)row["prefisso"] : null;
            pazi.telefono = row["telefono"] != DBNull.Value ? (string)row["telefono"] : null;
            pazi.codice_fiscale = row["codice_fiscale"] != DBNull.Value ? (string)row["codice_fiscale"] : null;
            pazi.paternita = row["paternita"] != DBNull.Value ? (string)row["paternita"] : null;
            pazi.maternita = row["maternita"] != DBNull.Value ? (string)row["maternita"] : null;
            pazi.stato_civile = row["stato_civile"] != DBNull.Value ? (string)row["stato_civile"] : null;
            pazi.professione = row["professione"] != DBNull.Value ? (string)row["professione"] : null;
            pazi.documento = row["documento"] != DBNull.Value ? (string)row["documento"] : null;
            pazi.luogo_documento = row["luogo_documento"] != DBNull.Value ? (string)row["luogo_documento"] : null;
            pazi.data_documento = row["data_documento"] != DBNull.Value ? (string)row["data_documento"].ToString() : null;
            pazi.domicilio = row["domicilio"] != DBNull.Value ? (string)row["domicilio"] : null;
            pazi.comune_domicilio = row["comune_domicilio"] != DBNull.Value ? (string)row["comune_domicilio"] : null;
            pazi.responsabile = row["responsabile"] != DBNull.Value ? (string)row["responsabile"] : null;
            pazi.indirizzo_resp = row["indirizzo_resp"] != DBNull.Value ? (string)row["indirizzo_resp"] : null;
            pazi.comune_resp = row["comune_resp"] != DBNull.Value ? (string)row["comune_resp"] : null;
            pazi.telefono_resp = row["telefono_resp"] != DBNull.Value ? (string)row["telefono_resp"] : null;
            pazi.curante = row["curante"] != DBNull.Value ? (int)row["curante"] : 0;
            pazi.seriale = row["seriale"] != DBNull.Value ? (int)row["seriale"] : 0;
            pazi.apazext = row["apazext"] != DBNull.Value ? (string)row["apazext"] : null;
            pazi.email = row["email"] != DBNull.Value ? (string)row["email"] : null;
            pazi.cellulare = row["cellulare"] != DBNull.Value ? (string)row["cellulare"] : null;
            pazi.tessera_cee = row["tessera_cee"] != DBNull.Value ? (string)row["tessera_cee"] : null;
            pazi.data_cert = row["data_cert"] != DBNull.Value ? (string)row["data_cert"].ToString() : null;
            pazi.data_creazione = row["data_creazione"] != DBNull.Value ? (string)row["data_creazione"].ToString() : null;
            pazi.Export = row["Export"] != DBNull.Value ? (bool)row["Export"] : false;
            pazi.dovuto = row["dovuto"] != DBNull.Value ? (double)row["dovuto"] : 0;
            pazi.speciale = row["speciale"] != DBNull.Value ? (bool)row["speciale"] : false;
            pazi.dovuto_privato = row["dovuto_privato"] != DBNull.Value ? (double)row["dovuto_privato"] : 0;
            pazi.dovuto_assicurato = row["dovuto_assicurato"] != DBNull.Value ? (double)row["dovuto_assicurato"] : 0;
            pazi.note = row["note"] != DBNull.Value ? (string)row["note"] : null;
            pazi.hash = row["hash"] != DBNull.Value ? (byte[])row["hash"] : null;
            pazi.dt_agg = row["dt_agg"] != DBNull.Value ? (string)row["dt_agg"].ToString() : null;
            pazi.citta_nascita = row["citta_nascita"] != DBNull.Value ? (string)row["citta_nascita"] : null;
            pazi.citta_residenza = row["citta_residenza"] != DBNull.Value ? (string)row["citta_residenza"] : null;

            return pazi;
        }
    }
}
