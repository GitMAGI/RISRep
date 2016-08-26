using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataRetriever
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRetriever DR = new DataRetriever();
            
            EpisodioDTO ep = (EpisodioDTO)DR.GetEpisData("1828");
            PazienteDTO p = (PazienteDTO)DR.GetPaziData((ep.codice).ToString());
            RichiesteRISDTO[] es = (RichiesteRISDTO[])DR.GetRichsDataByEpis("490937");
            RichiesteRISDTO e = (RichiesteRISDTO)DR.GetRichData("20160804142309906");

            EsameDTO[] esams = (EsameDTO[])DR.GetEsamDataByRich("20160804111023719");

            EsameDTO[] esams2 = (EsameDTO[])DR.GetEsamDataByEpis("490937");
            
            System.Console.WriteLine("Premere un tasto per continuare ...");
            System.Console.ReadKey();
        }
    }
}

