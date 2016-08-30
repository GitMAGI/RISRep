using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RISBLL : IBLL.IRISBLL
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IDAL.IRISDAL dal;
        private IDAL.IRISDAO dao;

        public RISBLL(IDAL.IRISDAL IDAL, IDAL.IRISDAO IDAO)
        {
            this.dal = IDAL;
            this.dao = IDAO;
        }

        public IBLL.DTO.PazienteDTO GetPazienteById(string id)
        {
            IDAL.DTO.PazienteDTO dalRes = this.dal.GetPazienteById(id);
            return this.PaziMapper(dalRes);
        }

        public IBLL.DTO.EpisodioDTO GetEpisodioById(string id)
        {
            IDAL.DTO.EpisodioDTO dalRes = this.dal.GetEpisodioById(id);
            return this.EpisMapper(dalRes);
        }

        public List<IBLL.DTO.RichiestaRISDTO> GetRichiesteRISByEpis(string episid)
        {
            List<IDAL.DTO.RichiestaRISDTO> dalRes = this.dal.GetRichiesteByEpis(episid);
            return this.RichMapper(dalRes);
        }

        public IBLL.DTO.RichiestaRISDTO GetRichiestaRISById(string richidid)
        {
            IDAL.DTO.RichiestaRISDTO dalRes = this.dal.GetRichiestaById(richidid);
            return this.RichMapper(dalRes);
        }

        public List<IBLL.DTO.EsameDTO> GetEsamiByRich(string richidid)
        {
            List<IDAL.DTO.EsameDTO> dalRes = this.dal.GetEsamiByRich(richidid);
            return this.EsamMapper(dalRes);
        }

        public List<IBLL.DTO.EsameDTO> GetEsamiByEpis(string episidid)
        {
            List<IDAL.DTO.EsameDTO> dalRes = this.dal.GetEsamiByEpis(episidid);
            return this.EsamMapper(dalRes);
        }

        public IBLL.DTO.EsameDTO GetEsameById(string esamidid)
        {
            IDAL.DTO.EsameDTO dalRes = this.dal.GetEsameById(esamidid);
            return this.EsamMapper(dalRes);
        }

        public int UpdateEsameById(IBLL.DTO.EsameDTO data, string esamidid)
        {
            int result = 0;

            IDAL.DTO.EsameDTO data_ = this.EsamUnMapper(data);
            result = dao.SetEsameByPk(data_, esamidid);

            return result;
        }

        public int AddEsame(IBLL.DTO.EsameDTO data)
        {
            int result = 0;

            IDAL.DTO.EsameDTO data_ = this.EsamUnMapper(data);
            result = dao.AddEsame(data_);

            return result;
        }

        public int DeleteEsameById(string esamidid)
        {
            int result = 0;

            result = dao.DeleteEsame(esamidid);

            return result;
        }
        
        // Mappers
        
        public IBLL.DTO.PazienteDTO PaziMapper(IDAL.DTO.PazienteDTO raw)
        {
            IBLL.DTO.PazienteDTO pazi = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.DTO.PazienteDTO, IBLL.DTO.PazienteDTO>());
                Mapper.AssertConfigurationIsValid();
                pazi = Mapper.Map<IBLL.DTO.PazienteDTO>(raw);
            }
            catch (AutoMapperConfigurationException ex)
            {
                log.Error(string.Format("AutoMapper Configuration Error!\n{0}", ex.Message));
            }
            catch (AutoMapperMappingException ex)
            {
                log.Error(string.Format("AutoMapper Mapping Error!\n{0}", ex.Message));
            }

            return pazi;
        }

        public IBLL.DTO.EpisodioDTO EpisMapper(IDAL.DTO.EpisodioDTO raw)
        {            
            IBLL.DTO.EpisodioDTO epis = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.DTO.EpisodioDTO, IBLL.DTO.EpisodioDTO>());
                Mapper.AssertConfigurationIsValid();
                epis = Mapper.Map<IBLL.DTO.EpisodioDTO>(raw);
            }
            catch(AutoMapperConfigurationException ex)
            {
                log.Error(string.Format("AutoMapper Configuration Error!\n{0}", ex.Message));
            }
            catch (AutoMapperMappingException ex)
            {
                log.Error(string.Format("AutoMapper Mapping Error!\n{0}", ex.Message));
            }
                
            return epis;
        }

        public IBLL.DTO.RichiestaRISDTO RichMapper(IDAL.DTO.RichiestaRISDTO raw)
        {
            IBLL.DTO.RichiestaRISDTO rich = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.DTO.RichiestaRISDTO, IBLL.DTO.RichiestaRISDTO>());
                Mapper.AssertConfigurationIsValid();
                rich = Mapper.Map<IBLL.DTO.RichiestaRISDTO>(raw);
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

        public List<IBLL.DTO.RichiestaRISDTO> RichMapper(List<IDAL.DTO.RichiestaRISDTO> raws)
        {
            List<IBLL.DTO.RichiestaRISDTO> res = null;

            if(raws != null){
                res = new List<IBLL.DTO.RichiestaRISDTO>();
                foreach(IDAL.DTO.RichiestaRISDTO raw in raws){
                    res.Add(this.RichMapper(raw));
                }
            }

            return res;
        }

        public IBLL.DTO.EsameDTO EsamMapper(IDAL.DTO.EsameDTO raw)
        {            
            IBLL.DTO.EsameDTO esam = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.DTO.EsameDTO, IBLL.DTO.EsameDTO>());
                Mapper.AssertConfigurationIsValid();
                esam = Mapper.Map<IBLL.DTO.EsameDTO>(raw);
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

        public List<IBLL.DTO.EsameDTO> EsamMapper(List<IDAL.DTO.EsameDTO> raws)
        {
            List<IBLL.DTO.EsameDTO> res = null;

            if (raws != null)
            {
                res = new List<IBLL.DTO.EsameDTO>();
                foreach (IDAL.DTO.EsameDTO raw in raws)
                {
                    res.Add(this.EsamMapper(raw));
                }
            }

            return res;
        }

        public IDAL.DTO.EsameDTO EsamUnMapper(IBLL.DTO.EsameDTO data)
        {
            IDAL.DTO.EsameDTO esam = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IBLL.DTO.EsameDTO, IDAL.DTO.EsameDTO>());
                Mapper.AssertConfigurationIsValid();
                esam = Mapper.Map<IDAL.DTO.EsameDTO>(data);
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
