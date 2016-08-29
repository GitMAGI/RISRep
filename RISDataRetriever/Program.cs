using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IBLL.DTO;
using System.Configuration;

namespace RISDataRetriever
{
    class Program
    {
        static void Main(string[] args)
        {            
            DAL.RISDAL dal = new DAL.RISDAL();
            BLL.RISBLL bll = new BLL.RISBLL(dal);
            DataRetriever DR = new DataRetriever(bll);

            /*
            IBLL.DTO.EpisodioDTO ep = (IBLL.DTO.EpisodioDTO)DR.GetEpisData("1828");
            IBLL.DTO.PazienteDTO p = (IBLL.DTO.PazienteDTO)DR.GetPaziData((ep.codice).ToString());
            List<IBLL.DTO.RichiestaRISDTO> es = (List<IBLL.DTO.RichiestaRISDTO>)DR.GetRichsDataByEpis("490937");
            IBLL.DTO.RichiestaRISDTO e = (IBLL.DTO.RichiestaRISDTO)DR.GetRichData("20160804105146473");
            
            List<IBLL.DTO.EsameDTO> esams = (List<IBLL.DTO.EsameDTO>)DR.GetEsamsDataByRich("20160804111023719");

            List<IBLL.DTO.EsameDTO> esams2 = (List<IBLL.DTO.EsameDTO>)DR.GetEsamsDataByEpis("490937");
            */

            string examId = "3";
            /*
             * 
             * 
            
            Dictionary<string, object> exam = new Dictionary<string, object>();
            exam["esameidid"] = 3;
            exam["esamestato"] = "A";
            exam["esame_ext_key"] = "7988282";
            int res = dal.SetEsameByPk(exam, examId);

             * 
             * 
             * 
             * */

            IDAL.DTO.EsameDTO toW = dal.GetEsameById("3");
            toW.esamestato = "R";
            toW.esame_ext_key = "0909029";
            int res = dal.SetEsameByPk(toW, "3");



            System.Console.WriteLine("Premere un tasto per continuare ...");
            System.Console.ReadKey();        
        }
    }
}

