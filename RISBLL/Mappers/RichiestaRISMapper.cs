﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class RichiestaRISMapper
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static IBLL.DTO.RichiestaRISDTO RichMapper(IDAL.VO.RichiestaRISVO raw)
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

        public static List<IBLL.DTO.RichiestaRISDTO> RichMapper(List<IDAL.VO.RichiestaRISVO> raws)
        {
            List<IBLL.DTO.RichiestaRISDTO> res = null;

            if (raws != null)
            {
                res = new List<IBLL.DTO.RichiestaRISDTO>();
                foreach (IDAL.VO.RichiestaRISVO raw in raws)
                {
                    res.Add(RichMapper(raw));
                }
            }

            return res;
        }

    }
}
