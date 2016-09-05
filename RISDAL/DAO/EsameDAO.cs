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
        public List<IDAL.VO.EsameVO> GetEsamiByRich(string richidid)
        {
            List<IDAL.VO.EsameVO> esams = null;
            try
            {
                List<hlt_esameradio> esams_ = hltCC.hlt_esameradio.Where(t => t.esamerichid == richidid).ToList();
                log.Info(string.Format("Query Executed! Retrieved {0} record!", esams_.Count));
                esams = this.EsamMapper(esams_);
                log.Info(string.Format("{0} Records mapped to {1}", esams.Count, esams.GetType().ToString()));
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("EntityFramework returned an Exception! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
            }
            return esams;
        }
        public List<IDAL.VO.EsameVO> GetEsamiByEpis(string episidid)
        {
            List<IDAL.VO.EsameVO> esams = null;
            try
            {
                var L2EQuery = from e in hltCC.hlt_esameradio join r in hltCC.hlt_ricradiologica on e.esamerichid equals r.objectid where r.idepisodio.Equals(episidid) select e;

                List<hlt_esameradio> esams_ = L2EQuery.ToList();
                log.Info(string.Format("Query Executed! Retrieved {0} record!", esams_.Count));
                esams = this.EsamMapper(esams_);
                log.Info(string.Format("{0} Records mapped to EsameDTO", esams.Count));

            }
            catch (Exception ex)
            {
                log.Warn(string.Format("EntityFramework returned an Exception! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
            }
            return esams;
        }
        public IDAL.VO.EsameVO GetEsameById(string esamidid)
        {
            IDAL.VO.EsameVO esam = null;
            try
            {
                long esamidid_ = long.Parse(esamidid);
                hlt_esameradio esam_ = hltCC.hlt_esameradio.Single(t => t.esameidid == esamidid_);
                log.Info(string.Format("Query Executed! Retrieved 1 record!"));
                esam = this.EsamMapper(esam_);
                log.Info("Record mapped to EsameDTO");
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("EntityFramework returned an Exception! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
            }
            return esam;
        }
        public int UpdateEsameByPk(Dictionary<string, object> data, string esamidid)
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
        public int UpdateEsameByPk(IDAL.VO.EsameVO data, string esamidid)
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
        public int AddEsame(IDAL.VO.EsameVO data)
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
        public int DeleteEsame(IDAL.VO.EsameVO data)
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

        public IDAL.VO.EpisodioVO EpisMapper(DataRow row)
        {
            IDAL.VO.EpisodioVO epis = new IDAL.VO.EpisodioVO();

            epis.codice = row["codice"] != DBNull.Value ? (int)row["codice"] : 0;
            epis.cartella = row["cartella"] != DBNull.Value ? (string)row["cartella"] : null;
            epis.tipo = row["tipo"] != DBNull.Value ? (string)row["tipo"] : null;
            epis.data = row["data"] != DBNull.Value ? (string)row["data"].ToString() : null;
            epis.ora = row["ora"] != DBNull.Value ? (string)row["ora"].ToString() : null;
            epis.dimissione = row["dimissione"] != DBNull.Value ? (string)row["dimissione"].ToString() : null;
            epis.ora_dimiss = row["ora_dimiss"] != DBNull.Value ? (string)row["ora_dimiss"].ToString() : null;
            epis.camera = row["camera"] != DBNull.Value ? (string)row["camera"] : null;
            epis.reparto = row["reparto"] != DBNull.Value ? (string)row["reparto"] : null;
            epis.convenzione1 = row["convenzione1"] != DBNull.Value ? (string)row["convenzione1"] : null;
            epis.convenzione2 = row["convenzione2"] != DBNull.Value ? (string)row["convenzione2"] : null;
            epis.impegnativa = row["impegnativa"] != DBNull.Value ? (string)row["impegnativa"] : null;
            epis.data_impegn = row["data_impegn"] != DBNull.Value ? (string)row["data_impegn"].ToString() : null;
            epis.giorni = row["giorni"] != DBNull.Value ? (short)row["giorni"] : (short)0;
            epis.usl = row["usl"] != DBNull.Value ? (string)row["usl"] : null;
            epis.regione = row["regione"] != DBNull.Value ? (string)row["regione"] : null;
            epis.tessera = row["tessera"] != DBNull.Value ? (string)row["tessera"] : null;
            epis.diagnosi = row["diagnosi"] != DBNull.Value ? (string)row["diagnosi"] : null;
            epis.provenienza = row["provenienza"] != DBNull.Value ? (string)row["provenienza"] : null;
            epis.regime = row["regime"] != DBNull.Value ? (string)row["regime"] : null;
            epis.inviante = row["inviante"] != DBNull.Value ? (int)row["inviante"] : 0;
            epis.accettante = row["accettante"] != DBNull.Value ? (int)row["accettante"] : 0;
            epis.consegna = row["consegna"] != DBNull.Value ? (string)row["consegna"].ToString() : null;
            epis.totale = row["totale"] != DBNull.Value ? (double)row["totale"] : 0;
            epis.dovuto = row["dovuto"] != DBNull.Value ? (double)row["dovuto"] : 0;
            epis.acconto = row["acconto"] != DBNull.Value ? (double)row["acconto"] : 0;
            epis.stato = row["stato"] != DBNull.Value ? (string)row["stato"] : null;
            epis.tipo_stato = row["tipo_stato"] != DBNull.Value ? (string)row["tipo_stato"] : null;
            epis.seriale = row["seriale"] != DBNull.Value ? (int)row["seriale"] : 0;
            epis.privacy = row["privacy"] != DBNull.Value ? (short)row["privacy"] : (short)0;
            epis.anonimato = row["anonimato"] != DBNull.Value ? (short)row["anonimato"] : (short)0;
            epis.data_open = row["data_open"] != DBNull.Value ? (string)row["data_open"].ToString() : null;
            epis.pazext = row["pazext"] != DBNull.Value ? (string)row["pazext"] : null;
            epis.argos_nos = row["argos_nos"] != DBNull.Value ? (string)row["argos_nos"] : null;
            epis.bloccato = row["bloccato"] != DBNull.Value ? (string)row["bloccato"] : null;
            epis.id_invio = row["id_invio"] != DBNull.Value ? (short)row["id_invio"] : (short)0;
            epis.dt_invio = row["dt_invio"] != DBNull.Value ? (string)row["dt_invio"] : null;
            epis.dt_pren = row["dt_pren"] != DBNull.Value ? (string)row["dt_pren"] : null;
            epis.dt_rice = row["dt_rice"] != DBNull.Value ? (string)row["dt_rice"] : null;
            epis.circoscrizione = row["circoscrizione"] != DBNull.Value ? (string)row["circoscrizione"] : null;
            epis.pnome = row["pnome"] != DBNull.Value ? (string)row["pnome"] : null;
            epis.pcognome = row["pcognome"] != DBNull.Value ? (string)row["pcognome"] : null;
            epis.pluogo_nascita = row["pluogo_nascita"] != DBNull.Value ? (string)row["pluogo_nascita"] : null;
            epis.ppaese = row["ppaese"] != DBNull.Value ? (string)row["ppaese"] : null;
            epis.pindirizzo = row["pindirizzo"] != DBNull.Value ? (string)row["pindirizzo"] : null;
            epis.pcomune = row["pcomune"] != DBNull.Value ? (string)row["pcomune"] : null;
            epis.pcap = row["pcap"] != DBNull.Value ? (string)row["pcap"] : null;
            epis.pprefisso = row["pprefisso"] != DBNull.Value ? (string)row["pprefisso"] : null;
            epis.ptelefono = row["ptelefono"] != DBNull.Value ? (string)row["ptelefono"] : null;
            epis.pcodice_fiscale = row["pcodice_fiscale"] != DBNull.Value ? (string)row["pcodice_fiscale"] : null;
            epis.pstato_civile = row["pstato_civile"] != DBNull.Value ? (string)row["pstato_civile"] : null;
            epis.pprofessione = row["pprofessione"] != DBNull.Value ? (string)row["pprofessione"] : null;
            epis.pdocumento = row["pdocumento"] != DBNull.Value ? (string)row["pdocumento"] : null;
            epis.pluogo_documento = row["pluogo_documento"] != DBNull.Value ? (string)row["pluogo_documento"] : null;
            epis.pdata_documento = row["pdata_documento"] != DBNull.Value ? (string)row["pdata_documento"] : null;
            epis.pdomicilio = row["pdomicilio"] != DBNull.Value ? (string)row["pdomicilio"] : null;
            epis.pcomune_domicilio = row["pcomune_domicilio"] != DBNull.Value ? (string)row["pcomune_domicilio"] : null;
            epis.pcurante = row["pcurante"] != DBNull.Value ? (int)row["pcurante"] : 0;
            epis.ImportoServizioDefault = row["ImportoServizioDefault"] != DBNull.Value ? (double)row["ImportoServizioDefault"] : 0;
            epis.domicilio_cap = row["domicilio_cap"] != DBNull.Value ? (string)row["domicilio_cap"] : null;
            epis.domicilio_comune = row["domicilio_comune"] != DBNull.Value ? (string)row["domicilio_comune"] : null;
            epis.domicilio_indirizzo = row["domicilio_indirizzo"] != DBNull.Value ? (string)row["domicilio_indirizzo"] : null;
            epis.domicilio_distretto = row["domicilio_distretto"] != DBNull.Value ? (string)row["domicilio_distretto"] : null;
            epis.cl_coge = row["cl_coge"] != DBNull.Value ? (string)row["cl_coge"] : null;
            epis.gestore = row["gestore"] != DBNull.Value ? (int)row["gestore"] : 0;
            epis.dovuto_privato = row["dovuto_privato"] != DBNull.Value ? (double)row["dovuto_privato"] : 0;
            epis.dovuto_assicurato = row["dovuto_assicurato"] != DBNull.Value ? (double)row["dovuto_assicurato"] : 0;

            return epis;
        }
        public IDAL.VO.EsameVO EsamMapper(hlt_esameradio data)
        {
            IDAL.VO.EsameVO esam = null;

            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<hlt_esameradio, IDAL.VO.EsameVO>());
                Mapper.AssertConfigurationIsValid();
                esam = Mapper.Map<IDAL.VO.EsameVO>(data);
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
        public List<IDAL.VO.EsameVO> EsamMapper(List<hlt_esameradio> data)
        {
            List<IDAL.VO.EsameVO> esams = null;

            if (data != null && data.Count > 0)
            {
                esams = new List<IDAL.VO.EsameVO>();

                foreach (hlt_esameradio datum in data)
                {
                    IDAL.VO.EsameVO tmp = null;

                    tmp = this.EsamMapper(datum);

                    if (tmp != null)
                        esams.Add(tmp);
                }
            }

            return esams;
        }
        public hlt_esameradio EsamMapper(IDAL.VO.EsameVO data)
        {
            hlt_esameradio esam = null;

            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.VO.EsameVO, hlt_esameradio>());
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
