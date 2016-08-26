using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRetriever
{
    interface IDataRetriever
    {
        object GetPaziData(string paziidid);
        object GetEpisData(string episidid);
        object GetRichData(string richidid);
        object GetRichsDataByEpis(string episidid);
        object GetEsamDataByRich(string richidid);
        object GetEsamDataByEpis(string episidid);
    }
}
