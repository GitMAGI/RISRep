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
    
    public partial class hlt_terapiafarmacologica
    {
        public long seriale { get; set; }
        public string objectid { get; set; }
        public System.DateTime data_creazione { get; set; }
        public Nullable<System.DateTime> data_modifica { get; set; }
        public string nomeutente_creazione { get; set; }
        public string nomeutente_modifica { get; set; }
        public string locker { get; set; }
        public string versione { get; set; }
        public string idepisodio { get; set; }
        public string terapia { get; set; }
        public string pdfcreato { get; set; }
    }
}
