using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Vrsta
    {
        public Vrsta()
        {
            Klanje = new HashSet<Klanje>();
            KupljenaHrana = new HashSet<KupljenaHrana>();
            PojedinaZivotinja = new HashSet<PojedinaZivotinja>();
            SkupinaZivotinja = new HashSet<SkupinaZivotinja>();
        }

        public long Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Klanje> Klanje { get; set; }
        public ICollection<KupljenaHrana> KupljenaHrana { get; set; }
        public ICollection<PojedinaZivotinja> PojedinaZivotinja { get; set; }
        public ICollection<SkupinaZivotinja> SkupinaZivotinja { get; set; }
    }
}
