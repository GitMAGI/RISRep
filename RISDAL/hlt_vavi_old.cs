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
    
    public partial class hlt_vavi_old
    {
        public long seriale { get; set; }
        public string objectid { get; set; }
        public System.DateTime data_creazione { get; set; }
        public Nullable<System.DateTime> data_modifica { get; set; }
        public string nomeutente_creazione { get; set; }
        public string nomeutente_modifica { get; set; }
        public string locker { get; set; }
        public string versione { get; set; }
        public int idservizioepisodio { get; set; }
        public string esameobiettivo { get; set; }
        public Nullable<int> dolore { get; set; }
        public string doloretext { get; set; }
        public Nullable<int> rom { get; set; }
        public Nullable<int> gonfiore { get; set; }
        public Nullable<int> forza { get; set; }
        public Nullable<int> stabilita { get; set; }
        public Nullable<int> flessibilita { get; set; }
        public Nullable<int> deficitfunzionali { get; set; }
        public Nullable<int> disturbisensitivi { get; set; }
        public Nullable<int> dismetrieeterometrie { get; set; }
        public string romtxt { get; set; }
        public string gonfioretxt { get; set; }
        public string forzatxt { get; set; }
        public string stabilitatxt { get; set; }
        public string flessibilitatxt { get; set; }
        public string deficitfunzionalitxt { get; set; }
        public string disturbisensitivitxt { get; set; }
        public string dismetrieeterometrietxt { get; set; }
        public string andamentoclinico { get; set; }
        public Nullable<bool> esamiprecedenti { get; set; }
        public string notereferto { get; set; }
        public string indicazioni { get; set; }
        public Nullable<bool> acidoialuronico { get; set; }
        public Nullable<bool> anestetico { get; set; }
        public Nullable<bool> cortisone { get; set; }
        public string pdfcreato { get; set; }
    }
}
