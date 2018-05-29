using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class DobivenaHranaPojedinacne
    {
        public long Id { get; set; }
        public double Kolicina { get; set; }
        public DateTime Datum { get; set; }
        public long ZivotinjaId { get; set; }

        public PojedinaZivotinja Zivotinja { get; set; }
    }
}
