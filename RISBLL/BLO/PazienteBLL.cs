using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;

namespace BLL
{
    public partial class RISBLL
    {
        public IBLL.DTO.PazienteDTO GetPazienteById(string id)
        {
            IDAL.VO.PazienteVO dalRes = this.dal.GetPazienteById(id);
            return PazienteMapper.PaziMapper(dalRes);
        }
    }
}
