using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using System.Diagnostics;
using GeneralLib;

namespace BLL
{
    public partial class RISBLL
    {
        public List<IBLL.DTO.RichiestaRISDTO> GetRichiesteRISByEpis(string episid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            List<IBLL.DTO.RichiestaRISDTO> richs = null;

            try
            {
                List<IDAL.VO.RichiestaRISVO> dalRes = this.dal.GetRichiesteByEpis(episid);
                richs = RichiestaRISMapper.RichMapper(dalRes);
                log.Info(string.Format("{0} VO mapped to {1}", richs.Count, richs.First().GetType().ToString()));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }            

            tw.Stop();
            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return richs;
        }

        public IBLL.DTO.RichiestaRISDTO GetRichiestaRISById(string richidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            IBLL.DTO.RichiestaRISDTO rich = null;

            try
            {
                IDAL.VO.RichiestaRISVO dalRes = this.dal.GetRichiestaById(richidid);
                rich = RichiestaRISMapper.RichMapper(dalRes);
                log.Info(string.Format("1 VO mapped to {0}", rich.GetType().ToString()));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();
            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return rich;
        }

    }
}
