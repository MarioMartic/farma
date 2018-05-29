using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class PojedinaZivotinja
    {
        public PojedinaZivotinja()
        {
            DobivenaHranaPojedinacne = new HashSet<DobivenaHranaPojedinacne>();
            Prirast = new HashSet<Prirast>();
            VeterinarskiPregled = new HashSet<VeterinarskiPregled>();
        }

        public long Id { get; set; }
        public long VrstaId { get; set; }
        public double Trosak { get; set; }
        public long FarmaId { get; set; }
        public DateTime DatumKupovine { get; set; }

        public Farma Farma { get; set; }
        public Vrsta Vrsta { get; set; }
        public ICollection<DobivenaHranaPojedinacne> DobivenaHranaPojedinacne { get; set; }
        public ICollection<Prirast> Prirast { get; set; }
        public ICollection<VeterinarskiPregled> VeterinarskiPregled { get; set; }
    }
}
