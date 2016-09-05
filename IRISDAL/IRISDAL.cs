using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IRISDAL
    {
        IDAL.VO.PazienteVO GetPazienteById(string pazidid);
        IDAL.VO.EpisodioVO GetEpisodioById(string episidid);

        IDAL.VO.RichiestaRISVO GetRichiestaById(string richidid);
        List<IDAL.VO.RichiestaRISVO> GetRichiesteByEpis(string episidid);

        List<IDAL.VO.EsameVO> GetEsamiByRich(string richidid);
        List<IDAL.VO.EsameVO> GetEsamiByEpis(string episidid);
        IDAL.VO.EsameVO GetEsameById(string esamidid);
        int UpdateEsameByPk(Dictionary<string, object> data, string esamidid);
        int UpdateEsameByPk(IDAL.VO.EsameVO data, string esamidid);
        int AddEsame(Dictionary<string, object> data);
        int AddEsame(IDAL.VO.EsameVO data);
        int DeleteEsame(string esamidid);
        int DeleteEsame(IDAL.VO.EsameVO data);
    }
}
