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

            
            IBLL.DTO.EpisodioDTO ep = (IBLL.DTO.EpisodioDTO)DR.GetEpisData("1828");
            IBLL.DTO.PazienteDTO p = (IBLL.DTO.PazienteDTO)DR.GetPaziData((ep.codice).ToString());
            List<IBLL.DTO.RichiestaRISDTO> es = (List<IBLL.DTO.RichiestaRISDTO>)DR.GetRichsDataByEpis("490937");
            IBLL.DTO.RichiestaRISDTO e = (IBLL.DTO.RichiestaRISDTO)DR.GetRichData("20160804105146473");
            
            List<IBLL.DTO.EsameDTO> esams = (List<IBLL.DTO.EsameDTO>)DR.GetEsamsDataByRich("20160804111023719");

            List<IBLL.DTO.EsameDTO> esams2 = (List<IBLL.DTO.EsameDTO>)DR.GetEsamsDataByEpis("490937");
            
            string examId = "3";           
            
            Dictionary<string, object> exam = new Dictionary<string, object>();
            exam["esameidid"] = 3;
            exam["esamestato"] = "A";
            exam["esame_ext_key"] = "7988282";
            int res = dal.UpdateEsameByPk(exam, examId);
            
            IDAL.VO.EsameVO toW = dal.GetEsameById("3");
            toW.esamestato = "A";
            toW.esame_ext_key = "2919021";
            res = dal.UpdateEsameByPk(toW, "3");
            

            string esame_ext_key = "8877943543543";
            string esamedataesecuzione = "08/08/2016 18:00:00";
            string esamedataprenotazione = "21/03/2016 19:00:00";
            string esamedesc = "Pomi Adami";
            string esamereferto = "http://iyuyiyuiyu";
            string esamestato = "R";
            string esamerichid = "20160804111023719";
            int esametipo = 14852;

            IBLL.DTO.EsameDTO esam = new EsameDTO();

            esam.esamerichid = esamerichid;
            esam.esame_ext_key = esame_ext_key;
            esam.esamedataesecuzione = esamedataesecuzione;
            esam.esamedataprenotazione = esamedataprenotazione;
            esam.esamedesc = esamedesc;
            esam.esamereferto = esamereferto;
            esam.esamestato = esamestato;
            esam.esametipo = esametipo;

            int result = bll.AddEsame(esam);


            System.Console.WriteLine("Premere un tasto per continuare ...");
            System.Console.ReadKey();        
        }
    }
}

