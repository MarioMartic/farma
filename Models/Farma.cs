using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Farma
    {
        public Farma()
        {
            Klanje = new HashSet<Klanje>();
            PojedinaZivotinja = new HashSet<PojedinaZivotinja>();
            SkupinaZivotinja = new HashSet<SkupinaZivotinja>();
            UpotrabaFarma = new HashSet<UpotrabaFarma>();
        }

        public long Id { get; set; }
        public string LokalniNaziv { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public long VlasnikId { get; set; }

        public Vlasnik Vlasnik { get; set; }
        public ICollection<Klanje> Klanje { get; set; }
        public ICollection<PojedinaZivotinja> PojedinaZivotinja { get; set; }
        public ICollection<SkupinaZivotinja> SkupinaZivotinja { get; set; }
        public ICollection<UpotrabaFarma> UpotrabaFarma { get; set; }
    }
}
