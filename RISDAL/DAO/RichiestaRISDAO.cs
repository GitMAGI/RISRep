using AutoMapper;
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
        public IDAL.VO.RichiestaRISVO GetRichiestaById(string richidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            IDAL.VO.RichiestaRISVO rich = null;
            try
            {
                hlt_ricradiologica rich_ = hltCC.hlt_ricradiologica.Single(t => t.objectid == richidid);
                log.Info(string.Format("Query Executed! Retrieved 1 record!"));
                rich = RichiestaRISMapper.RichMapper(rich_);
                log.Info(string.Format("Record mapped to {0}", rich.GetType().ToString()));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return rich;
        }
        public List<IDAL.VO.RichiestaRISVO> GetRichiesteByEpis(string episidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            List<IDAL.VO.RichiestaRISVO> richs = null;
            try
            {
                /*           
                var res = hltCC.hlt_ricradiologica.Where(t => t.idepisodio == episidid).Select(
                        p => new IDAL.DTO.RichiestaRISDTO()
                        {
                            data = ((DateTime)p.data).ToShortDateString(),
                            idepisodio = p.idepisodio
                        }
                    );  
                */
                /*
                // Ricerca se almeno un record esiste restituendo true o false. Il suo uso evita che il first o il tolist su un null generino eccezione!
                if(hltCC.hlt_ricradiologica.Where(t => t.idepisodio == episidid).Any()){

                }                 
                */
                richs = new List<IDAL.VO.RichiestaRISVO>();

                List<hlt_ricradiologica> richs_ = hltCC.hlt_ricradiologica.Where(t => t.idepisodio == episidid).ToList();

                log.Info(string.Format("Query Executed! Retrieved {0} record!", richs_.Count));

                foreach (hlt_ricradiologica rich_ in richs_)
                {
                    richs.Add(RichiestaRISMapper.RichMapper(rich_));
                }
                log.Info(string.Format("{0} Records mapped to {1}", richs.Count, richs.First().GetType().ToString()));  
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return richs;
        }
        public int UpdateRichiestaByPk(IDAL.VO.RichiestaRISVO data, string richidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;
            try
            {                
                hlt_ricradiologica rich = hltCC.hlt_ricradiologica.First(t => t.objectid == richidid);

                hlt_ricradiologica data_ = RichiestaRISMapper.RichMapper(data);

                foreach (System.Reflection.PropertyInfo prop in data_.GetType().GetProperties())
                {
                    if (rich.GetType().GetProperty(prop.Name) != null)
                    {
                        object val = prop.GetValue(data_, null);
                        rich.GetType().GetProperty(prop.Name).SetValue(rich, Convert.ChangeType(val, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType), null);
                    }
                }

                result = hltCC.SaveChanges();
                log.Info(string.Format("Query Executed! Updated {0} record!", result));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Query Executed! Updated 0 record!"));
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
        
    }
}
