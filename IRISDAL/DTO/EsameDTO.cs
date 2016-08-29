using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.DTO
{
    public class EsameDTO
    {
        public long esameidid { get; set; }
        public string esamedesc { get; set; }
        public int esametipo { get; set; }
        public string esamestato { get; set; }
        public DateTime esamedataprenotazione { get; set; }
        public DateTime esamedataesecuzione { get; set; }
        public string esamereferto { get; set; }
        public string esame_ext_key { get; set; }
        public string esamerichid { get; set; }
    }
}
