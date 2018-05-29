using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class SkupinaZivotinja
    {
        public SkupinaZivotinja()
        {
            DobivenaHranaSkupne = new HashSet<DobivenaHranaSkupne>();
        }

        public long Id { get; set; }
        public long? VrstaId { get; set; }
        public long Kolicina { get; set; }
        public long FarmaId { get; set; }
        public double Trosak { get; set; }

        public Farma Farma { get; set; }
        public Vrsta Vrsta { get; set; }
        public ICollection<DobivenaHranaSkupne> DobivenaHranaSkupne { get; set; }
    }
}
