using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class RadZaDrugoga
    {
        public long Id { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public double Zarada { get; set; }
        public double TrajanjeRadnje { get; set; }
        public long MehanizacijaId { get; set; }

        public Mehanizacija Mehanizacija { get; set; }
    }
}
