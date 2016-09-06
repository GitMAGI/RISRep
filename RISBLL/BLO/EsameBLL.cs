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
        public List<IBLL.DTO.EsameDTO> GetEsamiByRich(string richidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            List<IBLL.DTO.EsameDTO> esams = null;

            try
            {
                List<IDAL.VO.EsameVO> dalRes = this.dal.GetEsamiByRich(richidid);
                esams = EsameMapper.EsamMapper(dalRes);
                log.Info(string.Format("{0} VO mapped to {1}", esams.Count, esams.First().GetType().ToString()));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();
            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return esams;
        }

        public List<IBLL.DTO.EsameDTO> GetEsamiByEpis(string episidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            List<IBLL.DTO.EsameDTO> esams = null;

            try
            {
                List<IDAL.VO.EsameVO> dalRes = this.dal.GetEsamiByEpis(episidid);
                esams = EsameMapper.EsamMapper(dalRes);
                log.Info(string.Format("{0} VO mapped to {1}", esams.Count, esams.First().GetType().ToString()));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();
            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return esams;
        }

        public IBLL.DTO.EsameDTO GetEsameById(string esamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            IBLL.DTO.EsameDTO esam = null;

            try
            {
                IDAL.VO.EsameVO dalRes = this.dal.GetEsameById(esamidid);
                esam = EsameMapper.EsamMapper(dalRes);
                log.Info(string.Format("1 VO mapped to {0}", esam.GetType().ToString()));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();
            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return esam;
        }

        public int UpdateEsameById(IBLL.DTO.EsameDTO data, string esamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;

            try
            {
                IDAL.VO.EsameVO data_ = EsameMapper.EsamMapper(data);
                log.Info(string.Format("1 {0} mapped to {1}", data.GetType().ToString(), data_.GetType().ToString()));
                result = dal.UpdateEsameByPk(data_, esamidid);
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();
            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }

        public int AddEsame(IBLL.DTO.EsameDTO data)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;

            try
            {
                IDAL.VO.EsameVO data_ = EsameMapper.EsamMapper(data);
                log.Info(string.Format("1 {0} mapped to {1}", data.GetType().ToString(), data_.GetType().ToString()));
                result = dal.AddEsame(data_);
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();
            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }

        public int DeleteEsameById(string esamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = 0;

            try
            {
                result = dal.DeleteEsame(esamidid);
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();
            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
    }
}
