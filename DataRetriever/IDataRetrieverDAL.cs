using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRetriever
{
    interface IDataRetrieverDAL
    {
        object GetPazienteById(string pazidid);
        object GetEpisodioById(string episidid);
        object GetRichiestaById(string richidid);
        object GetRichiesteByEpis(string episidid);
        object GetEsamiByRich(string richidid);
    }
}
