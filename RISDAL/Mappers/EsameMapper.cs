using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class EsameMapper
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public static IDAL.VO.EsameVO EsamMapper(hlt_esameradio data)
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
        public static List<IDAL.VO.EsameVO> EsamMapper(List<hlt_esameradio> data)
        {
            List<IDAL.VO.EsameVO> esams = null;

            if (data != null && data.Count > 0)
            {
                esams = new List<IDAL.VO.EsameVO>();

                foreach (hlt_esameradio datum in data)
                {
                    IDAL.VO.EsameVO tmp = null;

                    tmp = EsamMapper(datum);

                    if (tmp != null)
                        esams.Add(tmp);
                }
            }

            return esams;
        }
        public static hlt_esameradio EsamMapper(IDAL.VO.EsameVO data)
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
