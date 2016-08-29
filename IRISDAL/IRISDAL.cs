using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IRISDAL
    {
        IDAL.DTO.PazienteDTO GetPazienteById(string pazidid);
        IDAL.DTO.EpisodioDTO GetEpisodioById(string episidid);
        IDAL.DTO.RichiestaRISDTO GetRichiestaById(string richidid);
        List<IDAL.DTO.RichiestaRISDTO> GetRichiesteByEpis(string episidid);
        List<IDAL.DTO.EsameDTO> GetEsamiByRich(string richidid);
        List<IDAL.DTO.EsameDTO> GetEsamiByEpis(string episidid);
        IDAL.DTO.EsameDTO GetEsameById(string esamidid);
    }
}
