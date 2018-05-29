using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class DobivenaHranaSkupne
    {
        public long Id { get; set; }
        public double Kolicina { get; set; }
        public DateTime Datum { get; set; }
        public long ZivotinjaId { get; set; }

        public SkupinaZivotinja Zivotinja { get; set; }
    }
}
