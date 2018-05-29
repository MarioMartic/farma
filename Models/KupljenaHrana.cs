using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class KupljenaHrana
    {
        public long Id { get; set; }
        public string Proizvodjac { get; set; }
        public string Prodavac { get; set; }
        public double Cjena { get; set; }
        public double Kolicina { get; set; }
        public DateTime DatumKupovine { get; set; }
        public long IdVrste { get; set; }

        public Vrsta IdVrsteNavigation { get; set; }
    }
}
