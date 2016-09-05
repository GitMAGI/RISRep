using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class RISDAL
    {
        public IDAL.VO.RichiestaRISVO GetRichiestaById(string richidid)
        {
            IDAL.VO.RichiestaRISVO rich = null;
            try
            {
                hlt_ricradiologica rich_ = hltCC.hlt_ricradiologica.Single(t => t.objectid == richidid);
                log.Info(string.Format("Query Executed! Retrieved 1 record!"));
                rich = this.RichMapper(rich_);
                log.Info(string.Format("Record mapped to {0}", rich.GetType().ToString()));
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("EntityFramework returned an Exception! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
            }
            return rich;
        }
        public List<IDAL.VO.RichiestaRISVO> GetRichiesteByEpis(string episidid)
        {
            List<IDAL.VO.RichiestaRISVO> rich = null;
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
                rich = new List<IDAL.VO.RichiestaRISVO>();

                List<hlt_ricradiologica> richs_ = hltCC.hlt_ricradiologica.Where(t => t.idepisodio == episidid).ToList();

                log.Info(string.Format("Query Executed! Retrieved {0} record!", richs_.Count));

                foreach (hlt_ricradiologica rich_ in richs_)
                {
                    rich.Add(this.RichMapper(rich_));
                }

                log.Info(string.Format("Record mapped to {0}", rich.GetType().ToString()));
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("EntityFramework returned an Exception! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
            }

            return rich;
        }
        public int UpdateRichiestaByPk(IDAL.VO.RichiestaRISVO data, string richidid)
        {
            int result = 0;
            try
            {                
                hlt_ricradiologica rich = hltCC.hlt_ricradiologica.First(t => t.objectid == richidid);

                hlt_ricradiologica data_ = this.RichMapper(data);

                foreach (System.Reflection.PropertyInfo prop in data_.GetType().GetProperties())
                {
                    if (rich.GetType().GetProperty(prop.Name) != null)
                    {
                        object val = prop.GetValue(data_, null);
                        rich.GetType().GetProperty(prop.Name).SetValue(rich, Convert.ChangeType(val, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType), null);
                    }
                }

                result = hltCC.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Exception Occurred! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Updated 0 record!"));
            }

            return result;
        }
        
        public IDAL.VO.RichiestaRISVO RichMapper(hlt_ricradiologica data)
        {
            IDAL.VO.RichiestaRISVO rich = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<hlt_ricradiologica, IDAL.VO.RichiestaRISVO>());
                Mapper.AssertConfigurationIsValid();
                rich = Mapper.Map<IDAL.VO.RichiestaRISVO>(data);
            }
            catch (AutoMapperConfigurationException ex)
            {
                log.Error(string.Format("AutoMapper Configuration Error!\n{0}", ex.Message));
            }
            catch (AutoMapperMappingException ex)
            {
                log.Error(string.Format("AutoMapper Mapping Error!\n{0}", ex.Message));
            }

            return rich;

        }
        public List<IDAL.VO.RichiestaRISVO> RichMapper(DataRow[] rows)
        {
            List<IDAL.VO.RichiestaRISVO> rich = null;
            if (rows != null)
            {
                rich = new List<IDAL.VO.RichiestaRISVO>();
                foreach (DataRow row in rows)
                {
                    rich.Add(this.RichMapper(row));
                }
            }
            return rich;
        }
        public IDAL.VO.RichiestaRISVO RichMapper(DataRow row)
        {
            IDAL.VO.RichiestaRISVO esam = new IDAL.VO.RichiestaRISVO();

            esam.data = row["data"] != DBNull.Value ? (string)row["data"].ToString() : null;
            esam.data_creazione = row["data_creazione"] != DBNull.Value ? (string)row["data_creazione"].ToString() : null;
            esam.data_modifica = row["data_modifica"] != DBNull.Value ? (string)row["data_modifica"].ToString() : null;
            esam.dimprotetta = row["dimprotetta"] != DBNull.Value ? (bool)row["dimprotetta"] : false;
            esam.esami = row["esami"] != DBNull.Value ? (string)row["esami"] : null;
            esam.idepisodio = row["idepisodio"] != DBNull.Value ? (string)row["idepisodio"] : null;
            esam.locker = row["locker"] != DBNull.Value ? (string)row["locker"] : null;
            esam.motivo = row["motivo"] != DBNull.Value ? (string)row["motivo"] : null;
            esam.nomeesami = row["nomeesami"] != DBNull.Value ? (string)row["nomeesami"] : null;
            esam.nomeutente_creazione = row["nomeutente_creazione"] != DBNull.Value ? (string)row["nomeutente_creazione"] : null;
            esam.nomeutente_modifica = row["nomeutente_modifica"] != DBNull.Value ? (string)row["nomeutente_modifica"] : null;
            esam.objectid = row["objectid"] != DBNull.Value ? (string)row["objectid"] : null;
            esam.ora = row["ora"] != DBNull.Value ? (string)row["ora"] : null;
            esam.pdfcreato = row["pdfcreato"] != DBNull.Value ? (string)row["pdfcreato"] : null;
            esam.quesitoclinico = row["quesitoclinico"] != DBNull.Value ? (string)row["quesitoclinico"] : null;
            esam.seriale = row["seriale"] != DBNull.Value ? (long)row["seriale"] : 0;
            esam.statopaziente = row["statopaziente"] != DBNull.Value ? (string)row["statopaziente"] : null;
            esam.urgente = row["urgente"] != DBNull.Value ? (bool)row["urgente"] : false;
            esam.versione = row["versione"] != DBNull.Value ? (string)row["versione"] : null;

            return esam; ;
        }
        public hlt_ricradiologica RichMapper(IDAL.VO.RichiestaRISVO data)
        {
            hlt_ricradiologica rich = null;

            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.VO.RichiestaRISVO, hlt_ricradiologica>());
                Mapper.AssertConfigurationIsValid();
                rich = Mapper.Map<hlt_ricradiologica>(data);
            }
            catch (AutoMapperConfigurationException ex)
            {
                log.Error(string.Format("AutoMapper Configuration Error!\n{0}", ex.Message));
            }
            catch (AutoMapperMappingException ex)
            {
                log.Error(string.Format("AutoMapper Mapping Error!\n{0}", ex.Message));
            }

            return rich;
        }
    
    }
}
