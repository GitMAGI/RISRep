using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RISDAO : IDAL.IRISDAO
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string HLTDesktopConnectionString = ConfigurationManager.ConnectionStrings["HltDesktop"].ConnectionString;
        private ccDemo_devRISEntities hltCC = new ccDemo_devRISEntities();

        public int SetEsameByPk(Dictionary<string, object> data, string esamidid)
        {
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
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Exception Occurred! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Updated 0 record!"));
            }

            return result;
        }
        public int SetEsameByPk(IDAL.DTO.EsameDTO data, string esamidid)
        {
            int result = 0;
            try
            {
                long esamidid_ = long.Parse(esamidid);
                hlt_esameradio esam = hltCC.hlt_esameradio.First(t => t.esameidid == esamidid_);

                hlt_esameradio data_ = this.EsamMapper(data);

                foreach (System.Reflection.PropertyInfo prop in data_.GetType().GetProperties())
                {
                    if (esam.GetType().GetProperty(prop.Name) != null)
                    {
                        object val = prop.GetValue(data_, null);
                        esam.GetType().GetProperty(prop.Name).SetValue(esam, Convert.ChangeType(val, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType), null);
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

        public int AddEsame(Dictionary<string, object> data)
        {
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
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Exception Occurred! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Updated 0 record!"));
            }
            return result;
        }
        public int AddEsame(IDAL.DTO.EsameDTO data)
        {
            int result = 0;
            try
            {
                hlt_esameradio data_ = this.EsamMapper(data);
                hltCC.hlt_esameradio.Add(data_);
                result = hltCC.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Exception Occurred! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Updated 0 record!"));
            }
            return result;
        }

        public int DeleteEsame(string esamidid)
        {
            int result = 0;
            try
            {
                long esamidid_ = long.Parse(esamidid);
                hlt_esameradio data_ = hltCC.hlt_esameradio.Where(s => s.esameidid == esamidid_).FirstOrDefault<hlt_esameradio>();
                hltCC.Entry(data_).State = System.Data.EntityState.Deleted;
                result = hltCC.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Exception Occurred! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Deleted 0 record!"));
            }

            return result;
        }
        public int DeleteEsame(IDAL.DTO.EsameDTO data)
        {
            int result = 0;

            try
            {
                hlt_esameradio data_ = this.EsamMapper(data);
                hltCC.Entry(data_).State = System.Data.EntityState.Deleted;
                result = hltCC.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Exception Occurred! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Deleted 0 record!"));
            }

            return result;
        }

        public hlt_esameradio EsamMapper(IDAL.DTO.EsameDTO data)
        {
            hlt_esameradio esam = null;

            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.DTO.EsameDTO, hlt_esameradio>());
                Mapper.AssertConfigurationIsValid();
                esam = Mapper.Map<hlt_esameradio>(data);
            }
            catch (AutoMapperConfigurationException ex)
            {
                log.Error(string.Format("AutoMapper Configuration Error!\n{0}", ex.Message));
            }
            catch (AutoMapperMappingException ex)
            {
                log.Error(string.Format("AutoMapper Mapping Error!\n{0}", ex.Message));
            }

            return esam;
        }
    }
}
