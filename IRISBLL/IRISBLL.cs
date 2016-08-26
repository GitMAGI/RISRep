using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IRISBLL
    {        
        DTO.PazienteDTO GetPazienteById(string id);
        DTO.EpisodioDTO GetEpisodioById(string id);
        List<IBLL.DTO.RichiestaRISDTO> GetRichiesteRISByEpis(string episid);
        DTO.RichiestaRISDTO GetRichiestaRISById(string richidid);
        List<DTO.EsameDTO> GetEsamiDataByRich(string richidid);
        List<DTO.EsameDTO> GetEsamiDataByEpis(string episidid);
    }
}
