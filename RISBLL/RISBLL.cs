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

        public RISBLL(IDAL.IRISDAL IDAL)
        {
            this.dal = IDAL;
        }

        public IBLL.DTO.PazienteDTO GetPazienteById(string id)
        {
            IDAL.VO.PazienteVO dalRes = this.dal.GetPazienteById(id);
            return this.PaziMapper(dalRes);
        }

        public IBLL.DTO.EpisodioDTO GetEpisodioById(string id)
        {
            IDAL.VO.EpisodioVO dalRes = this.dal.GetEpisodioById(id);
            return this.EpisMapper(dalRes);
        }

        public List<IBLL.DTO.RichiestaRISDTO> GetRichiesteRISByEpis(string episid)
        {
            List<IDAL.VO.RichiestaRISVO> dalRes = this.dal.GetRichiesteByEpis(episid);
            return this.RichMapper(dalRes);
        }

        public IBLL.DTO.RichiestaRISDTO GetRichiestaRISById(string richidid)
        {
            IDAL.VO.RichiestaRISVO dalRes = this.dal.GetRichiestaById(richidid);
            return this.RichMapper(dalRes);
        }

        public List<IBLL.DTO.EsameDTO> GetEsamiByRich(string richidid)
        {
            List<IDAL.VO.EsameVO> dalRes = this.dal.GetEsamiByRich(richidid);
            return this.EsamMapper(dalRes);
        }

        public List<IBLL.DTO.EsameDTO> GetEsamiByEpis(string episidid)
        {
            List<IDAL.VO.EsameVO> dalRes = this.dal.GetEsamiByEpis(episidid);
            return this.EsamMapper(dalRes);
        }

        public IBLL.DTO.EsameDTO GetEsameById(string esamidid)
        {
            IDAL.VO.EsameVO dalRes = this.dal.GetEsameById(esamidid);
            return this.EsamMapper(dalRes);
        }

        public int UpdateEsameById(IBLL.DTO.EsameDTO data, string esamidid)
        {
            int result = 0;

            IDAL.VO.EsameVO data_ = this.EsamMapper(data);
            result = dal.UpdateEsameByPk(data_, esamidid);

            return result;
        }

        public int AddEsame(IBLL.DTO.EsameDTO data)
        {
            int result = 0;

            IDAL.VO.EsameVO data_ = this.EsamMapper(data);
            result = dal.AddEsame(data_);

            return result;
        }

        public int DeleteEsameById(string esamidid)
        {
            int result = 0;

            result = dal.DeleteEsame(esamidid);

            return result;
        }
        
        // Mappers
        
        public IBLL.DTO.PazienteDTO PaziMapper(IDAL.VO.PazienteVO raw)
        {
            IBLL.DTO.PazienteDTO pazi = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.VO.PazienteVO, IBLL.DTO.PazienteDTO>());
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

        public IBLL.DTO.EpisodioDTO EpisMapper(IDAL.VO.EpisodioVO raw)
        {            
            IBLL.DTO.EpisodioDTO epis = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.VO.EpisodioVO, IBLL.DTO.EpisodioDTO>());
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

        public IBLL.DTO.RichiestaRISDTO RichMapper(IDAL.VO.RichiestaRISVO raw)
        {
            IBLL.DTO.RichiestaRISDTO rich = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.VO.RichiestaRISVO, IBLL.DTO.RichiestaRISDTO>());
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

        public List<IBLL.DTO.RichiestaRISDTO> RichMapper(List<IDAL.VO.RichiestaRISVO> raws)
        {
            List<IBLL.DTO.RichiestaRISDTO> res = null;

            if(raws != null){
                res = new List<IBLL.DTO.RichiestaRISDTO>();
                foreach(IDAL.VO.RichiestaRISVO raw in raws){
                    res.Add(this.RichMapper(raw));
                }
            }

            return res;
        }

        public IBLL.DTO.EsameDTO EsamMapper(IDAL.VO.EsameVO raw)
        {            
            IBLL.DTO.EsameDTO esam = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDAL.VO.EsameVO, IBLL.DTO.EsameDTO>());
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

        public List<IBLL.DTO.EsameDTO> EsamMapper(List<IDAL.VO.EsameVO> raws)
        {
            List<IBLL.DTO.EsameDTO> res = null;

            if (raws != null)
            {
                res = new List<IBLL.DTO.EsameDTO>();
                foreach (IDAL.VO.EsameVO raw in raws)
                {
                    res.Add(this.EsamMapper(raw));
                }
            }

            return res;
        }

        public IDAL.VO.EsameVO EsamMapper(IBLL.DTO.EsameDTO data)
        {
            IDAL.VO.EsameVO esam = null;
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IBLL.DTO.EsameDTO, IDAL.VO.EsameVO>());
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
    
    
    }
}
