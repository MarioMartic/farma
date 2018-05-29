using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Klanje
    {
        public long Id { get; set; }
        public DateTime Datum { get; set; }
        public double KolicinaMesa { get; set; }
        public string Opis { get; set; }
        public long FarmaId { get; set; }
        public long VrstaId { get; set; }

        public Farma Farma { get; set; }
        public Vrsta Vrsta { get; set; }
    }
}
