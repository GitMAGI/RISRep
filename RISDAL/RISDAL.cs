﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RISDAL : IDAL.IRISDAL
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string HLTDesktopConnectionString = ConfigurationManager.ConnectionStrings["HltDesktop"].ConnectionString;      
        private ccDemo_devRISEntities hltCC = new ccDemo_devRISEntities();
        
        public IDAL.DTO.PazienteDTO GetPazienteById(string pazidid)
        {
            string connectionString = this.HLTDesktopConnectionString;
            IDAL.DTO.PazienteDTO pazi = null;

            string query = "SELECT * FROM AnagraficaPazienti WHERE seriale = @seriale";
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars["seriale"] = pazidid;

            log.Info(string.Format("Query: {0}", query));
            log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

            DataTable data = DAO.DBSQLLayer.ExecuteQueryWithParams(connectionString, query, pars);

            
            log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));

            if (data != null && data.Rows.Count == 1)
            {
                DataRow row = data.Rows[0];

                pazi = PaziMapper(row);

                log.Info("Record mapped to PazienteDTO");
            }

            return pazi;
        }
        public IDAL.DTO.EpisodioDTO GetEpisodioById(string episidid) 
        {
            string connectionString = this.HLTDesktopConnectionString;
            IDAL.DTO.EpisodioDTO epis = null;

            string query = "SELECT * FROM Episodi WHERE seriale = @seriale";
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars["seriale"] = episidid;

            log.Info(string.Format("Query: {0}", query));
            log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

            DataTable data = DAO.DBSQLLayer.ExecuteQueryWithParams(connectionString, query, pars);

            log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));

            if (data != null && data.Rows.Count == 1)
            {
                DataRow row = data.Rows[0];

                epis = EpisMapper(row);

                log.Info("Record mapped to EpisodioDTO");
            }
            return epis;
        }
        public IDAL.DTO.RichiestaRISDTO GetRichiestaById(string richidid)
        {
            IDAL.DTO.RichiestaRISDTO rich = null;
            try
            {
                hlt_ricradiologica rich_ = hltCC.hlt_ricradiologica.Single(t => t.objectid == richidid);
                log.Info(string.Format("Query Executed! Retrieved 1 record!"));
                rich = this.RichMapper(rich_);
                log.Info("Record mapped to EpisodioDTO");
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("EntityFramework returned an Exception! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
            }
            return rich;            
        }
        public List<IDAL.DTO.RichiestaRISDTO> GetRichiesteByEpis(string episidid)
        {
            List<IDAL.DTO.RichiestaRISDTO> rich = null;            
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
                rich = new List<IDAL.DTO.RichiestaRISDTO>();

                List<hlt_ricradiologica> richs_ = hltCC.hlt_ricradiologica.Where(t => t.idepisodio == episidid).ToList();

                log.Info(string.Format("Query Executed! Retrieved {0} record!", richs_.Count));

                foreach (hlt_ricradiologica rich_ in richs_)
                {
                    rich.Add(this.RichMapper(rich_));
                }
                
                log.Info("Records mapped to EpisodioDTO");
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("EntityFramework returned an Exception! \n{0}", ex.Message));
                log.Info(string.Format("Query Executed! Retrieved 0 record!"));
            }

            return rich;
        }
        public List<IDAL.DTO.EsameDTO> GetEsamiByRich(string richidid)
        {
            List<IDAL.DTO.EsameDTO> esam = null;
            try
            {
                IDAL.DTO.RichiestaRISDTO rich = (IDAL.DTO.RichiestaRISDTO)this.GetRichiestaById(richidid);

                if (rich != null)
                {
                    string esamsID = rich.esami;
                    string esamsDesc = rich.nomeesami;

                    if (!(string.IsNullOrEmpty(esamsID)) && !(string.IsNullOrEmpty(esamsDesc)))
                    {
                        string[] esamsIDs = esamsID.Split(',').ToArray<string>();
                        string[] esamsDescs = esamsDesc.Split(',').ToArray<string>();

                        // Mapper Integrato. Da Implementare in caso di Tabella Esami fisica
                        esam = new List<IDAL.DTO.EsameDTO>();
                        for(int i = 0; i<esamsIDs.Length; i++){
                            string id = esamsIDs[i];
                            string desc = esamsDescs[i];

                            IDAL.DTO.EsameDTO tmp = new IDAL.DTO.EsameDTO();
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
        public List<IDAL.DTO.EsameDTO> GetEsamiByEpis(string episidid)
        {
            List<IDAL.DTO.EsameDTO> esam = null;
            try
            {
                List<IDAL.DTO.RichiestaRISDTO> richs = (List<IDAL.DTO.RichiestaRISDTO>)this.GetRichiesteByEpis(episidid);

                if (richs != null)
                {
                    esam = new List<IDAL.DTO.EsameDTO>();
                    foreach(IDAL.DTO.RichiestaRISDTO rich in richs){
                        List<IDAL.DTO.EsameDTO> tmp = (List<IDAL.DTO.EsameDTO>)this.GetEsamiByRich(rich.objectid);

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

        public IDAL.DTO.PazienteDTO PaziMapper(DataRow row)
        {
            IDAL.DTO.PazienteDTO pazi = new IDAL.DTO.PazienteDTO();

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
        public IDAL.DTO.RichiestaRISDTO RichMapper(hlt_ricradiologica data)
        {
            IDAL.DTO.RichiestaRISDTO rich = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<hlt_ricradiologica, IDAL.DTO.RichiestaRISDTO>());
                Mapper.AssertConfigurationIsValid();
                rich = Mapper.Map<IDAL.DTO.RichiestaRISDTO>(data);
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
        public List<IDAL.DTO.RichiestaRISDTO> RichMapper(DataRow[] rows)
        {
            List<IDAL.DTO.RichiestaRISDTO> rich = null;
            if (rows != null)
            {
                rich = new List<IDAL.DTO.RichiestaRISDTO>();                
                foreach(DataRow row in rows){
                    rich.Add(this.RichMapper(row));                    
                }
            }
            return rich;   
        }
        public IDAL.DTO.RichiestaRISDTO RichMapper(DataRow row)
        {
            IDAL.DTO.RichiestaRISDTO esam = new IDAL.DTO.RichiestaRISDTO();

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
        public IDAL.DTO.EpisodioDTO EpisMapper(DataRow row)
        {
            IDAL.DTO.EpisodioDTO epis = new IDAL.DTO.EpisodioDTO();

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



        /*
        void test()
        {
            hlt_certificato pp = hltCC.hlt_certificato.First(t => t.objectid == "xxdx");

            pp.prescrizione = "aaa";
            hltCC.SaveChanges();
        }
        */
    }
}
