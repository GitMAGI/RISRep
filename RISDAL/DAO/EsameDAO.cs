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
        public List<IDAL.VO.EsameVO> GetEsamiByRich(string richidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            List<IDAL.VO.EsameVO> esams = null;
            try
            {
                List<hlt_esameradio> esams_ = hltCC.hlt_esameradio.Where(t => t.esamerichid == richidid).ToList();
                log.Info(string.Format("Entity Framework Query Executed! Retrieved {0} record!", esams_.Count));
                esams = EsameMapper.EsamMapper(esams_);
                log.Info(string.Format("{0} Records mapped to {1}", esams.Count, esams.First().GetType().ToString()));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Entity Framework Query Executed! Retrieved 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return esams;
        }
        public List<IDAL.VO.EsameVO> GetEsamiByEpis(string episidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            List<IDAL.VO.EsameVO> esams = null;
            try
            {
                var L2EQuery = from e in hltCC.hlt_esameradio join r in hltCC.hlt_ricradiologica on e.esamerichid equals r.objectid where r.idepisodio.Equals(episidid) select e;

                List<hlt_esameradio> esams_ = L2EQuery.ToList();
                log.Info(string.Format("Entity Framework Query Executed! Retrieved {0} record!", esams_.Count));
                esams = EsameMapper.EsamMapper(esams_);
                log.Info(string.Format("{0} Records mapped to {1}", esams.Count, esams.First().GetType().ToString()));   

            }
            catch (Exception ex)
            {
                log.Info(string.Format("Entity Framework Query Executed! Retrieved 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return esams;
        }
        public IDAL.VO.EsameVO GetEsameById(string esamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            IDAL.VO.EsameVO esam = null;
            try
            {
                long esamidid_ = long.Parse(esamidid);
                hlt_esameradio esam_ = hltCC.hlt_esameradio.Single(t => t.esameidid == esamidid_);
                log.Info(string.Format("Entity Framework Query Executed! Retrieved 1 record!"));
                esam = EsameMapper.EsamMapper(esam_);
                log.Info(string.Format("Record mapped to {0}", esam.GetType().ToString()));                
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Entity Framework Query Executed! Retrieved 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return esam;
        }
        public int UpdateEsameByPk(Dictionary<string, object> data, string esamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;
            try
            {
                long esamidid_ = long.Parse(esamidid);
                hlt_esameradio esam = hltCC.hlt_esameradio.First(t => t.esameidid == esamidid_);

                foreach (KeyValuePair<string, object> d_ in data)
                {
                    string origPName = d_.Key;
                    object val = d_.Value;
                    string destPName = origPName;

                    System.Reflection.PropertyInfo prop = esam.GetType().GetProperty(destPName);

                    if (prop != null)
                    {
                        prop.SetValue(esam, Convert.ChangeType(val, prop.PropertyType), null);
                    }
                }

                result = hltCC.SaveChanges();
                log.Info(string.Format("Entity Framework Query Executed! Updated {0} record!", result));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Entity Framework Query Executed! Updated 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
        public int UpdateEsameByPk(IDAL.VO.EsameVO data, string esamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;
            try
            {
                long esamidid_ = long.Parse(esamidid);
                hlt_esameradio esam = hltCC.hlt_esameradio.First(t => t.esameidid == esamidid_);

                hlt_esameradio data_ = EsameMapper.EsamMapper(data);

                foreach (System.Reflection.PropertyInfo prop in data_.GetType().GetProperties())
                {
                    if (esam.GetType().GetProperty(prop.Name) != null)
                    {
                        object val = prop.GetValue(data_, null);
                        esam.GetType().GetProperty(prop.Name).SetValue(esam, Convert.ChangeType(val, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType), null);
                    }
                }

                result = hltCC.SaveChanges();
                log.Info(string.Format("Entity Framework Query Executed! Updated {0} record!", result));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Entity Framework Query Executed! Updated 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
        public int AddEsame(Dictionary<string, object> data)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;
            try
            {
                hlt_esameradio esam = new hlt_esameradio();

                foreach (KeyValuePair<string, object> d_ in data)
                {
                    string origPName = d_.Key;
                    object val = d_.Value;
                    string destPName = origPName;

                    System.Reflection.PropertyInfo prop = esam.GetType().GetProperty(destPName);

                    if (prop != null)
                    {
                        prop.SetValue(esam, Convert.ChangeType(val, prop.PropertyType), null);
                    }
                }

                hltCC.hlt_esameradio.Add(esam);
                result = hltCC.SaveChanges();
                log.Info(string.Format("Entity Framework Query Executed! Added {0} record!", result));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Entity Framework Query Executed! Added 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
        public int AddEsame(IDAL.VO.EsameVO data)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;
            try
            {
                hlt_esameradio data_ = EsameMapper.EsamMapper(data);
                hltCC.hlt_esameradio.Add(data_);
                result = hltCC.SaveChanges();
                log.Info(string.Format("Entity Framework Query Executed! Added {0} record!", result));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Entity Framework Query Executed! Added 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
        public int DeleteEsame(string esamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;
            try
            {
                long esamidid_ = long.Parse(esamidid);
                hlt_esameradio data_ = hltCC.hlt_esameradio.Where(s => s.esameidid == esamidid_).FirstOrDefault<hlt_esameradio>();
                hltCC.Entry(data_).State = System.Data.EntityState.Deleted;
                result = hltCC.SaveChanges();
                log.Info(string.Format("Entity Framework Query Executed! Deleted {0} record!", result));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Entity Framework Query Executed! Deleted 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
        public int DeleteEsame(IDAL.VO.EsameVO data)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;

            try
            {
                hlt_esameradio data_ = EsameMapper.EsamMapper(data);
                hltCC.Entry(data_).State = System.Data.EntityState.Deleted;
                result = hltCC.SaveChanges();
                log.Info(string.Format("Entity Framework Query Executed! Deleted {0} record!", result));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Entity Framework Query Executed! Deleted 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }

        /*
        public List<IDAL.VO.EsameVO> GetEsamiByRich(string richidid)
        {
            List<IDAL.VO.EsameVO> esam = null;
            try
            {
                IDAL.VO.RichiestaRISVO rich = (IDAL.VO.RichiestaRISVO)this.GetRichiestaById(richidid);

                if (rich != null)
                {
                    string esamsID = rich.esami;
                    string esamsDesc = rich.nomeesami;

                    if (!(string.IsNullOrEmpty(esamsID)) && !(string.IsNullOrEmpty(esamsDesc)))
                    {
                        string[] esamsIDs = esamsID.Split(',').ToArray<string>();
                        string[] esamsDescs = esamsDesc.Split(',').ToArray<string>();

                        // Mapper Integrato. Da Implementare in caso di Tabella Esami fisica
                        esam = new List<IDAL.VO.EsameVO>();
                        for(int i = 0; i<esamsIDs.Length; i++){
                            string id = esamsIDs[i];
                            string desc = esamsDescs[i];

                            IDAL.DTO.EsameVO tmp = new IDAL.VO.EsameVO();
                            tmp.esamidid = id;
                            tmp.esamdesc = desc;

                            esam.Add(tmp);
                        }
                    }
                }
                rich = null;                
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("EntityFramework returned an Exception! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
            }

            return esam;
        }
        public List<IDAL.VO.EsameVO> GetEsamiByEpis(string episidid)
        {
            List<IDAL.VO.EsameVO> esam = null;
            try
            {
                List<IDAL.VO.RichiestaRISVO> richs = (List<IDAL.VO.RichiestaRISVO>)this.GetRichiesteByEpis(episidid);

                if (richs != null)
                {
                    esam = new List<IDAL.VO.EsameVO>();
                    foreach(IDAL.VO.RichiestaRISDTO rich in richs){
                        List<IDAL.VO.EsameVO> tmp = (List<IDAL.VO.EsameVO>)this.GetEsamiByRich(rich.objectid);

                        if (tmp != null)
                        {
                            esam.AddRange(tmp);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Warn(string.Format("EntityFramework returned an Exception! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
            }

            return esam;
        }
        */
}
}
