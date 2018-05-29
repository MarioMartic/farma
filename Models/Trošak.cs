using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Trošak
    {
        public long Id { get; set; }
        public string OpisTroska { get; set; }
        public DateTime Datum { get; set; }
        public long MehanizacijaId { get; set; }
        public double? Cijena { get; set; }

        public Mehanizacija Mehanizacija { get; set; }
    }
}
