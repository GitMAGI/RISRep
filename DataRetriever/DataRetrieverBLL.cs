using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRetriever
{
    class DataRetrieverBLL
    {
        public static PazienteDTO GetPazienteById(string id)
        {
            IDataRetrieverDAL dal = new DataRetrieverDAL();
            return (PazienteDTO)dal.GetPazienteById(id);
        }

        public static EpisodioDTO GetEpisodioById(string id)
        {
            DataRetrieverDAL dal = new DataRetrieverDAL();
            return (EpisodioDTO)dal.GetEpisodioById(id);
        }

        public static RichiesteRISDTO[] GetRichiesteRISByEpis(string episid)
        {
            DataRetrieverDAL dal = new DataRetrieverDAL();
            return (RichiesteRISDTO[]) dal.GetRichiesteByEpis(episid);
        }

        public static RichiesteRISDTO GetRichiestRISById(string richidid)
        {
            DataRetrieverDAL dal = new DataRetrieverDAL();
            return (RichiesteRISDTO)dal.GetRichiestaById(richidid);
        }

        public static EsameDTO[] GetEsamsDataByRich(string richidid)
        {
            DataRetrieverDAL dal = new DataRetrieverDAL();
            return (EsameDTO[])dal.GetEsamiByRich(richidid);
        }

        public static EsameDTO[] GetEsamsDataByEpis(string episidid)
        {
            DataRetrieverDAL dal = new DataRetrieverDAL();
            return (EsameDTO[])dal.GetEsamiByEpis(episidid);
        }
    
    }
}
