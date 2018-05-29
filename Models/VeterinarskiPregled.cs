using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class VeterinarskiPregled
    {
        public long Id { get; set; }
        public DateTime Datum { get; set; }
        public double Trosak { get; set; }
        public long ZivotinjaId { get; set; }

        public PojedinaZivotinja Zivotinja { get; set; }
    }
}
