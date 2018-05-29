using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class UpotrabaFarma
    {
        public long Id { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public long MehanizacijaId { get; set; }
        public long FarmaId { get; set; }

        public Farma Farma { get; set; }
        public Mehanizacija Mehanizacija { get; set; }
    }
}
