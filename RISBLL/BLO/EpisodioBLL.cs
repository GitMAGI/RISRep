using BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class RISBLL
    {
        public IBLL.DTO.EpisodioDTO GetEpisodioById(string id)
        {
            IDAL.VO.EpisodioVO dalRes = this.dal.GetEpisodioById(id);
            return EpisodioMapper.EpisMapper(dalRes);
        }
    }
}
