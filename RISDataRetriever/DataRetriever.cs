using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.DTO;

namespace RISDataRetriever
{
    class DataRetriever : IDataRetriever
    {
        private IBLL.IRISBLL bll;

        public DataRetriever(IBLL.IRISBLL BLL)
        {
            this.bll = BLL;
        }

        public object GetPaziData(string paziidid)
        {
            return (PazienteDTO)this.bll.GetPazienteById(paziidid);
        }

        public object GetEpisData(string episidid)
        {
            return (EpisodioDTO)this.bll.GetEpisodioById(episidid);
        }

        public object GetRichData(string richidid)
        {
            return (RichiestaRISDTO)this.bll.GetRichiestaRISById(richidid);
        }

        public object GetRichsDataByEpis(string episidid)
        {
            return (List<RichiestaRISDTO>)this.bll.GetRichiesteRISByEpis(episidid);
        }

        public object GetEsamsDataByRich(string richidid)
        {
            return (List<EsameDTO>)this.bll.GetEsamiByRich(richidid);
        }

        public object GetEsamsDataByEpis(string episidid)
        {
            return (List<EsameDTO>)this.bll.GetEsamiByEpis(episidid);
        }

        public object GetEsamDataById(string esamidid)
        {
            return (EsameDTO)this.bll.GetEsameById(esamidid);
        }
    }
}
