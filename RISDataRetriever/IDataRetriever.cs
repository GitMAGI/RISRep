using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISDataRetriever
{
    interface IDataRetriever
    {       
        object GetPaziData(string paziidid);
        object GetEpisData(string episidid);
        object GetRichData(string richidid);
        object GetRichsDataByEpis(string episidid);
        object GetEsamsDataByRich(string richidid);
        object GetEsamsDataByEpis(string episidid);
        object GetEsamDataById(string esamidid);
    }
}
