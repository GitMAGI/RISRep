//------------------------------------------------------------------------------
// <auto-generated>
//    Codice generato da un modello.
//
//    Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//    Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class hlt_plantari
    {
        public long seriale { get; set; }
        public string objectid { get; set; }
        public System.DateTime data_creazione { get; set; }
        public Nullable<System.DateTime> data_modifica { get; set; }
        public string nomeutente_creazione { get; set; }
        public string nomeutente_modifica { get; set; }
        public string locker { get; set; }
        public string versione { get; set; }
        public Nullable<int> ortesiplantare { get; set; }
        public Nullable<bool> ortesisilicone { get; set; }
        public Nullable<int> conchigliaamericana { get; set; }
        public Nullable<bool> retropiedeavvolgente { get; set; }
        public Nullable<bool> sostegnodellavolta { get; set; }
        public string cuneopronatore { get; set; }
        public string cuneosupinatore { get; set; }
        public Nullable<bool> gocciaretrocapitale { get; set; }
        public Nullable<bool> barraretrocapitale { get; set; }
        public string scarico { get; set; }
        public Nullable<double> mm { get; set; }
        public string rialzodelretropiededesc { get; set; }
        public Nullable<bool> neutro { get; set; }
        public string rialzosottolaprimafalangealluce { get; set; }
        public string pdfcreato { get; set; }
    }
}
