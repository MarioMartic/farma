using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Prirast
    {
        public long Id { get; set; }
        public long IdZivotinje { get; set; }
        public double Masa { get; set; }
        public DateTime DatumVrijeme { get; set; }

        public PojedinaZivotinja IdZivotinjeNavigation { get; set; }
    }
}
