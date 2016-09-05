﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.VO
{
    public class EpisodioVO
    {
        public int codice { get; set; }
        public string cartella { get; set; }
        public string tipo { get; set; }
        public string data { get; set; }
        public string ora { get; set; }
        public string dimissione { get; set; }
        public string ora_dimiss { get; set; }
        public string camera { get; set; }
        public string reparto { get; set; }
        public string convenzione1 { get; set; }
        public string convenzione2 { get; set; }
        public string impegnativa { get; set; }
        public string data_impegn { get; set; }
        public short giorni { get; set; }
        public string usl { get; set; }
        public string regione { get; set; }
        public string tessera { get; set; }
        public string diagnosi { get; set; }
        public string provenienza { get; set; }
        public string regime { get; set; }
        public int inviante { get; set; }
        public int accettante { get; set; }
        public string consegna { get; set; }
        public double totale { get; set; }
        public double dovuto { get; set; }
        public double acconto { get; set; }
        public string stato { get; set; }
        public string tipo_stato { get; set; }
        public int seriale { get; set; }
        public short privacy { get; set; }
        public short anonimato { get; set; }
        public string data_open { get; set; }
        public string pazext { get; set; }
        public string argos_nos { get; set; }
        public string bloccato { get; set; }
        public int id_invio { get; set; }
        public string dt_invio { get; set; }
        public string dt_pren { get; set; }
        public string dt_rice { get; set; }
        public string circoscrizione { get; set; }
        public string pnome { get; set; }
        public string pcognome { get; set; }
        public string pluogo_nascita { get; set; }
        public string ppaese { get; set; }
        public string pindirizzo { get; set; }
        public string pcomune { get; set; }
        public string pcap { get; set; }
        public string pprefisso { get; set; }
        public string ptelefono { get; set; }
        public string pcodice_fiscale { get; set; }
        public string pstato_civile { get; set; }
        public string pprofessione { get; set; }
        public string pdocumento { get; set; }
        public string pluogo_documento { get; set; }
        public string pdata_documento { get; set; }
        public string pdomicilio { get; set; }
        public string pcomune_domicilio { get; set; }
        public int pcurante { get; set; }
        public double ImportoServizioDefault { get; set; }
        public string domicilio_cap { get; set; }
        public string domicilio_comune { get; set; }
        public string domicilio_indirizzo { get; set; }
        public string domicilio_distretto { get; set; }
        public string cl_coge { get; set; }
        public int gestore { get; set; }
        public double dovuto_privato { get; set; }
        public double dovuto_assicurato { get; set; }
    }
}
