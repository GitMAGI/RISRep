using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IRISDAO
    {
        int SetEsameByPk(Dictionary<string, object> data, string esamidid);
        int SetEsameByPk(IDAL.DTO.EsameDTO data, string esamidid);

        int AddEsame(Dictionary<string, object> data);
        int AddEsame(IDAL.DTO.EsameDTO data);
    }
}
