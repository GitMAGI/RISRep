using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRetriever
{
    class DataRetriever : IDataRetriever
    {
        public object GetPaziData(string paziidid)
        {
            return (PazienteDTO) DataRetrieverBLL.GetPazienteById(paziidid);
        }

        public object GetEpisData(string episidid)
        {
            return (EpisodioDTO)DataRetrieverBLL.GetEpisodioById(episidid);
        }

        public object GetRichData(string richidid)
        {
            return (RichiesteRISDTO)DataRetrieverBLL.GetRichiestRISById(richidid);
        }

        public object GetRichsDataByEpis(string episidid)
        {
            return (RichiesteRISDTO[]) DataRetrieverBLL.GetRichiesteRISByEpis(episidid);
        }

        public object GetEsamDataByRich(string richidid)
        {
            return (EsameDTO[])DataRetrieverBLL.GetEsamsDataByRich(richidid);
        }

        public object GetEsamDataByEpis(string episidid)
        {
            return (EsameDTO[])DataRetrieverBLL.GetEsamsDataByEpis(episidid);
        }
    }
}
