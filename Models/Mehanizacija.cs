using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Mehanizacija
    {
        public Mehanizacija()
        {
            RadZaDrugoga = new HashSet<RadZaDrugoga>();
            Trošak = new HashSet<Trošak>();
            UpotrabaFarma = new HashSet<UpotrabaFarma>();
            UpotrabaOranica = new HashSet<UpotrabaOranica>();
        }

        public long Id { get; set; }
        public double NabavnaCijena { get; set; }
        public DateTime DatumKupnje { get; set; }
        public long VlasnikId { get; set; }
        public long KategorijaId { get; set; }
        public double TrenutnaVrijednost { get; set; }

        public KategorijaMehanizacije Kategorija { get; set; }
        public Vlasnik Vlasnik { get; set; }
        public ICollection<RadZaDrugoga> RadZaDrugoga { get; set; }
        public ICollection<Trošak> Trošak { get; set; }
        public ICollection<UpotrabaFarma> UpotrabaFarma { get; set; }
        public ICollection<UpotrabaOranica> UpotrabaOranica { get; set; }
    }
}
